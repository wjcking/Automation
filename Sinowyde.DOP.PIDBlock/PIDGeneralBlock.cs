using System.Collections.Generic;
using Northwoods.Go;
using Sinowyde.DOP.PIDAlgorithm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sinowyde.DOP.PIDBlock
{

    public class StateColor
    {
        public static Color Normal = Color.Gainsboro;
        public static Color Force = Color.Red;
        public static Color Keep = Color.Green;
    }

    [Serializable]
    public class PIDGeneralBlock : GoGeneralNode
    {
        /// <summary>
        /// 发送命令, CommandStr,文档HashCode默认给-1,
        /// </summary>
        public static Action<string, int> CommandAction;

        public static Action<string, string> LocateAction;

        //是否是运行环境
        public static volatile bool IsRunning = false;

        /// <summary>
        /// 显示端口文字
        /// </summary>
        protected virtual bool IsShowPortLabelName
        {
            get
            {
                return true;
            }
        }

        public string iconName = string.Empty;

        /// <summary>
        /// block中 icon图片的名称
        /// 图片名称更换时 自动调用 DrawBackground
        /// </summary>
        public virtual string IconName
        {
            get { return iconName; }
            set
            {
                if (!iconName.Equals(value))
                {
                    iconName = value;
                    this.ChangeIconImage(iconName);
                }
            }
        }

        /// <summary>
        /// 关联算法
        /// </summary>
        public PIDBindAlgorithm Algorithm
        {
            get;
            protected set;
        }

        /// <summary>
        /// 模块唯一标识
        /// </summary>
        public string Identity
        {
            get { return this.Algorithm.Identity; }
            set { this.Algorithm.Identity = value; }
        }

        /// <summary>
        /// 参数设置界面
        /// </summary>
        [NonSerialized]
        protected ICtrlParamBase ctrlParam = null;
        public ICtrlParamBase CtrlParam
        {
            get
            {
                if (this.ctrlParam == null)
                {
                    this.ctrlParam = CreateCtrlParam();
                    if (this.ctrlParam != null)
                    {
                        this.ctrlParam.Block = this;
                        this.paramFrm = new FrmPIDBlockParam();
                        this.paramFrm.SetCtrlParam(this.ctrlParam);
                    }
                }

                return this.ctrlParam;
            }
        }

        protected virtual ICtrlParamBase CreateCtrlParam()
        {
            return null;
        }

        /// <summary>
        /// 参数界面
        /// </summary>
        [NonSerialized]
        private FrmPIDBlockParam paramFrm = null;
        /// <summary>
        /// 绑定算法，关联参数设置界面，绘制显示,用于点击拖拽行为添加Block
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="ctrlParam"></param>
        public PIDGeneralBlock(PIDBindAlgorithm algorithm)
        {
            this.Algorithm = algorithm;
            this.Algorithm.AlgChangedEvent += AlgorithmChangeEvent;

            Initialize(null, null, string.Empty, string.Empty,
                   Algorithm.GetAllInput().Count, Algorithm.GetAllOutput().Count);
            InitialBlockParam(string.Empty);

            SetInPortParam();
            SetOutPortParam();

            //绘制
            DrawBackground();
        }

        /// <summary>
        /// 内部算法发生变化
        /// </summary>
        public const int ChangedAlgorithm = 0x1000;
        private void AlgorithmChangeEvent(Object sender, AlgorithmChangeArg arg)
        {
            GoDocument document = this.Document;
            if (document != null)
            {
                document.RaiseChanging(0x385, ChangedAlgorithm, this);
            }
        }

        protected override GoGeneralNodePort CreatePort(bool input)
        {
            return new PIDGeneralPort
            {
                LeftSide = input,
                IsValidFrom = !input,
                IsValidTo = input
            };
        }

        /// <summary>
        /// 绘制正常显示图形
        /// </summary>
        public virtual void DrawBackground() { }

        /// <summary>
        /// 双击显示参数界面
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public override bool OnDoubleClick(GoInputEventArgs evt, GoView view)
        {
            if (evt != null && evt.Buttons == MouseButtons.Left && evt.DoubleClick)
                ShowParamDialog();

            return base.OnDoubleClick(evt, view);
        }

        #region
        /// <summary>
        /// 中间label
        /// </summary>
        public GoText midLabel = null;

        /// <summary>
        /// 刷新文本显示
        /// </summary>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <param name="mid"></param>
        public void RefreshTex(String top, String bottom, string mid)
        {
            this.TopText = top;
            this.BottomText = bottom;
            this.MidText = mid;
        }
        /// <summary>
        /// 设置输入是否可见
        /// </summary>
        /// <param name="visible"></param>
        protected void SetInPortParam()
        {
            LeftPortLabelsInside = true;
            for (int i = 0; i < this.LeftPortsCount; i++)
            {
                GoGeneralNodePort port = this.GetLeftPort(i);
                port.IsValidSelfNode = true;
                port.IsValidSingleLink = true;
                port.UserObject = Algorithm.GetAllInput()[i];
                port.Label.Text = string.Empty;
                if (this.IsShowPortLabelName)
                {
                    port.Label.Text = (port.UserObject as PIDAlgorithmVar).Name.Replace(PIDAlgorithmToken.prefixInput, "");
                }
                SetPortParam(port);
            }
        }

        /// <summary>
        /// 设置输出是否可见
        /// </summary>
        /// <param name="visible"></param>
        protected void SetOutPortParam()
        {
            RightPortLabelsInside = true;
            for (int i = 0; i < this.RightPortsCount; i++)
            {
                GoGeneralNodePort port = this.GetRightPort(i);
                port.IsValidSelfNode = true;
                port.UserObject = Algorithm.GetAllOutput()[i];
                port.Label.Text = string.Empty;
                if (this.IsShowPortLabelName)
                {
                    port.Label.Text = (port.UserObject as PIDAlgorithmVar).Name.Replace(PIDAlgorithmToken.prefixResult, "");
                }
                SetPortParam(port);
            }
        }
        /// <summary>
        /// 设置子对象布局
        /// </summary>
        /// <param name="childchanged"></param>
        protected override void LayoutLabels()
        {
            if (this.midLabel != null && this.Icon != null)
                this.midLabel.SetSpotLocation(Middle, this.Icon, Middle);
            base.LayoutLabels();
        }

        /// <summary>
        /// 设置端口属性
        /// </summary>
        /// <param name="visible"></param>
        private void SetPortParam(GoGeneralNodePort port)
        {
            port.Editable = false;
            port.Resizable = false;
            port.Label.Editable = false;
            port.Label.Resizable = false;
            port.Label.Font = new Font("", 8f);

        }
        /// <summary>
        /// 设置显示文本属性
        /// </summary>
        protected void InitialBlockParam(string mid)
        {
            this.Resizable = false;

            this.TopLabel.Editable = false;
            this.BottomLabel.Editable = false;

            this.midLabel = new GoText();
            this.midLabel.Multiline = true;
            this.midLabel.Selectable = false;
            this.midLabel.Editable = false;
            //this.midLabel.Font = new System.Drawing.Font("", 6f);
            this.midLabel.Text = mid;
            this.midLabel.FontSize = 12f;
            this.Add(this.midLabel);
        }
        #endregion

        #region   显示文本
        /// <summary>
        /// 显示中间文本
        /// </summary>
        public String MidText
        {
            get
            {
                return this.midLabel.Text;
            }
            set
            {
                this.midLabel.Text = value;
                this.midLabel.Visible = !string.IsNullOrEmpty(this.midLabel.Text);
            }
        }
        /// <summary>
        /// 顶部文本
        /// </summary>
        public String TopText
        {
            get
            {
                return this.TopLabel.Text;
            }
            set
            {
                this.TopLabel.Text = value;
                this.TopLabel.Visible = !string.IsNullOrEmpty(this.TopLabel.Text);
            }
        }
        /// <summary>
        /// 底部文本
        /// </summary>
        public String BottomText
        {
            get
            {
                return this.BottomLabel.Text;
            }
            set
            {
                this.BottomLabel.Text = value;
                this.BottomLabel.Visible = !string.IsNullOrEmpty(this.BottomLabel.Text);
            }
        }
        /// <summary>
        /// 设置端口显示文本
        /// </summary>
        /// <param name="index"></param>
        /// <param name="showText"></param>
        public void SetPortText(bool left, int index, string showText)
        {
            GoGeneralNodePort port = left ? this.GetLeftPort(index)
                : this.GetRightPort(index);
            if (port != null)
            {
                port.Label.Visible = !string.IsNullOrEmpty(showText);
                port.Label.Text = showText;
            }
        }
        /// <summary>
        /// 获取端口显示文本
        /// </summary>
        /// <param name="left"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetPortText(bool left, int index)
        {
            GoGeneralNodePort port = left ? this.GetLeftPort(index)
                : this.GetRightPort(index);
            return port != null ? port.Label.Text : port.Label.Text;
        }
        #endregion

        /// <summary>
        /// 界面设置参数
        /// </summary>
        private void SetCommand()
        {
            if (null == paramFrm)
                return;

            IList<AlgParamVarSummary> list = paramFrm.ChangeParamVars;
            foreach (var algParamVarSummary in list)
            {
                if (algParamVarSummary.Type == PIDCommandParamType.Output)
                    continue;

                var msg = new PIDCommmandMsg();
                msg.CommandType = PIDCommandType.ForceValue;
                msg.TakeEffect = true;
                msg.Guid = Algorithm.Identity;
                msg.Token = algParamVarSummary.Name;
                msg.Value = algParamVarSummary.Value;

                if (algParamVarSummary.Type == PIDCommandParamType.Input)
                    msg.ParamType = PIDCommandParamType.Input;
                else if (algParamVarSummary.Type == PIDCommandParamType.Param)
                    msg.ParamType = PIDCommandParamType.Param;
              
                CommandAction(msg.ToString(), Document.GetHashCode());
            }
        }

        #region 右键菜单

        /// <summary>
        /// 显示参数界面
        /// </summary>
        public virtual void ShowParamDialog()
        {
            if (this.CtrlParam == null)
                return;
            paramFrm.StartPosition = FormStartPosition.CenterScreen;
            paramFrm.Text = "参数设置" + PartID.ToString();
            if (paramFrm.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(paramFrm.NewImageName))
                {
                    //更新shape 图片
                    this.IconName = paramFrm.NewImageName;
                }

                if (paramFrm.AgainDraw)
                {
                    this.DrawBackground();
                }

                //发送参数变化命令
                if (PIDGeneralBlock.IsRunning)
                    SetCommand();
            }
        }

        /// <summary>
        /// 强制算法块输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Forced(object sender, EventArgs e)
        {
            if (null != CommandAction)
            {
                var frmForced = new FrmForced(this);
                if (frmForced.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(frmForced.CommmandMsgStr))
                    CommandAction(frmForced.CommmandMsgStr, Document.GetHashCode());
            }
        }

        /// <summary>
        /// 取消强制算法块输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnForced(object sender, EventArgs e)
        {
            if (null != CommandAction)
            {
                var frmForced = new FrmForced(this, false);
                if (frmForced.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(frmForced.CommmandMsgStr))
                    CommandAction(frmForced.CommmandMsgStr, Document.GetHashCode());
            }
        }

        /// <summary>
        /// 保持算法块输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeepOutput(object sender, EventArgs e)
        {
            if (null != CommandAction)
            {
                var frmKeep = new FrmKeep(this);
                if (frmKeep.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(frmKeep.CommmandMsgStr))
                    CommandAction(frmKeep.CommmandMsgStr, Document.GetHashCode());
            }
        }

        /// <summary>
        /// 取消保持算法块输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnKeepOutput(object sender, EventArgs e)
        {
            if (null != CommandAction)
            {
                var frmKeep = new FrmKeep(this, false);
                if (frmKeep.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(frmKeep.CommmandMsgStr))
                    CommandAction(frmKeep.CommmandMsgStr, Document.GetHashCode());
            }
        }

        public override GoContextMenu GetContextMenu(GoView view)
        {
            var goContextMenu = new GoContextMenu(view);
            goContextMenu.MenuItems.Add(new MenuItem("强制算法块输出", new EventHandler(Forced)) { Enabled = PIDGeneralBlock.IsRunning });
            goContextMenu.MenuItems.Add(new MenuItem("取消强制算法块输出", new EventHandler(UnForced)) { Enabled = PIDGeneralBlock.IsRunning });
            goContextMenu.MenuItems.Add(new MenuItem("保持算法块输出", new EventHandler(KeepOutput)) { Enabled = PIDGeneralBlock.IsRunning });
            goContextMenu.MenuItems.Add(new MenuItem("取消保持算法块输出", new EventHandler(UnKeepOutput)) { Enabled = PIDGeneralBlock.IsRunning });
            return goContextMenu;
        }

        #endregion

        #region port输出结果显示

        private Dictionary<string, GoText> _dicOutput = new Dictionary<string, GoText>();


        /// <summary>
        /// 显示,四舍五入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public virtual void SetOutputText(string key, double value)
        {
            if (_dicOutput.ContainsKey(key))
                _dicOutput[key].Text = Math.Round(value, 2, MidpointRounding.AwayFromZero).ToString(); //value.ToString("0.00");
        }

        public virtual void SetOutputText(string str)
        {
            foreach (var item in _dicOutput)
            {
                item.Value.Text = str;
            }
        }

        /// <summary>
        /// 输出,根据port动态创建,命名规则  BIO.Identity.OutputVarName //注意IO输出？？直接Var命名
        /// </summary>
        public virtual Dictionary<string, GoText> CreateOutputText()
        {
            ClearOutputText();
            IList<string> list = Algorithm.GetAllResultVarName();
            for (int i = 0; i < RightPortsCount; i++)
            {
                GoGeneralNodePort port = GetRightPort(i);
                var name = list[i];
                var goText = new GoText
                {
                    Text = string.Empty,
                    TextColor = Color.Blue,
                    Center = new PointF(port.Center.X + 14, port.Center.Y - 6),
                    Editable = false,
                    Selectable = false,
                    Movable = false
                };
                _dicOutput.Add(name, goText);
                Add(goText);
            }

            return _dicOutput;
        }

        public virtual void ClearOutputText()
        {
            foreach (var item in _dicOutput)
            {
                if (this.Contains(item.Value))
                    this.Remove(item.Value);
            }
            _dicOutput.Clear();
        }

        #endregion

        public virtual bool CheckSelfValid()
        {
            var isValid = this.Algorithm.CheckSelfValid();
            //输出至少得有一个关联变量
            var isSet = false;
            for (int j = 0; j < this.RightPortsCount; j++)
            {
                GoGeneralNodePort rightPort = this.GetRightPort(j);
                if (rightPort.LinksCount > 0)
                {
                    isSet = true;
                    break;
                }
                if (!string.IsNullOrEmpty((rightPort.UserObject as PIDAlgorithmVar).BindSource))
                {
                    isSet = true;
                    break;
                }
            }
            if (!isSet)
            {
                //生成错误记录
                PIDCompileErrManager.Instance().AddError(new PIDCompileError
                {
                    Identity = this.Identity,
                    GroupIndex = this.Algorithm.GroupIndex,
                    IndexInGroup = this.Algorithm.IndexInGroup,
                    Description = string.Format("至少一个输出须关联变量"),
                    AlgName = this.Algorithm.AlgName
                });
            }

            return isValid && isSet;
        }

        public GoGeneralNodePort GetLeftPort(string name)
        {
            for (int i = 0; i < this.LeftPortsCount; i++)
            {
                if ((this.GetLeftPort(i).UserObject as PIDAlgorithmVar).Name == name)
                {
                    return this.GetLeftPort(i);
                }
            }
            return null;
        }

        public GoGeneralNodePort GetRightPort(string name)
        {
            for (int i = 0; i < this.RightPortsCount; i++)
            {
                if ((this.GetRightPort(i).UserObject as PIDAlgorithmVar).Name == name)
                {
                    return this.GetRightPort(i);
                }
            }
            return null;
        }

        public bool IsLinkLeftPort(string name)
        {
            GoGeneralNodePort port = GetLeftPort(name);
            if (port != null)
                return port.LinksCount > 0;
            else
                return false;
        }

        public bool IsLinkRightPort(string name)
        {
            GoGeneralNodePort port = GetRightPort(name);
            if (port != null)
                return port.LinksCount > 0;
            else
                return false;
        }
    }
}
