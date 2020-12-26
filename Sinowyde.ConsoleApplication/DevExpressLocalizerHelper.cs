using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Controls;

namespace Sinowyde.ConsoleApplication
{
    /// <summary>  
    /// 汉化简化辅助类  
    /// </summary>  
    public class DevExpressLocalizerHelper
    {
        public static void SetSimpleChinese()
        {
            Localizer.Active = new XtraEditorLocalizerChs();
        }
    }

    public class XtraEditorLocalizerChs : Localizer
    {

        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                case StringId.XtraMessageBoxOkButtonText: return "确定";
                case StringId.XtraMessageBoxCancelButtonText: return "取消";
                case StringId.XtraMessageBoxYesButtonText: return "是";
                case StringId.XtraMessageBoxNoButtonText: return "否";
            }
            return base.GetLocalizedString(id);
        }
    }

}
