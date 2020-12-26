using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm.DB;
using Sinowyde.Util;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlPIDAlgorithms : XtraUserControl
    {
        private IList<PIDAlgEntity> pidAlgorithms = null;
        public string Outputs { get; set; }

        public UCtlPIDAlgorithms()
        {
            InitializeComponent();
        }

        private List<string> algIndexes = new List<string>() { "0", "0", "0", "0" };

        private Variable selectedVariable = new Variable();
        public Variable SelectedVariable
        {
            get
            {
                return selectedVariable;
            }
            set
            {
                selectedVariable = value;
            }
        }

        /// <summary>
        /// 返回选中状态
        /// </summary>
        public IList<string> AlgIndexes
        {
            get
            {
                algIndexes[0] = cboPage.SelectedIndex.ToString();
                algIndexes[1] = cboBlock.SelectedIndex.ToString();
                algIndexes[2] = cboAlgType.SelectedIndex.ToString(); 
                algIndexes[3] = cboIO.SelectedIndex.ToString();
                return algIndexes;
            }
            set
            {
                algIndexes = value as List<string>;         
            }
        }

        private void UCtlPIDAlgorithms_Load(object sender, EventArgs e)
        {
            try
            {
                PIDDataLogic.Instance().GetPageSummys().ToList().ForEach(s =>
                {
                    cboPage.Properties.Items.Add(new ComboxData() { ID = s.ID, Text = s.GIndex.ToString() });
                });
                cboPage.SelectedIndex =ConvertUtil.ConvertToInt(algIndexes[0]);

            }
            catch (Exception)
            {
                this.Enabled = false;
            }
        }
        /// <summary>
        /// 根据页号获取所有算法类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboAlgType.Properties.Items.Clear();
                var pageID = (this.cboPage.SelectedItem as ComboxData).ID;
                pidAlgorithms = PIDDataLogic.Instance().GetAlgorithmSummarys(pageID);
                List<string> algEntity = pidAlgorithms.Select(ss => ss.AlgType).Distinct().ToList();
                cboAlgType.Properties.Items.AddRange(algEntity);
                if (cboAlgType.Properties.Items.Count > 0)
                    cboAlgType.SelectedIndex = ConvertUtil.ConvertToInt(algIndexes[1]);
            }
            catch (Exception)
            {
                cboPage.Enabled = false;
            }
            
        }
        /// <summary>
        /// 根据算法类型获得所有块号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboAlgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboBlock.Properties.Items.Clear();
                pidAlgorithms = pidAlgorithms.Where(s => s.AlgType.Equals(this.cboAlgType.Text)).ToList();
                foreach (var alg in pidAlgorithms)
                {
                    cboBlock.Properties.Items.Add(alg.BIndex);
                }
                if (cboBlock.Properties.Items.Count > 0)
                    cboBlock.SelectedIndex = ConvertUtil.ConvertToInt(algIndexes[2]);
            }
            catch (Exception)
            {
                cboAlgType.Enabled = false;
            }
        }
        /// <summary>
        ///  根据算法块号获取所有输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboIO.Properties.Items.Clear();
                pidAlgorithms = pidAlgorithms.Where(w => w.BIndex.Equals(this.cboBlock.Text)).ToList();
                foreach (var output in pidAlgorithms.First().Outputs)
                {
                    cboIO.Properties.Items.Add(output);
                }
                if (cboIO.Properties.Items.Count > 0)
                    cboIO.SelectedIndex = ConvertUtil.ConvertToInt(algIndexes[3]);
            }
            catch (Exception)
            {
                this.cboBlock.Enabled = false;
            }
        }

 
        public class ComboxData
        {
            public string Text { set; get; }
            public long ID { set; get; }
            public override string ToString()
            {
                return Text;
            }
        }

        /// <summary>
        /// 根据输出取得变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var number = pidAlgorithms.First().VarNnumber(this.cboIO.Text);
            SelectedVariable = new Variable() { Number = number };
        }

        

        
    }
}
