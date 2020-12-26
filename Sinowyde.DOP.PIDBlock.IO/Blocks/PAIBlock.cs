using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Northwoods.Go;
using System.Drawing;
using System;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDBlock.IO
{
    [Serializable]
    public class PAIBlock : PIDGeneralBlock
    {
        public PAIBlock()
            : base(new PIDPAI())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamPAI();
        }

        public override void DrawBackground()
        {
            this.GetLeftPort(0).Visible = false;
            this.GetLeftPort(0).Label.Text = string.Empty;

            this.GetRightPort(0).Visible = true;
            this.GetRightPort(0).Label.Text = string.Empty;

            var paoBlock = PageBlockRelation.Instance().GetRelatedPAO(this);
            int groupIndex = 0;
            int indexInGroup = 0;
            if (null != paoBlock)
            {
                groupIndex = ConvertUtil.ConvertToInt(paoBlock.Algorithm.GroupIndex);
                indexInGroup = ConvertUtil.ConvertToInt(paoBlock.Algorithm.IndexInGroup);
            }
            GoDrawing drawing = new GoDrawing(GoFigure.Circle);
            DrawBlockUtil.Draw(this, drawing, 60f, 60f);
            GoText topText = ((GoText)((GoGroup)this.Icon).FindChild("topText"));
            //填充数据
            topText.Text = groupIndex.ToString();
            GoText bottomText = ((GoText)((GoGroup)this.Icon).FindChild("bottomText"));
            //填充数据
            bottomText.Text = indexInGroup.ToString();
            //重新设置中心位置
            GoDrawing line = ((GoGroup)Icon).FindChild("line") as GoDrawing;
            topText.Center = new PointF(line.Center.X, line.Center.Y - 10);
            bottomText.Center = new PointF(line.Center.X, line.Center.Y + 10);
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
                var pAOBlock = PageBlockRelation.Instance().GetRelatedPAO(this);
                if (null == pAOBlock)
                    XtraMessageBox.Show("没有引用!");
                else
                    LocateAction(pAOBlock.Algorithm.GroupIndex, pAOBlock.Algorithm.IndexInGroup);
            }
        }
    }
}
