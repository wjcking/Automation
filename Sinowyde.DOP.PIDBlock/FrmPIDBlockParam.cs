using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;

namespace Sinowyde.DOP.PIDBlock
{
    public partial class FrmPIDBlockParam : DevExpress.XtraEditors.XtraForm
    {
        public string NewImageName { get; set; }

        /// <summary>
        /// 重新绘制Block
        /// </summary>
        public bool AgainDraw { get; set; }

        public ICtrlParamBase CtrlParam
        {
            get;
            protected set;
        }

        public FrmPIDBlockParam(ICtrlParamBase ctrlParam = null)
        {
            InitializeComponent();
            SetCtrlParam(ctrlParam);
        }

        public void SetCtrlParam(ICtrlParamBase ctrlParam)
        {
            if (ctrlParam != null)
            {
                this.CtrlParam = ctrlParam;
                //设置刷新
                //splitContainerControl.Panel1.Controls.Clear();
                UserControl childControl = ctrlParam.GetParamCtrl();
                pc_All.Tag = string.Format("{0};{1}", childControl.Width + 10, childControl.Height + 4);
                pc_All.Controls.Add(childControl);
                childControl.Dock = DockStyle.Fill;

            }
        }

        private void simpleButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            if (null != CtrlParam)
            {
                if (CtrlParam.SaveParam())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void FrmPIDBlockParam_Load(object sender, EventArgs e)
        {
            textEdit1.Enabled = false;
            textEdit2.Enabled = false;

            if (CtrlParam != null)
            {
                this.textEdit1.Text = CtrlParam.Block.Algorithm.GroupIndex;
                this.textEdit2.Text = CtrlParam.Block.Algorithm.IndexInGroup;
                //重置Form的高度
                int heightFormTop = 29;
                int heightFormBottom = 7;
                int heightPanelTop = 35;
                int heightPanelBottom = 29;
                this.Width = Convert.ToInt32(pc_All.Tag.ToString().Split(';')[0]);
                this.Height = Convert.ToInt32(pc_All.Tag.ToString().Split(';')[1]) + heightFormBottom + heightFormTop + heightPanelBottom + heightPanelTop;
                this.simpleButtonSave.SetBounds(this.panel1.Width - this.simpleButtonSave.Width - this.simpleButtonClose.Width - 30, 3, this.simpleButtonSave.Width, this.simpleButtonSave.Height);
                this.simpleButtonClose.SetBounds(this.simpleButtonSave.Left + this.simpleButtonClose.Width + 10, 3, this.simpleButtonClose.Width, this.simpleButtonClose.Height);

                this.Text = this.CtrlParam.Block.Algorithm.AlgName;

                CtrlParam.LoadParam();
                //保留原值
                UpdateParamVars();
            }
        }
        /// <summary>
        /// 保存原始数据
        /// </summary>
        private IList<AlgParamVarSummary> ParamVars = new List<AlgParamVarSummary>();
        private void UpdateParamVars()
        {
            ParamVars.Clear();
            if (CtrlParam != null && CtrlParam.Block.Algorithm != null)
            {
                IList<PIDAlgorithmParam> algParams = CtrlParam.Block.Algorithm.GetAllParam();
                foreach (PIDAlgorithmParam param in algParams)
                {
                    ParamVars.Add(new AlgParamVarSummary { Name = param.Name, Value = param.ValueToString(), Type = PIDCommandParamType.Param });
                }

                IList<PIDAlgorithmVar> inputs = CtrlParam.Block.Algorithm.GetAllInput();
                foreach (PIDAlgorithmVar input in inputs)
                {
                    ParamVars.Add(new AlgParamVarSummary { Name = input.Name, Value = input.Value.ToString(), Type = PIDCommandParamType.Input });
                }

                IList<PIDAlgorithmVar> outputs = CtrlParam.Block.Algorithm.GetAllOutput();
                foreach (PIDAlgorithmVar output in outputs)
                {
                    ParamVars.Add(new AlgParamVarSummary { Name = output.Name, Value = output.Value.ToString(), Type = PIDCommandParamType.Output });
                }
            }
        }

        /// <summary>
        /// 发生变化的数值
        /// </summary>
        public IList<AlgParamVarSummary> ChangeParamVars
        {
            get
            {
                IList<AlgParamVarSummary> summary = new List<AlgParamVarSummary>();
                if (CtrlParam == null || CtrlParam.Block.Algorithm == null)
                    return summary;

                foreach (AlgParamVarSummary one in this.ParamVars)
                {
                    switch (one.Type)
                    {
                        case PIDCommandParamType.Param:
                            PIDAlgorithmParam param = CtrlParam.Block.Algorithm.GetParam(one.Name);
                            if (param.ValueToString() != one.Value)
                            {
                                one.Value = param.ValueToString();
                                summary.Add(one);
                            }
                            break;
                        case PIDCommandParamType.Input:
                            PIDAlgorithmVar input = CtrlParam.Block.Algorithm.GetInputVar(one.Name);
                            if (input.Value != one.DValue)
                            {
                                one.Value = input.Value.ToString();
                                summary.Add(one);
                            }
                            break;
                        case PIDCommandParamType.Output:
                            PIDAlgorithmVar output = CtrlParam.Block.Algorithm.GetOutputVar(one.Name);
                            if (output.Value != one.DValue)
                            {
                                one.Value = output.Value.ToString();
                                summary.Add(one);
                            }
                            break;
                        default:
                            break;
                    }
                }
                return summary;
            }
        }
    }
}