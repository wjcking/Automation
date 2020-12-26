using System;
using Ninject;
using Ninject.Modules;
using Sinowyde.DOP.UI;
using Sinowyde.Log;

namespace Sinowyde.DOP.UI
{
    public class MyNinject : NinjectModule
    {
        public override void Load()
        {
            this.Bind<GoDrawViewEx>().ToSelf().InSingletonScope();//Graph软件界面GoDrawView,要先于MefTool
            this.Bind<MefTool>().ToSelf().InSingletonScope();//mef软件界面块
        }
    }


    public static class NinjectHelper
    {
        public static IKernel Kernel = null;
        static NinjectHelper()
        {
            try
            {
                var myNinject = new MyNinject();
                Kernel = new StandardKernel(myNinject);
            }
            catch (Exception ex)
            {
                LogUtil.LogFatal(ex.ToString());
            }
        }
    }
}
