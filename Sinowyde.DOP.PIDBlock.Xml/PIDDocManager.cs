using System.Drawing;
using Sinowyde.DOP.DTProxy;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDBlock.GoObjectEx;
using Sinowyde.DOP.PIDBlock.Xml.Entitys;
using Sinowyde.DOP.PIDAlgorithm.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sinowyde.DataModel;
using Sinowyde.Util;
using Sinowyde.Zip;
using Northwoods.Go;
using System.Windows.Forms;
using Sinowyde.DOP.PIDBlock.IO;

namespace Sinowyde.DOP.PIDBlock.Xml
{
    public enum ActionEnum
    {
        Default = -1,
        LoadDoc,
        NewDoc,
        ModifyDoc,
        DeleteDoc
    }

    /// <summary>
    /// 文档集合管理器
    /// </summary>
    public class PIDDocManager
    {
        #region  单例数据库访问对象

        private static PIDDocManager instance = null;
        private static object _lock = new object();
        public static PIDDocManager Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new PIDDocManager();
                }
            }

            return instance;
        }
        private PIDDocManager()
        {
        }

        #endregion

        public ActionEnum CurrentAction { get; set; }
        public PIDDocument ActiveDoc { get; private set; }

        /// <summary>
        /// 缓存路径
        /// </summary>
        private string DocPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Sinowyde", "Sama", "DocPath");
        /// <summary>
        /// 备份路径
        /// </summary>
        private string BackupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Sinowyde", "Sama", "BackupPath");
        /// <summary>
        /// 文档map
        /// </summary>
        private IDictionary<string, PIDDocument> DocMap = new Dictionary<string, PIDDocument>();
        /// <summary>
        /// 发生变化的文档
        /// </summary>
        private IList<PIDDocument> changedDocs = new List<PIDDocument>();
        /// <summary>
        /// 删除的文档，留作后用
        /// </summary>
        private IList<PIDDocument> deletedDocs = new List<PIDDocument>();

        /// <summary>
        /// 按照索引顺序返回文档列表
        /// </summary>
        public IList<PIDDocument> Documents
        {
            get
            {
                if (DocMap.Values == null)
                    return new List<PIDDocument>(0);
                else
                    return DocMap.Values.OrderBy(v => v.AlgPage.GIndex).ToList<PIDDocument>();
            }
        }
        /// <summary>
        /// 获取索引对应文档
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public PIDDocument GetDocument(string guid)
        {
            return DocMap[guid] as PIDDocument;
        }
        /// <summary>
        /// 清空环境
        /// </summary>
        private void ResetEnvVar()
        {
            this.DocMap.Clear();
            PageBlockRelation.Instance().Clear();
            this.changedDocs.Clear();
            this.deletedDocs.Clear();
        }
        /// <summary>
        /// 从数据库加载所有页
        /// </summary>
        public void InitFromDB()
        {
            ResetEnvVar();
            IList<PIDAlgPage> pages = PIDDataLogic.Instance().GetPages();
            if (null != pages)
            {
                foreach (PIDAlgPage page in pages)
                {
                    AddDoc(new PIDDocument(page));
                }
            }
        }

        private void AddDoc(PIDDocument doc)
        {
            doc.Changed += doc_Changed;
            DocMap.Add(doc.AlgPage.Guid, doc);
            PageBlockRelation.Instance().AddRealtedPB(doc);
        }
        /// <summary>
        /// 文档发生变化，记录下来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doc_Changed(object sender, GoChangedEventArgs e)
        {
            if (!changedDocs.Contains(sender as PIDDocument))
            {
                changedDocs.Add(sender as PIDDocument);
                if ((sender as PIDDocument).ChangedBlock)
                    ChangeAlgorithm = true;
            }
        }
        /// <summary>
        /// 文档内容发生变化，涉及到算法参数以及拓扑结构等
        /// 如果发生变化，则提交时需要编译，否则不需要编译
        /// 如果发生变化，提交后才能调试，否则可直接调试
        /// </summary>
        /// <returns></returns>
        public volatile bool ChangeAlgorithm = false;

        /// <summary>
        /// 文档发送变化
        /// </summary>
        /// <returns></returns>
        public bool ChangeDoc()
        {
            return changedDocs.Count > 0 || deletedDocs.Count > 0;
        }

        /// <summary>
        /// 当前最大页索引
        /// </summary>
        /// <returns></returns>
        public long GetMaxPageIndex()
        {
            long index = 0;
            if (DocMap.Values != null)
            {
                foreach (PIDDocument doc in DocMap.Values)
                {
                    index = Math.Max(index, doc.AlgPage.GIndex);
                }
            }
            return index;
        }
        /// <summary>
        /// 是否已经存在索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ExistGIndex(long index)
        {
            foreach (var docKey in DocMap)
            {
                if (docKey.Value.AlgPage.GIndex == index)
                    return true;
            }
            return false;
        }

        public PIDDocument NewDoc(long index, string description)
        {
            var page = new PIDAlgPage
                {
                    GIndex = index,
                    Guid = Guid.NewGuid().ToString("N"),
                    Description = description,
                    Timestamp = DateTime.Now.Ticks,
                    Content = string.Empty
                };
            var doc = new PIDDocument(page);
            AddDoc(doc);
            //记录变更
            this.changedDocs.Add(doc);
            this.ChangeAlgorithm = true;
            return doc;
        }

        /// <summary>
        /// 修改页
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public void ModifyDoc(string guid, long index, string description)
        {
            if (this.DocMap.ContainsKey(guid))
            {
                DocMap[guid].UpdateIndex(index);
                DocMap[guid].AlgPage.Timestamp = DateTime.Now.Ticks;
                DocMap[guid].AlgPage.Description = description;

                this.changedDocs.Add(DocMap[guid]);
            }
        }

        /// <summary>
        /// 删除页
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDoc(string guid)
        {
            if (this.DocMap.ContainsKey(guid))
            {
                PIDDocument doc = this.DocMap[guid];
                this.DocMap.Remove(guid);
                this.changedDocs.Remove(doc);
                this.deletedDocs.Add(doc);
                PageBlockRelation.Instance().RemoveRealtedPB(doc);
                try
                {
                    string file = GetCacheFilePath(doc.Name);
                    if (File.Exists(file))
                        File.Delete(file);
                    this.ChangeAlgorithm = true;
                }
                catch (Exception ex)
                {
                    Log.LogUtil.LogFatal("删除缓存文件失败", ex);
                }
            }
        }


        /// <summary>
        /// 设置当前文档  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PIDDocument SetActiveDocByGIndex(string gIndex)
        {
            PIDDocument doc = null;
            foreach (var item in DocMap)
            {
                if (item.Value.AlgPage.GIndex.Equals(gIndex))
                {
                    this.ActiveDoc = item.Value;
                }
                break;
            }
            return doc;
        }

        /// <summary>
        /// 设置当前文档  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PIDDocument SetActiveDoc(string guid)
        {
            PIDDocument doc = null;
            var flag = DocMap.TryGetValue(guid, out doc);
            if (flag)
                this.ActiveDoc = doc;

            return doc;
        }

        /// <summary>
        /// 保存当前文档,删除重新建立
        /// </summary>
        /// <returns></returns>
        public bool SaveToCache(int hascode = -1)
        {
            try
            {
                if (!RecreateDocPath())
                    return false;


                foreach (var item in DocMap)
                {
                    if (!hascode.Equals(-1) && !item.Value.GetHashCode().Equals(hascode))
                        continue;

                    string file = this.GetCacheFilePath(item.Value.Name);
                    string content = item.Value.SerializeContent();
                    File.WriteAllText(file, content);
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("PIDDocManager.SaveToCache:" + ex);
                return false;
            }
        }

        /// <summary>
        /// 打开文档后
        /// </summary>
        public void AfterLoad()
        {
            //设置一下显示组号
            if (PIDDocument.VisBottomText)
            {
                foreach (var doc in DocMap)
                {
                    foreach (var block in doc.Value.OfType<PIDGeneralBlock>())
                    {
                        block.BottomText = string.Format("{0}-{1}", block.Algorithm.GroupIndex, block.Algorithm.IndexInGroup);
                    }
                }
            }

            PageBlockRelation.Instance().Refresh();
        }

        /// <summary>
        /// 打开文档,从本地文件到内存
        /// </summary>
        /// <returns></returns>
        public bool OpenFromCache()
        {
            try
            {
                this.ResetEnvVar();
                foreach (var file in new DirectoryInfo(DocPath).GetFiles("*.xml"))
                {
                    string content = File.ReadAllText(file.FullName);
                    var doc = new PIDDocument(file.Name, content);
                    AddDoc(doc);
                }
                AfterLoad();
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("PIDDocManager.OpenDoc:" + ex);
                return false;
            }
        }

        /// <summary>
        /// 判断有误本地缓存文件
        /// </summary>
        /// <returns></returns>
        public bool ExistCache()
        {
            var flag = Directory.Exists(Instance().DocPath) && Directory.GetFiles(Instance().DocPath, "*.xml").Any();
            return flag;
        }

        public IEnumerable<RecoveryEntity> GetBackupsInfo()
        {
            var list = new List<RecoveryEntity>();
            foreach (var file in new DirectoryInfo(BackupPath).GetFiles("*.sama"))
            {
                var entity = new RecoveryEntity();
                var strs = file.Name.Split('.');
                if (strs.Length != 5) continue;
                entity.People = strs[1];
                entity.Description = strs[2];
                entity.BackupTimestamp = new DateTime(ConvertUtil.ConvertToLong(strs[3]));
                entity.FileName = file.FullName;
                list.Add(entity);
            }
            return list.OrderByDescending(v => v.BackupTimestamp);
        }

        /// <summary>
        /// 获取文档名称
        /// </summary>
        /// <param name="docName"></param>
        /// <returns></returns>
        private string GetCacheFilePath(string docName)
        {
            return Path.Combine(DocPath, string.Format("{0}.xml", docName));
        }

        /// <summary>
        /// 重建缓存路径
        /// </summary>
        private bool RecreateDocPath()
        {
            try
            {
                if (Directory.Exists(DocPath))
                    Directory.Delete(DocPath, true); //后续优化成本地本身有一些文件
                Directory.CreateDirectory(DocPath);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("重建缓存路径失败", ex);
                return false;
            }
        }
        /// <summary>
        /// 下载到缓存
        /// </summary>
        /// <returns></returns>
        public bool UpdateToCache()
        {
            try
            {
                if (!RecreateDocPath())
                    return false;
                IList<PIDAlgPage> pages = PIDDataLogic.Instance().GetPages();
                if (pages != null)
                {
                    foreach (PIDAlgPage page in pages)
                    {
                        var path = GetCacheFilePath(page.Summary);
                        File.WriteAllText(path, page.Content);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("现在sama页失败", ex);
                return false;
            }
        }

        /// <summary>
        /// 上载,把本地的xml文件上载到服务器,删除服务器所有PIDAlgorithmGroup,再根据Guid新建
        /// </summary>
        public bool UploadToDB()
        {
            try
            {
                //1.删除服务器所有PIDAlgorithmGroup
                PIDDataLogic.Instance().ClearPages();

                //2.根据Guid新建,批量
                foreach (var docKey in this.DocMap)
                {
                    PIDDocument doc = docKey.Value;
                    doc.UpdateDB();
                }

                this.ChangeAlgorithm = false;

                //3.更新模型
                PIDDataLogic.Instance().UpdateModelVersion(ModelType.Sama);

                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("PIDDocManager.Upload:", ex);
                return false;
            }
        }

        /// <summary>
        /// 恢复到该备份
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool Recovery(string fileName)
        {
            try
            {
                //1.删除当前
                if (!RecreateDocPath())
                    return false;
                //2解压到本地
                ZipHelper.Uncompress(fileName, DocPath);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("恢复错误:" + ex);
                return false;
            }
        }

        /// <summary>
        /// 添加备份
        /// </summary>
        /// <param name="people"></param>
        /// <param name="des"></param>
        /// <returns></returns>
        public bool Backup(string people, string des)
        {
            try
            {
                var name = string.Format("{0}.{1}.{2}.{3}", Guid.NewGuid().ToString("N"), people, des, DateTime.Now.Ticks);

                ZipHelper.Compress(Path.Combine(BackupPath, string.Format("{0}.sama", name)), DocPath);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("备份错误:" + ex);
                return false;
            }
        }

        /// <summary>
        /// 从数据库获取所有页的简要信息
        /// </summary>
        /// <returns></returns>
        public IList<PIDAlgPageSummary> GetPageSummaryFromDB()
        {
            return PIDDataLogic.Instance().GetPageSummys();
        }

        /// <summary>
        /// 显示块IndexInGroup
        /// </summary>
        public void VisIndexInGroup(bool visibility)
        {
            PIDDocument.VisBottomText = visibility;
            foreach (var item in DocMap)
            {
                foreach (var block in item.Value.OfType<PIDGeneralBlock>())
                {
                    block.BottomText = visibility ? string.Format("{0}-{1}", block.Algorithm.GroupIndex, block.Algorithm.IndexInGroup) : string.Empty;
                }
            }
        }

        public IList<StatisticsEntity> GetAllBlocks()
        {
            var list = new List<StatisticsEntity>();//return
            var dicGroup = new Dictionary<string, StatisticsEntity>();//统计有多少分组
            var dicBlock = new Dictionary<string, StatisticsEntity>();//统计有多少种算法块
            int id = 1;

            var entityRoot = new StatisticsEntity();
            entityRoot.ParentID = -1;
            entityRoot.ID = id;
            entityRoot.Type = EntityTypeEnum.AllS;
            list.Add(entityRoot);
            id++;

            foreach (var item in DocMap)
            {
                foreach (var block in item.Value.OfType<PIDGeneralBlock>())
                {
                    var typeStr = block.Algorithm.AlgType.Split('.');
                    var group = typeStr[3];
                    var alg = block.Algorithm.AlgName;// typeStr[4];
                    var pageIndex = block.Algorithm.GroupIndex;
                    var indexInGroup = block.Algorithm.IndexInGroup;
                    var guid = block.Algorithm.Identity;

                    if (!dicGroup.ContainsKey(group))//统计节点
                    {
                        var entityGroupS = new StatisticsEntity();
                        entityGroupS.ParentID = 0;
                        entityGroupS.ID = id;
                        entityGroupS.Name = group;
                        entityGroupS.Type = EntityTypeEnum.GroupS;
                        list.Add(entityGroupS);
                        dicGroup.Add(group, entityGroupS);
                        id++;
                    }
                    dicGroup[group].Count++;


                    if (!dicBlock.ContainsKey(alg))//统计节点
                    {
                        var entityBlockS = new StatisticsEntity();
                        entityBlockS.ParentID = dicGroup[group].ID;
                        entityBlockS.ID = id;
                        entityBlockS.Name = alg;
                        entityBlockS.Type = EntityTypeEnum.BlockS;
                        list.Add(entityBlockS);
                        dicBlock.Add(alg, entityBlockS);
                        id++;
                    }
                    dicBlock[alg].Count++;


                    var entity = new StatisticsEntity();
                    entity.ParentID = dicBlock[alg].ID;
                    entity.ID = id;
                    entity.Name = string.Format("页号:{0},     算法号:{1}", pageIndex, indexInGroup);
                    entity.PageGuid = item.Key;
                    entity.BlockGuid = guid;
                    entity.Type = EntityTypeEnum.Block;
                    list.Add(entity);
                    id++;

                    entityRoot.Count++;
                }
            }
            return list;

        }

        /// <summary>
        /// 编译,检测算法文档的有效性, 有问题
        /// </summary>
        /// <returns></returns>
        public bool CheckValid()
        {
            PIDCompileErrManager.Instance().ClearError();

            var isValid = true;
            foreach (var doc in DocMap.Values)
            {
                doc.ResetRelation();
                if (!doc.CheckValid())
                    isValid = false;
            }
            if (!CheckOutputVar())
                isValid = false;

            return isValid;
        }
        /// <summary>
        /// 检测输出变量是否有效
        /// </summary>
        /// <returns></returns>
        public bool CheckOutputVar()
        {
            if (DocMap.Values == null)
                return true;
            bool isValid = true;
            IDictionary<string, PIDGeneralBlock> blockMap = new Dictionary<string, PIDGeneralBlock>();
            //分析数据库变量引用关系
            foreach (PIDDocument item in DocMap.Values)
            {
                IEnumerable<PIDGeneralBlock> blocks = item.Blocks;
                foreach (var block in blocks)
                {
                    IList<PIDAlgorithmVar> vars = block.Algorithm.GetAllOutput();
                    foreach (PIDAlgorithmVar var in vars)
                    {
                        if (!var.BindSource.StartsWith(BindSourceToken.PrefixBlock)
                            && !string.IsNullOrEmpty(var.BindSource))
                        {
                            if (blockMap.ContainsKey(var.BindSource))
                            {
                                //生成错误记录
                                PIDCompileErrManager.Instance().AddError(new PIDCompileError
                                {
                                    Identity = block.Identity,
                                    GroupIndex = block.Algorithm.GroupIndex,
                                    IndexInGroup = block.Algorithm.IndexInGroup,
                                    AlgName = block.Algorithm.AlgName,
                                    Description = string.Format("输出管脚{0}引用变量{1}，与算法块{2}引用重复", var.Name,
                                    var.BindSource, blockMap[var.BindSource].Algorithm.GroupIndex.ToString() + "_" + blockMap[var.BindSource].Algorithm.IndexInGroup.ToString())
                                });
                                isValid = false;
                            }
                            else
                            {
                                blockMap.Add(var.BindSource, block);
                            }
                        }
                    }
                }
            }
            return isValid;
        }

        public List<DebugSettingEntity> GetDebugSettingList()
        {
            var list = new List<DebugSettingEntity>();

            var stateList = PIDDataLogic.Instance().GetAllAlgRunState();//数据库运行状态
            var variableList = DOPDataLogic.Instance().Query<Variable>(null, null, 0, 0);//所有变量点

            foreach (var docKey in DocMap)
            {
                var blocks = docKey.Value.Blocks;
                foreach (var block in blocks)
                {
                    if (block is AOBlock || block is DOBlock)
                    {
                        var runState = stateList.FirstOrDefault(v => v.Guid.Equals(block.Algorithm.Identity) && v.CommandType == PIDCommandType.OfflineDebug);

                        var variableNumber = block.Algorithm.GetBindVarNumber();//是ASET,DEST,AI,AO,DI,DO,AM,DM 这八种,子类算法已经重载

                        if (!string.IsNullOrEmpty(variableNumber))
                        {
                            var variable = variableList.FirstOrDefault(v => v.Number.Equals(variableNumber));
                            if (null != variable)
                            {
                                var entity = new DebugSettingEntity();
                                entity.Identity = block.Algorithm.Identity;
                                entity.GroupIndex = block.Algorithm.GroupIndex;
                                entity.IndexInGroup = block.Algorithm.IndexInGroup;
                                entity.Number = variable.Number;
                                entity.Name = variable.Name;
                                if (null != runState && runState.CommandType == PIDCommandType.OfflineDebug)
                                    entity.IsOpenloop = true;
                                else
                                    entity.IsOpenloop = false;

                                list.Add(entity);
                            }
                        }
                    }
                }
            }
            return list;
        }

    }
}
