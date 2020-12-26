using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DTProxy;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.Graph.Xml;
using Sinowyde.DOP.GraphicElement.Base;
using Sinowyde.DOP.UI;
using DevExpress.Utils;
using Northwoods.Go;

namespace Sinowyde.DOP.Graph
{
    [Export(typeof(IToolUc))]
    [ExportUcMetaData("GraphRun组态软件")]
    public partial class UCtlGraphRun : XtraUserControl, IToolUc
    {
        private Timer _timer = new Timer();

        public UCtlGraphRun()
        {
            InitializeComponent();
        }

        private void UCtlGraphRun_Load(object sender, EventArgs e)
        {
            InitDocs();
            GraphRunTime.Instance().GraphStatus = GraphDocStatus.IsRun;
            RTValueMemCache.Instance().StartMemCache();
            this._timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
            _timer.Start();
            this.Width = 1000;
            this.Height = 800;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            //foreach (GoObject obj in this.goViewRun.Document.DefaultLayer)
            //{
            //    var dopGraphElement = obj as DOPGraphElement;
            //    foreach (var action in dopGraphElement.ActionScript)
            //    {
            //        if (dopGraphElement.GetType().Name.Equals("DOPTimer"))
            //        {
            //            dopGraphElement.Refresh();
            //            continue;
            //        }
            //        else
            //        {
            //            IList<string> resultList = action.GetAllVariable();
            //            if (resultList != null && resultList.Count > 0)
            //            {
            //                IList<RTValue> realResultValue = RTValueMemCache.Instance().GetValues(resultList);
            //                if (realResultValue.Count < 1)
            //                    continue;
            //                action.RTValue = realResultValue;
            //                dopGraphElement.Refresh();
            //            }
            //        }
            //    }
            //}
            foreach (GoObject obj in this.goViewRun.Document.DefaultLayer)
            {
                var dopGraphElement = obj as DOPGraphElement;
                dopGraphElement.Refresh();
            }
        }
        
        private void InitDocs()
        {
            using (new WaitDialogForm("请等待", "数据加载中...", new Size(200, 50), ParentForm))
            {
                GraphDocManager.Instance().InitFromDB();
                IList<GraphDocument> graphEntity = GraphDocManager.Instance().OpenDocs;

                //有主页面
                var mainPage = graphEntity.FirstOrDefault(v => v.Name.Contains("Main"));
                if (null != mainPage)
                {
                    var doc = GraphDocManager.Instance().GetOpenedDoc(mainPage.Name);
                    goViewRun.Document = doc;
                }
                else
                {
                    var doc = graphEntity.FirstOrDefault();
                    goViewRun.Document = doc;
                }
                //document的颜色有bug，需要再次设置
                Color tempColor = goViewRun.Document.PaperColor;
                goViewRun.Document.PaperColor = Color.White;
                goViewRun.Document.PaperColor = tempColor;
                goViewRun.Visible = true;
            }
        }

        public UserControl CreateUc()
        {
            return this;
        }

        public void SaveUc()
        {

        }

        private void UCtlGraphRun_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
               
            }
            else
            {
                //_timer.Stop();
            }
        }
    }
}
