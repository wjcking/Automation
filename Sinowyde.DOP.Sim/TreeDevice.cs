using Sinowyde.DOP.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinowyde.DOP.Sim
{
    public partial class TreeDevice : TreeView
    {
        public IList<IOUnit> IOUnit { get; private set; }
        public IList<IOChannel> IOChannel { get; private set; }
        //   public IList<IOChannel> IOChannel { get; private set; } 
        public TreeDevice()
        {
            InitializeComponent();
        }

        public TreeDevice(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void BindData()
        {
            IOUnit = Sinowyde.DOP.DataLogic.DOPDataLogic.Instance().GetAllBy<IOUnit>();
            IOChannel = Sinowyde.DOP.DataLogic.DOPDataLogic.Instance().GetAllBy<IOChannel>();
            TreeNode tn = new TreeNode();
            tn.Text = "所有通道";

            foreach (var c in IOChannel)
            {
                TreeNode cNode = new TreeNode(c.Name);

                foreach (var u in IOUnit)
                {
                    if (u.ChannelID == c.ID)
                    {
                        TreeNode uNode = new TreeNode(u.Name);
                        uNode.Tag = u;
                        cNode.Nodes.Add(uNode);
                    }
                }
                tn.Nodes.Add(cNode);
            }
            Nodes.Add(tn);
            tn.ExpandAll();
        }


    }
}
