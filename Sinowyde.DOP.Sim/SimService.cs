using Sinowyde.DataLogic;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.Sim.Properties;
using Sinowyde.DOP.DataModel;
using Sinowyde.DataModel;
using Sinowyde.Util;

namespace Sinowyde.DOP.Sim
{
    public class SimService : ServiceThread
    {
        //周期监测模型是否发生变更，如果变更则重新加载模型
     //   private CheckModel checkModel = null;
        /// <summary>
        /// 发布数据
        /// </summary>
        private PushThread pushThread = null;

        public SimService()
            :base(1000,1000)
        {
            //检查模型更新
            //checkModel = new CheckModel(DOPDataLogic.Instance(), ModelType.Communication);
            //checkModel.UpdateModelEvent += checkModel_UpdateModelEvent;
            //实例发布对象
            pushThread = new PushThread(Settings.Default.Response, IOTopic.IORead);
        }



        /// <summary>
        /// 更新模型事件
        /// </summary>
        private void checkModel_UpdateModelEvent()
        {
            pushThread.Stop();
            UpdateModel();
            pushThread.Start();
        }

        /// <summary>
        ///　更新模型数据，重新进行发布操作
        /// </summary>
        private void UpdateModel()
        {
            RTValue rtVal = new RTValue();
            rtVal.VarNumber = "Var1";
            rtVal.Value = 298.33f;
            rtVal.Quality = RtValueQuality.good;
            rtVal.Timestamp = System.DateTime.Now;
            pushThread.AddBuffer(rtVal.ToString());
        }

        /// <summary>
        /// 启动模拟发布程序
        /// </summary>
        internal bool StartService()
        {
            //checkModel.Start();
            pushThread.Start();
            return true;
        }
        /// <summary>
        ///　 
        /// </summary>
        internal void Send(RTValue rt)
        {
            pushThread.AddBuffer(rt.ToString());
        
        }
        /// <summary>
        /// 停止发布程序
        /// </summary>
        internal bool StopService()
        {
            //checkModel.Stop();
            pushThread.Stop();
            return true;
        }

        protected override bool DoWork()
        {
            return true;
        }
    }
}
