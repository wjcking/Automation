using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 页间引用数字量输入算法
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("页间引用数字量输入算法", "输入输出", 1, null, "io_pagedi_icon")]
    public class PDIBlockTools : BaseTool<PDIBlock> { }
}
