using Newtonsoft.Json;
using Northwoods.Go;
using Northwoods.Go.Instruments;
using Sinowyde.DOP.DataModel;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinowyde.DOP.GraphicElement.Base
{
    [Serializable]
    public class DOPGraphElement : GoGroup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DOPGraphElement()
        {
            this.GraphActionMap = new Dictionary<string, GraphActionDefine>();
        }

        /// <summary>
        /// 动作脚本
        /// </summary>
        public IDictionary<string, GraphActionDefine> GraphActionMap
        {
            get;
            private set;
        }
        /// <summary>
        /// 转换为json串
        /// </summary>
        /// <returns></returns>
        public String ActionToJson()
        {
            return JsonConvert.SerializeObject(GraphActionMap);
        }
        /// <summary>
        /// 解析json串
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public void ActionFromJson(string json)
        {
            try
            {
                GraphActionMap = JsonConvert.DeserializeObject<IDictionary<string, GraphActionDefine>>(json);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="script"></param>
        /// <param name="action"></param>
        public void RegisterAction(ExecGraphAction action, GraphActionDefine arg)
        {
            if (GraphActionMap.ContainsKey(arg.ID))
            {
                GraphActionMap.Remove(arg.ID);
            }
            arg.GraphAction = action;
            GraphActionMap.Add(arg.ID, arg);
        }
        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="action"></param>
        public void UnRegisterAction(string actionID)
        {
            if (GraphActionMap.ContainsKey(actionID))
            {
                GraphActionMap.Remove(actionID);
            }
        }
        /// <summary>
        /// 启动或者禁用事件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="enabled"></param>
        public void EnableAction(string actionID, bool enabled)
        {
            if (GraphActionMap.ContainsKey(actionID))
            {
                GraphActionMap[actionID].Enabled = enabled;
            }
        }

        /// <summary>
        /// 刷新显示
        /// </summary>
        public virtual void Refresh()
        {
            if (!GraphRunTime.Instance().IsRun())
                return;

            //动作刷新
            foreach (GraphActionDefine action in this.GraphActionMap.Values)
            {
                action.Execute();
            }

            //其它刷新
        }

        /// <summary>
        /// 重载pick方法，直接返回顶层元素对象
        /// </summary>
        /// <param name="p"></param>
        /// <param name="selectableOnly"></param>
        /// <returns></returns>
        public override GoObject Pick(PointF p, bool selectableOnly)
        {
            if (!this.CanView())
            {
                return null;
            }
            //直接返回顶层对象
            foreach (GoObject current in this.Backwards)
            {
                GoObject goObject = current.Pick(p, selectableOnly);
                if (goObject != null)
                {
                    return goObject.TopLevelObject;
                }
            }
            if (this.PickableBackground)
            {
                if (!selectableOnly)
                {
                    return this;
                }
                if (this.CanSelect())
                {
                    return this;
                }
                for (GoObject parent = base.Parent; parent != null; parent = parent.Parent)
                {
                    if (parent.CanSelect())
                    {
                        return parent;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 双击显示参数界面
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public override bool OnDoubleClick(GoInputEventArgs evt, GoView view)
        {
            if (GraphRunTime.Instance().IsEdit())
            {
                if (evt != null && evt.Buttons == MouseButtons.Left && evt.DoubleClick)
                {
                    this.InitCtrlParam();
                    ShowParamDialog();
                }
            }
            return base.OnDoubleClick(evt, view);
        }

        /// <summary>
        /// 参数设置界面
        /// </summary>
        [NonSerialized]
        protected ICtrlParamBase ctrlParam = null;
        /// <summary>
        /// 初始化控件
        /// </summary>
        protected void InitCtrlParam()
        {
            this.ctrlParam = CreateCtrlParam();
            if (this.ctrlParam != null)
            {
                this.paramFrm = new FrmGraphParam();
                this.paramFrm.SetCtrlParam(this.ctrlParam, this.ctrlParam.Name);
            }
        }
        /// <summary>
        /// 创建参数控件
        /// </summary>
        /// <returns></returns>
        protected virtual ICtrlParamBase CreateCtrlParam()
        {
            return null;
        }
        /// <summary>
        /// 参数界面
        /// </summary>
        [NonSerialized]
        private FrmGraphParam paramFrm = null;
        /// <summary>
        /// 显示参数界面
        /// </summary>
        public void ShowParamDialog()
        {
            if (this.paramFrm != null)
                paramFrm.ShowDialog();
        }

        #region //菜单区

        public static Action<string> CommandAction;
        public override GoContextMenu GetContextMenu(GoView view)
        {
            if (GraphRunTime.Instance().IsEdit())
            {
                var goContextMenu = new GoContextMenu(view);
                goContextMenu.MenuItems.Add(new MenuItem("置顶", new EventHandler(BringToFront)));
                goContextMenu.MenuItems.Add(new MenuItem("置底", new EventHandler(SendToBack)));
                goContextMenu.MenuItems.Add(new MenuItem("剪切", new EventHandler(CutObject)));
                goContextMenu.MenuItems.Add(new MenuItem("复制", new EventHandler(CopyObject)));
                goContextMenu.MenuItems.Add(new MenuItem("粘贴", new EventHandler(PasteObject)));
                goContextMenu.MenuItems.Add(new MenuItem("删除", new EventHandler(DeleteObject)));
                //if (view.Selection.Primary.GetType().Name.Equals("DOPImage"))
                //{
                //    goContextMenu.MenuItems.Add(new MenuItem("图片原始大小", new EventHandler(ImageAutoResizes)));
                //}
                return goContextMenu;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 恢复图片原始大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageAutoResizes(object sender, EventArgs e)
        {
            CommandAction("AutoResizes");
        }

        /// <summary>
        /// 图形置底
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendToBack(object sender, EventArgs e)
        {
            CommandAction("SendToBack");
        }
        /// <summary>
        /// 图形置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BringToFront(object sender, EventArgs e)
        {
            CommandAction("BringToFront");
        }
        /// <summary>
        /// 剪切对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutObject(object sender, EventArgs e)
        {
            CommandAction("CutObject");
        }
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyObject(object sender, EventArgs e)
        {
            CommandAction("CopyObject");
        }
        /// <summary>
        /// 粘贴对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteObject(object sender, EventArgs e)
        {
            CommandAction("PasteObject");
        }
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteObject(object sender, EventArgs e)
        {
            CommandAction("DeleteObject");
        }
        #endregion

        #region //动作区
        /// <summary>
        /// 移动动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        public void MoveAction(Object sender, GraphActionDefine arg)
        {
            GraphMoveActionDefine moveArg = arg as GraphMoveActionDefine;
            if (moveArg.Direction == MoveDirection.UnKnown)
            {
                return;
            }
            else
            {
                switch (moveArg.Direction)
                {
                    case MoveDirection.Left:
                        this.Left -= ConvertUtil.ConvertToInt(arg.GetResult());
                        break;
                    case MoveDirection.Top:
                        this.Top -= ConvertUtil.ConvertToInt(arg.GetResult());
                        break;
                    case MoveDirection.Right:
                        this.Right += ConvertUtil.ConvertToInt(arg.GetResult());
                        break;
                    case MoveDirection.Bottom:
                        this.Bottom += ConvertUtil.ConvertToInt(arg.GetResult());
                        break;
                    default:
                        break;
                }
            }    
        }
        /// <summary>
        /// 闪烁动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void FlashAction(Object sender, GraphActionDefine arg)
        {
            this.Visible = !this.Visible;
        }
        /// <summary>
        /// 隐藏动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void HideAction(Object sender, GraphActionDefine arg)
        {
            this.Visible = ConvertUtil.ConvertToBool(arg.GetResult());
        }

        /// <summary>
        /// 笔刷颜色改变动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void BrushColorAction(Object sender, GraphActionDefine arg)
        {
            if (this.First is Meter)
            {
                (this.First as Meter).Indicator.BrushColor = (Color)arg.GetResult();
            }
            else
            {
                (this.First as GoShape).BrushColor = (Color)arg.GetResult();
            }
        }
        /// <summary>
        /// 线颜色改变动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void PenColorAction(Object sender, GraphActionDefine arg)
        {
            (this.First as GoShape).PenColor = (Color)arg.GetResult();
        }
        /// <summary>
        /// 按钮背景颜色改变动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void BackgroundColorAction(Object sender, GraphActionDefine arg)
        {
            if (this.First is GoButton)
            {
                (this.First as GoButton).Label.TransparentBackground = false;
                (this.First as GoButton).Label.BackgroundColor = (Color)arg.GetResult();
                ((this.First as GoButton).Background as GoRectangle).BrushColor = (Color)arg.GetResult();
            }
            else if (this.First is GoText)
            {
                (this.First as GoText).TransparentBackground = false;
                (this.First as GoText).BackgroundColor = (Color)arg.GetResult();
            }
        }
        /// <summary>
        /// 文本颜色改变动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void TextColorAction(Object sender, GraphActionDefine arg)
        {
            if (this.First is GoButton)
            {
                (this.First as GoButton).Label.TextColor = (Color)arg.GetResult();
            }
            else {
                (this.First as GoText).TextColor = (Color)arg.GetResult();
            }
        }
        /// <summary>
        /// 文本数据变化动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public void TextValueAction(Object sender, GraphActionDefine arg)
        {
            (this.First as GoText).Text = arg.GetResult().ToString();
        }
        #endregion
    }
}
