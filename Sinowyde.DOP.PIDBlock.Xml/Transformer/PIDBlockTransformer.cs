using Northwoods.Go.Xml;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock.Xml.Transformer
{
    /// <summary>
    /// block 序列化转换
    /// </summary>
    public class PIDBlockTransformer : GoXmlTransformer
    {
        public PIDBlockTransformer()
        {
            this.ElementName = "Block";
            this.TransformerType = typeof(PIDGeneralBlock);
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <returns></returns>
        public override object Allocate()
        {
            string blockType = StringAttr("BlockType", "?");
            string blockAssembly = StringAttr("BlockAssembly", "?");
            ObjectHandle handle = System.Activator.CreateInstance(blockAssembly, blockType);
            return handle.Unwrap();
        }

        /// <summary>
        /// 生成xml文件节点
        /// </summary>
        /// <param name="obj"></param>
        public override void GenerateAttributes(Object obj)
        {
            PIDGeneralBlock block = obj as PIDGeneralBlock;
            base.GenerateAttributes(block);
            WriteAttrVal("BlockType", block.GetType().FullName);
            WriteAttrVal("BlockAssembly", block.GetType().Assembly.FullName);
            WriteAttrVal("Identity", block.Identity);
            WriteAttrVal("PartID", block.PartID);
            WriteAttrVal("LeftPortLabelsInside", block.LeftPortLabelsInside);
            WriteAttrVal("RightPortLabelsInside", block.RightPortLabelsInside);
            WriteAttrVal("Location", block.Location);
            WriteAttrVal("IconName", block.IconName);
            WriteAttrVal("GroupIndex", block.Algorithm.GroupIndex);
            WriteAttrVal("IndexInGroup", block.Algorithm.IndexInGroup);
            WriteAttrVal("AlgAssembly", block.Algorithm.AlgAssembly);
            WriteAttrVal("AlgType", block.Algorithm.AlgType);
            WriteAttrVal("VarParams", block.Algorithm.VarParams);
            WriteAttrVal("VarInputs", block.Algorithm.VarInputs);
            WriteAttrVal("VarOutputs", block.Algorithm.VarOutputs);

            IList<int> partIDs = new List<int>();
            for(int index=0; index<block.LeftPortsCount; index++)
            {
                partIDs.Add(block.GetLeftPort(index).PartID);
            }
            WriteAttrVal("LeftPorts", partIDs.ToArray<int>());

            partIDs.Clear();
            for (int index = 0; index < block.RightPortsCount; index++)
            {
                partIDs.Add(block.GetRightPort(index).PartID);
            }
            WriteAttrVal("RightPorts", partIDs.ToArray<int>());
        }
        /// <summary>
        /// 设置算法属性
        /// </summary>
        /// <param name="obj"></param>        
        public override void ConsumeAttributes(object obj)
        {
            base.ConsumeAttributes(obj);
            PIDGeneralBlock block = obj as PIDGeneralBlock;
            block.Identity = StringAttr("Identity", "?");
            block.PartID = Int32Attr("PartID", 0);
            block.LeftPortLabelsInside = BooleanAttr("LeftPortLabelsInside", true);
            block.RightPortLabelsInside = BooleanAttr("RightPortLabelsInside", true);
            block.IconName = StringAttr("IconName", "?");
            block.Algorithm.GroupIndex = StringAttr("GroupIndex", "?");
            block.Algorithm.IndexInGroup = StringAttr("IndexInGroup", "?");
            block.Algorithm.VarParams = StringAttr("VarParams", "?");
            block.Algorithm.VarInputs = StringAttr("VarInputs", "?");
            block.Algorithm.VarOutputs = StringAttr("VarOutputs", "?");
            block.Location = PointFAttr("Location", new PointF(100, 100));
            int[] partIDs = Int32ArrayAttr("LeftPorts", null);
            if (partIDs != null)
            {
                for (int index = 0; index < partIDs.Length; index++)
                {
                    block.GetLeftPort(index).PartID = partIDs[index];
                }
            }
            partIDs = Int32ArrayAttr("RightPorts", null);
            if (partIDs != null)
            {
                for (int index = 0; index < partIDs.Length; index++)
                {
                    block.GetRightPort(index).PartID = partIDs[index];
                }
            }
        }
    }
}
