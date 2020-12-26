using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Sinowyde.Util;
using Sinowyde.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDBlock.IO
{
    public partial class CtrlParamPAI : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamPAI()
        {
            InitializeComponent();

            this.cmb_Groups.Properties.TextEditStyle = TextEditStyles.Standard;
            this.cmb_IndexInGroup.Properties.TextEditStyle = TextEditStyles.Standard;
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public IList<PAOBlock> PaoBlockList = null;

        public void LoadParam()
        {
            cmb_Groups.Properties.Items.Clear();
            cmb_IndexInGroup.Properties.Items.Clear();
            PaoBlockList = PageBlockRelation.Instance().PAOBlocks;
            if (null == PaoBlockList || PaoBlockList.Count == 0)
                return;

            List<string> listGroup = PaoBlockList.Select(paoBlock => paoBlock.Algorithm.GroupIndex).Distinct().OrderBy(v => ConvertUtil.ConvertToInt(v)).ToList();
            cmb_Groups.Properties.Items.AddRange(listGroup);

            var pAIBlock = Block as PAIBlock;
            var paoBlockOld = PageBlockRelation.Instance().GetRelatedPAO(pAIBlock);
            if (null != paoBlockOld)
            {
                var generalBlock = paoBlockOld as PIDGeneralBlock;
                this.cmb_Groups.SelectedItem = generalBlock.Algorithm.GroupIndex;
                this.cmb_IndexInGroup.SelectedItem = generalBlock.Algorithm.IndexInGroup;
            }

            this.cmb_Groups.Enabled = !PIDGeneralBlock.IsRunning;
            this.cmb_IndexInGroup.Enabled = !PIDGeneralBlock.IsRunning;
        }

        public bool SaveParam()
        {
            if (null == PaoBlockList || null == cmb_Groups.SelectedItem || null == cmb_IndexInGroup.SelectedItem)
                return false;

            var groupIndex = cmb_Groups.SelectedItem.ToString();
            var indexInGroup = cmb_IndexInGroup.SelectedItem.ToString();

            var paoBlockFrom = PaoBlockList.FirstOrDefault(v => v.Algorithm.GroupIndex.Equals(groupIndex) && v.Algorithm.IndexInGroup.Equals(indexInGroup));
            if (null != paoBlockFrom)
            {
                var sourceVar = BindSourceToken.GetName(paoBlockFrom.Identity, PIDPAO.Result);//pao 是From参考GoViewEx

                var oldGuid = string.Empty;
                if (!string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPAI.InputAI)))
                    oldGuid = Algorithm.GetBindParam(PIDPAI.InputAI).Split('.')[1];

                Algorithm.UnBindParam(PIDPAI.InputAI);//解绑

                if (!string.IsNullOrEmpty(oldGuid))
                {
                    var oldPaoBlock = PageBlockRelation.Instance().PAOBlocks.FirstOrDefault(v => v.Algorithm.Identity.Equals(oldGuid));
                    if (null != oldPaoBlock)
                        oldPaoBlock.DrawBackground();//刷新原来连接的
                }

                Algorithm.BindParam(PIDPAI.InputAI, sourceVar);//自己是To 
                ((FrmPIDBlockParam)this.ParentForm).AgainDraw = true;//刷新自己
                paoBlockFrom.DrawBackground();//刷新新连接的
            }
            return true;
        }

        public UserControl GetParamCtrl() { return this; }

        private void cmb_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == PaoBlockList || null == this.cmb_Groups.SelectedItem)
                return;

            string selectItem = this.cmb_Groups.SelectedItem.ToString();
            var indexInGroupList = PaoBlockList.Where(v => v.Algorithm.GroupIndex.Equals(selectItem))
                                 .OrderBy(v => ConvertUtil.ConvertToInt(v.Algorithm.IndexInGroup))
                                 .Select(q => q.Algorithm.IndexInGroup)
                                 .ToList();

            this.cmb_IndexInGroup.Properties.Items.Clear();
            this.cmb_IndexInGroup.Properties.Items.AddRange(indexInGroupList);
        }
    }
}
