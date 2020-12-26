using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Sinowyde.ConsoleApplication
{
    public static class DevexpressUtil
    {
        public static void ShowExceptionDialog(Exception ex)
        {
            XtraMessageBox.Show("出现异常!请查看Log");
        }


        public class ChLocalizer : Localizer
        {
            public override string GetLocalizedString(StringId id)
            {
                switch (id)
                {
                    case StringId.XtraMessageBoxOkButtonText:
                        return "确定";
                    case StringId.XtraMessageBoxCancelButtonText:
                        return "取消";
                    case StringId.XtraMessageBoxYesButtonText:
                        return "是";
                    case StringId.XtraMessageBoxNoButtonText:
                        return "否";
                    default:
                        return base.GetLocalizedString(id);
                }
            }
        }
    }
}
