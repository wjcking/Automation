using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// �����ֶ�վ�㷨�飨DMS��Digital Man Stationb54c9
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����ֶ�վ�㷨��", "���ƹ���", 6, null, "math_dms_icon")]
    public class DmsBlockTool : BaseTool<DmsBlock>
    {
         
    }
}
