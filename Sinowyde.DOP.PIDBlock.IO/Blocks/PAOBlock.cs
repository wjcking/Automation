using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Northwoods.Go;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace Sinowyde.DOP.PIDBlock.IO
{
    [Serializable]
    public class PAOBlock : IOBlock
    {
        public PAOBlock()
            : base(new PIDPAO())
        {
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamPAO();
        }

        private string GetDataSource()
        {
            var str = string.Empty;
            var paiList = PageBlockRelation.Instance().GetRelatedPAI(this);
            foreach (var pai in paiList)
            {
                str += string.Format("{0},{1};", pai.Algorithm.GroupIndex, pai.Algorithm.IndexInGroup);
            }
            return str;
        }

        public override void DrawBackground()
        {
            this.GetRightPort(0).Visible = false;

            float fixedWidth = 40f;
            float fixedHeight = 40f;

            string dataSource = GetDataSource();// "1,2;3,4;5,6;7,8;";

            string[] linkCount = dataSource.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            GoGroup group = new GoGroup();
            group.Size = new SizeF(fixedWidth * (linkCount.Length + 1), fixedHeight);

            GoDrawing shape = new GoDrawing(GoFigure.Circle);
            shape.Size = new SizeF(fixedWidth, fixedHeight);
            shape.Selectable = false;

            group.Add(shape);

            for (int i = 0; i < linkCount.Length; i++)
            {
                GoDrawing childShape = new GoDrawing(GoFigure.Circle);
                childShape.Size = new SizeF(fixedWidth, fixedHeight);
                childShape.Selectable = false;
                float x = fixedWidth / 2 + fixedWidth * (i + 1);
                childShape.Center = new PointF(x, group.Center.Y);

                GoText topText = new GoText();
                topText.Text = linkCount[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                topText.Selectable = false;
                topText.Center = new PointF(childShape.Center.X, childShape.Center.Y - topText.Height / 2);
                GoText bottomText = new GoText();
                bottomText.Text = linkCount[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
                bottomText.Selectable = false;
                bottomText.Center = new PointF(childShape.Center.X, childShape.Center.Y + topText.Height / 2);

                group.Add(childShape);
                group.Add(topText);
                group.Add(bottomText);
            }

            this.Icon = group;
        }

        public override GoContextMenu GetContextMenu(GoView view)
        {
            var contextMenu = base.GetContextMenu(view);
            contextMenu.MenuItems.Add(new MenuItem("跳转到引用", new EventHandler(GotoUsages)) { Enabled = true });
            return contextMenu;
        }

        /// <summary>
        /// 跳转到引用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoUsages(object sender, EventArgs e)
        {
            if (null != LocateAction)
            {
                var list = PageBlockRelation.Instance().GetRelatedPAI(this);
                if (null == list || list.Count == 0)
                    XtraMessageBox.Show("没有引用!");
                else if (list.Count == 1)//直接跳转
                    LocateAction(list[0].Algorithm.GroupIndex, list[0].Algorithm.IndexInGroup);
                else
                {
                    var listStr = list.Select(item => string.Format("{0}-{1}", item.Algorithm.GroupIndex, item.Algorithm.IndexInGroup)).ToList();
                    var frmGotoUsages = new FrmGotoUsages(listStr);
                    if (frmGotoUsages.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(frmGotoUsages.StrLocateInfo))
                    {
                        var str = frmGotoUsages.StrLocateInfo.Split('-');
                        LocateAction(str[0], str[1]);
                    }
                }
            }
        }

        public override void SetOutputText(string key, double value)
        {
            return;
        }

        public override Dictionary<string, GoText> CreateOutputText()
        {
            return new Dictionary<string, GoText>();
        }

        public override void ClearOutputText()
        {
            return;
        }

        public override bool CheckSelfValid()
        {
            return this.Algorithm.CheckSelfValid();
        }
    }
}