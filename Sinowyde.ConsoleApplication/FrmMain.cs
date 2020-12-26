using System;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using Ninject;
using Sinowyde.DOP.DTProxy;
using Sinowyde.DOP.UI;
using System.Linq;

namespace Sinowyde.ConsoleApplication
{


    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {

        #region 变量

        private bool isMoving = false;
        private int currentPositionX = 0; //当前鼠标X坐标
        private int currentPositionY = 0; //当前鼠标Y坐标
        private Lazy<IToolUc, IUcMetaData> currntToolUc = null;

        #endregion

        public FrmMain()
        {
            InitializeComponent();

            this.FormClosing += FrmMain_FormClosing;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("关闭软件请注意保存！确认要退出？", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                if (null != currntToolUc)
                    currntToolUc.Value.SaveUc();

                RTValueMemCache.Instance().StopMemCache();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Init();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;

            SetControl(NinjectHelper.Kernel.Get<MefTool>().ToolAddUc.Where(v => v.Metadata.Name.Equals("Sama编辑软件")).FirstOrDefault());//Sama编辑软件  GraphRun组态软件  数据模型软件
        }

        private void Init()
        {
            panelControlTop.MouseMove += panelControlTop_MouseMove;
            panelControlTop.MouseDown += panelControlTop_MouseDown;
            panelControlTop.MouseUp += panelControlTop_MouseUp;
            panelControlTop.MouseLeave += panelControlTop_MouseLeave;
            panelControlTop.DoubleClick += panelControlTop_DoubleClick;


            dropDownButtonSoft.DropDownControl = CreateDxDropDownControl();
            simpleButtonMinimizeBox.Click += (sender, e) => { WindowState = FormWindowState.Minimized; };
            simpleButtonMaximizeBox.Click +=
                (sender, e) =>
                {
                    WindowState = WindowState == FormWindowState.Maximized
                                      ? FormWindowState.Normal
                                      : FormWindowState.Maximized;
                };
            simpleButtonClose.Click += (sender, e) =>
                {
                    Close();
                };
        }

        #region panelControlTop

        private void panelControlTop_DoubleClick(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void panelControlTop_MouseLeave(object sender, EventArgs e)
        {
            //初始状态
            currentPositionX = 0;
            currentPositionY = 0;
            isMoving = false;

        }

        private void panelControlTop_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }

        private void panelControlTop_MouseDown(object sender, MouseEventArgs e)
        {

            isMoving = true;
            currentPositionX = MousePosition.X;
            currentPositionY = MousePosition.Y;
        }

        private void panelControlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                //鼠标xy坐标确定窗体XY坐标 鼠标移动XY距离
                this.Left += MousePosition.X - currentPositionX;
                this.Top += MousePosition.Y - currentPositionY;
                //鼠标当前位置赋值
                currentPositionX = MousePosition.X;
                currentPositionY = MousePosition.Y;

            }
        }

        #endregion

        private void SetControl(Lazy<IToolUc, IUcMetaData> toolUc)
        {
            if (null == toolUc) return;

            if (null != currntToolUc)
                currntToolUc.Value.SaveUc();

            panelControl.Controls.Clear();
            var uc = toolUc.Value.CreateUc();
            uc.Dock = DockStyle.Fill;
            panelControl.Controls.Add(uc);

            labelControlSoftName.Text = toolUc.Metadata.Name;
            currntToolUc = toolUc;
        }

        private DXPopupMenu CreateDxDropDownControl()
        {
            var menu = new DXPopupMenu();
            var mefTool = NinjectHelper.Kernel.Get<MefTool>();
            if (null != mefTool)
            {
                foreach (var tool in mefTool.ToolAddUc)
                {
                    menu.Items.Add(new DXMenuItem(tool.Metadata.Name, (sender, args) => SetControl(tool)));
                }
            }
            return menu;
        }
    }
}
