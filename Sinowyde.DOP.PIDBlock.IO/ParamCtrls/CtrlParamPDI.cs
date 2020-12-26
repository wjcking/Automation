using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Sinowyde.Util;
using Sinowyde.DataModel;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Controls;

namespace Sinowyde.DOP.PIDBlock.IO
{
    public partial class CtrlParamPDI : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamPDI()
        {
            InitializeComponent();

            this.cmb_Groups.Properties.TextEditStyle = TextEditStyles.Standard;
            this.cmb_IndexInGroup.Properties.TextEditStyle = TextEditStyles.Standard;
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public IList<PDOBlock> PdoBlockList = null;

        public void LoadParam()
        {
            cmb_Groups.Properties.Items.Clear();
            cmb_IndexInGroup.Properties.Items.Clear();
            PdoBlockList = PageBlockRelation.Instance().PDOBlocks;
            if (null == PdoBlockList || PdoBlockList.Count == 0)
                return;

            List<string> listGroup = PdoBlockList.Select(pdoBlock => pdoBlock.Algorithm.GroupIndex).Distinct().OrderBy(v => ConvertUtil.ConvertToInt(v)).ToList();
            cmb_Groups.Properties.Items.AddRange(listGroup);

            var pDIBlock = Block as PDIBlock;
            var pdoBlockOld = PageBlockRelation.Instance().GetRelatedPDO(pDIBlock);
            if (null != pdoBlockOld)
            {
                var generalBlock = pdoBlockOld as PIDGeneralBlock;
                this.cmb_Groups.SelectedItem = generalBlock.Algorithm.GroupIndex;
                this.cmb_IndexInGroup.SelectedItem = generalBlock.Algorithm.IndexInGroup;
            }

            this.cmb_Groups.Enabled = !PIDGeneralBlock.IsRunning;
            this.cmb_IndexInGroup.Enabled = !PIDGeneralBlock.IsRunning;
        }

        public bool SaveParam()
        {
            if (null == PdoBlockList || null == cmb_Groups.SelectedItem || null == cmb_IndexInGroup.SelectedItem)
                return false;

            var groupIndex = cmb_Groups.SelectedItem.ToString();
            var indexInGroup = cmb_IndexInGroup.SelectedItem.ToString();

            var pdoBlockFrom = PdoBlockList.FirstOrDefault(v => v.Algorithm.GroupIndex.Equals(groupIndex) && v.Algorithm.IndexInGroup.Equals(indexInGroup));
            if (null != pdoBlockFrom)
            {
                var sourceVar = BindSourceToken.GetName(pdoBlockFrom.Identity, PIDPDO.Result);//pao 是From参考GoViewEx

                var oldGuid = string.Empty;
                if (!string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPDI.InputDI)))
                    oldGuid = Algorithm.GetBindParam(PIDPDI.InputDI).Split('.')[1];

                Algorithm.UnBindParam(PIDPDI.InputDI);//解绑

                if (!string.IsNullOrEmpty(oldGuid))
                {
                    var oldPdoBlock = PageBlockRelation.Instance().PDOBlocks.FirstOrDefault(v => v.Algorithm.Identity.Equals(oldGuid));
                    if (null != oldPdoBlock)
                        oldPdoBlock.DrawBackground();//刷新原来连接的
                }

                Algorithm.BindParam(PIDPDI.InputDI, sourceVar);//自己是To 
                ((FrmPIDBlockParam)this.ParentForm).AgainDraw = true;//刷新自己
                pdoBlockFrom.DrawBackground();//刷新新连接的
            }
            return true;
        }

        public UserControl GetParamCtrl() { return this; }

        private void cmb_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == PdoBlockList || null == this.cmb_Groups.SelectedItem)
                return;

            string selectItem = this.cmb_Groups.SelectedItem.ToString();
            var indexInGroupList = PdoBlockList.Where(v => v.Algorithm.GroupIndex.Equals(selectItem))
                                  .OrderBy(v => ConvertUtil.ConvertToInt(v.Algorithm.IndexInGroup))
                                 .Select(q => q.Algorithm.IndexInGroup)
                                 .ToList();

            this.cmb_IndexInGroup.Properties.Items.Clear();
            this.cmb_IndexInGroup.Properties.Items.AddRange(indexInGroupList);

        }
    }
}
