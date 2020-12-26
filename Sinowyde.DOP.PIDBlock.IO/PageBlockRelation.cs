using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock.IO
{
    /// <summary>
    /// 页间关系
    /// </summary>
    public class PageBlockRelation
    {
        #region 单例

        /// <summary>
        /// 单例数据库访问对象
        /// </summary>
        private static PageBlockRelation instance = null;

        private static object _lock = new object();

        public static PageBlockRelation Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new PageBlockRelation();
                }
            }


            return instance;
        }

        private PageBlockRelation()
        {
            this.PAOBlocks = new List<PAOBlock>();
            this.PAIBlocks = new List<PAIBlock>();
            this.PDOBlocks = new List<PDOBlock>();
            this.PDIBlocks = new List<PDIBlock>();
        }

        #endregion

        /// <summary>
        /// 页间AO块
        /// </summary>
        public IList<PAOBlock> PAOBlocks
        {
            get;
            private set;
        }

        /// <summary>
        /// 页间AI块
        /// </summary>
        public IList<PAIBlock> PAIBlocks
        {
            get;
            private set;
        }

        /// <summary>
        /// 页间DO块
        /// </summary>
        public IList<PDOBlock> PDOBlocks
        {
            get;
            private set;
        }

        /// <summary>
        /// 页间DI块
        /// </summary>
        public IList<PDIBlock> PDIBlocks
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取与输出相关的输入块
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public IList<PAIBlock> GetRelatedPAI(PAOBlock aob)
        {
            return GetRelatedPBI<PAIBlock, PAOBlock>(aob, this.PAIBlocks);
        }

        /// <summary>
        /// 获取与输出相关的输入块
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public IList<PDIBlock> GetRelatedPDI(PDOBlock dob)
        {
            return GetRelatedPBI<PDIBlock, PDOBlock>(dob, this.PDIBlocks);
        }

        private IList<TI> GetRelatedPBI<TI, TO>(TO bob, IList<TI> bibs)
            where TI : PIDGeneralBlock
            where TO : PIDGeneralBlock
        {
            IList<TI> blocks = new List<TI>();
            foreach (TI bib in bibs)
            {
                var list = bib.Algorithm.GetRelatedAlgs();
                if (null == list || list.Count == 0)
                    continue;

                string id = list[0];
                if (string.IsNullOrEmpty(id))
                    continue;
                else
                {
                    if (id == bob.Identity)
                        blocks.Add(bib);
                }
            }
            return blocks;
        }

        /// <summary>
        /// pdi 香瓜输出块
        /// </summary>
        /// <param name="dib"></param>
        /// <returns></returns>
        public PDOBlock GetRelatedPDO(PDIBlock dib)
        {
            return GetRelatedPBO<PDIBlock, PDOBlock>(dib, this.PDOBlocks);
        }

        /// <summary>
        /// pAi 香瓜输出块
        /// </summary>
        /// <param name="dib"></param>
        /// <returns></returns>
        public PAOBlock GetRelatedPAO(PAIBlock aib)
        {
            return GetRelatedPBO<PAIBlock, PAOBlock>(aib, this.PAOBlocks);
        }


        private TO GetRelatedPBO<TI, TO>(TI bib, IList<TO> bobs)
            where TI : PIDGeneralBlock
            where TO : PIDGeneralBlock
        {
            var list = bib.Algorithm.GetRelatedAlgs();
            if (null == list || list.Count == 0)
                return null;

            string id = list[0];
            if (string.IsNullOrEmpty(id))
                return null;
            foreach (TO bob in bobs)
            {
                if (id == bob.Identity)
                    return bob;
            }
            return null;
        }

        public void RemoveRealtedPB(GoDocument doc)
        {
             if (doc == null)
                return;

            ReomvePIB<PDIBlock>(doc, this.PDIBlocks);
            ReomvePIB<PAIBlock>(doc, this.PAIBlocks);
            ReomvePOB<PDOBlock, PDIBlock>(doc, this.PDOBlocks, this.PDIBlocks);
            ReomvePOB<PAOBlock, PAIBlock>(doc, this.PAOBlocks, this.PAIBlocks);
        }

        private void ReomvePIB<T>(GoDocument doc, IList<T> blocks)
            where T : PIDGeneralBlock
        {
            for (int i = blocks.Count - 1; i >= 0; i--)
            {
                if (blocks[i].IsInDocument && blocks[i].Document == doc)
                {
                    ReomvePIB<T>(blocks[i]);
                }
            }
        }

        private void ReomvePIB<T>(T block)
            where T : PIDGeneralBlock
        {
            if (block is PAIBlock)
            {
                this.PAIBlocks.Remove(block as PAIBlock);
                //重绘输出
                PAOBlock bob = GetRelatedPAO(block as PAIBlock);
                if (bob != null)
                    bob.DrawBackground();
            }

            if (block is PDIBlock)
            {
                this.PDIBlocks.Remove(block as PDIBlock);
                //重绘输出
                PDOBlock bob = GetRelatedPDO(block as PDIBlock);
                if (bob != null)
                    bob.DrawBackground();
            }
        }

        private void ReomvePOB<TO, TI>(GoDocument doc, IList<TO> bobs, IList<TI> bibs)
            where TO : PIDGeneralBlock
            where TI : PIDGeneralBlock
        {
            for (int i = bobs.Count - 1; i >= 0; i--)
            {
                if (bobs[i].IsInDocument && bobs[i].Document == doc)
                {
                    EmptyPIB<TI>(bobs[i].Identity, bibs);
                    bobs.Remove(bobs[i]);
                }
            }
        }

        private void EmptyPIB<TI>(string id, IList<TI> bibs)
            where TI : PIDGeneralBlock
        {
            foreach (TI bib in bibs)
            {
                var list = bib.Algorithm.GetRelatedAlgs();
                if (null == list || list.Count == 0)
                    continue;

                if (list[0] == id)
                {
                    bib.Algorithm.UnBindParam(bib.Algorithm.GetAllInput()[0].Name);
                    bib.DrawBackground();
                }
            }
        }

        public void AddRealtedPB(GoDocument doc)
        {
            if (doc == null)
                return;

            foreach (GoObject block in doc.DefaultLayer.GetEnumerator())
            {
                if (block is PIDGeneralBlock)
                    AddBlock(block as PIDGeneralBlock);
            }
        }

        public void Clear()
        {
            this.PDIBlocks.Clear();
            this.PDOBlocks.Clear();
            this.PAIBlocks.Clear();
            this.PAOBlocks.Clear();
        }

        public void AddBlock(PIDGeneralBlock block)
        {
            if (block is PAIBlock)
                this.PAIBlocks.Add(block as PAIBlock);
            else if (block is PAOBlock)
                this.PAOBlocks.Add(block as PAOBlock);
            else if (block is PDIBlock)
                this.PDIBlocks.Add(block as PDIBlock);
            else if (block is PDOBlock)
                this.PDOBlocks.Add(block as PDOBlock);
            else { }
        }

        public void RemoveBlock(PIDGeneralBlock block)
        {
            if (block is PAIBlock)
                this.ReomvePIB<PAIBlock>(block as PAIBlock);
            else if (block is PAOBlock)
            {
                EmptyPIB<PAIBlock>(block.Identity, this.PAIBlocks);
                this.PAOBlocks.Remove(block as PAOBlock);
            }
            else if (block is PDIBlock)
                this.ReomvePIB<PDIBlock>(block as PDIBlock);
            else if (block is PDOBlock)
            {
                EmptyPIB<PDIBlock>(block.Identity, this.PDIBlocks);
                this.PDOBlocks.Remove(block as PDOBlock);
            }
            else { }
        }

        /// <summary>
        /// 刷新显示
        /// </summary>
        public void Refresh()
        {
            foreach (var paiBlock in PageBlockRelation.Instance().PAIBlocks)
            {
                paiBlock.DrawBackground();
            }
            foreach (var paoBlock in PageBlockRelation.Instance().PAOBlocks)
            {
                paoBlock.DrawBackground();
            }
            foreach (var pdiBlocks in PageBlockRelation.Instance().PDIBlocks)
            {
                pdiBlocks.DrawBackground();
            }
            foreach (var pdoBlock in PageBlockRelation.Instance().PDOBlocks)
            {
                pdoBlock.DrawBackground();
            }
        }
    }
}
