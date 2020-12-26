using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 页间引用数字量输出算法
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("页间引用数字量输出算法", "输入输出", 1, null, "io_pagedo_icon")]
    public class PDOBlockTools : BaseTool<PDOBlock> { }
}

