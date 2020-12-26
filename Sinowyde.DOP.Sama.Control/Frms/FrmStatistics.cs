using System;
using DevExpress.XtraTreeList;
using Sinowyde.DOP.PIDBlock.Xml;
using Sinowyde.DOP.PIDBlock.Xml.Entitys;
using DevExpress.XtraEditors;

namespace Sinowyde.DOP.Sama.Control.Frms
{
    public partial class FrmStatistics : XtraForm
    {
        public Action<string, string> SelectPageAction;

        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            InitUi();
            LoadData();
        }


        private void InitUi()
        {
            this.treeList.AfterFocusNode += treeList_AfterFocusNode;
        }

        private void treeList_AfterFocusNode(object sender, NodeEventArgs e)
        {
            var entity = this.treeList.GetDataRecordByNode(e.Node) as StatisticsEntity;
            if (null != entity && entity.Type == EntityTypeEnum.Block)
            {
                if (null != SelectPageAction)
                    SelectPageAction(entity.PageGuid, entity.BlockGuid);
            }
        }

        private void LoadData()
        {
            this.treeList.Nodes.Clear();
            this.treeList.DataSource = PIDDocManager.Instance().GetAllBlocks();
            treeList.ExpandToLevel(0);
        }
        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
