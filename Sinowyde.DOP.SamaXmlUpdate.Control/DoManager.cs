using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.Zip;

namespace Sinowyde.DOP.SamaXmlUpdate.Control
{
    public class DoManager
    {
        #region  单例数据库访问对象

        private static DoManager instance = null;
        private static object _lock = new object();
        public static DoManager Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new DoManager();
                }
            }

            return instance;
        }
        private DoManager()
        {
        }

        #endregion

        /// <summary>
        /// 缓存路径
        /// </summary>
        private string DocPath = Path.Combine(System.Environment.CurrentDirectory, "TempFiles");

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
                return false;
            }
        }



        public bool Do(string oldFile, string newFile)
        {
            RecreateDocPath();
            //解压
            ZipHelper.Uncompress(oldFile, DocPath);


            foreach (var file in new DirectoryInfo(DocPath).GetFiles("*.xml"))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(file.FullName);

                var root = xmlDocument.DocumentElement;
                if (null == root)
                    continue;

                var blockList = root.SelectNodes("Block");
                if (null == blockList)
                    continue;

                foreach (XmlNode node in blockList)
                {
                    var blockType = node.Attributes["BlockType"].Value;
                    switch (blockType)
                    {
                        case "Sinowyde.DOP.PIDBlock.Nonlinearity.LineBlock":
                            var varParams = JsonConvert.DeserializeObject<IList<PIDAlgorithmVarSpec>>(node.Attributes["VarParams"].Value);
                            foreach (var pidAlgorithmVarSpec in varParams)
                            {
                                var value = pidAlgorithmVarSpec.Value.Replace(" ", "#");
                                pidAlgorithmVarSpec.Value = value;
                            }
                            node.Attributes["VarParams"].Value = JsonConvert.SerializeObject(varParams);
                            break;
                        case "Sinowyde.DOP.PIDBlock.Control.MaexBlock":
                        case "Sinowyde.DOP.PIDBlock.Control.PidexBlock":
                        case "Sinowyde.DOP.PIDBlock.Control.AsetpointBlock":
                        case "Sinowyde.DOP.PIDBlock.Control.DsetpointBlock":
                        case "Sinowyde.DOP.PIDBlock.Choice.MaxBlock":
                        case "Sinowyde.DOP.PIDBlock.Choice.MinBlock":
                        case "Sinowyde.DOP.PIDBlock.Choice.InselBlock":
                        case "Sinowyde.DOP.PIDBlock.Logic.CompBlock":
                        case "Sinowyde.DOP.PIDBlock.Logic.OrBlock":
                        case "Sinowyde.DOP.PIDBlock.Logic.AndBlock":
                        case "Sinowyde.DOP.PIDBlock.Logic.FirstBlock":
                        case "Sinowyde.DOP.PIDBlock.Signal.SquareBlock":
                        case "Sinowyde.DOP.PIDBlock.Nonlinearity.RangeBlock":
                        case "Sinowyde.DOP.PIDBlock.Linearity.DsBlock":
                        case "Sinowyde.DOP.PIDBlock.Linearity.ConstBlock":
                        case "Sinowyde.DOP.PIDBlock.Math.AddBlock":
                        case "Sinowyde.DOP.PIDBlock.Math.DivBlock":
                        case "Sinowyde.DOP.PIDBlock.Math.MultBlock":
                        case "Sinowyde.DOP.PIDBlock.Math.SubBlock":
                            var varInputs = JsonConvert.DeserializeObject<IList<PIDAlgorithmVarSpec>>(node.Attributes["VarInputs"].Value);
                            foreach (var pidAlgorithmVarSpec in varInputs)
                            {
                                pidAlgorithmVarSpec.InputType = PIDVarInputType.Init;//0->1
                            }
                            node.Attributes["VarInputs"].Value = JsonConvert.SerializeObject(varInputs);
                            break;
                    }
                }
                xmlDocument.Save(file.FullName);
            }

            //压缩
            ZipHelper.Compress(newFile, DocPath);

            return true;
        }

    }
}
