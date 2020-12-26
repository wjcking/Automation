using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;

namespace Sinowyde.DOP.PIDBlock.GoObjectEx
{
    [Serializable]
    public class BlockText : GoText
    {
        public BlockText()
        {
            this.Text = "Text";
            Editable = true;
        }

        private bool isNeedSave = false;
        public bool IsNeedSave
        {
            get
            {
                return isNeedSave;
            }
            set
            {
                isNeedSave = value;
            }
        }
        public override System.Drawing.PointF Location
        {
            get
            {
                return base.Location;
            }
            set
            {
                base.Location = value;
                IsNeedSave = true;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (!value.Equals("Text"))
                    IsNeedSave = true;
            }
        }
    }
}
