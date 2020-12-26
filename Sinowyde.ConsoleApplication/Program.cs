using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using Sinowyde.Log;

namespace Sinowyde.ConsoleApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            DevExpressLocalizerHelper.SetSimpleChinese();//汉化
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());

            try
            {
                SetExceptionCatch();
                if ((Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)).GetUpperBound(0) > 0)
                {
                    XtraMessageBox.Show("正在运行中!");
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmMain());
                }
            }
            catch (InvalidOperationException ex)
            {
                LogUtil.LogFatal(ex.ToString());
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                LogUtil.LogFatal(ex.ToString());
                DevexpressUtil.ShowExceptionDialog(ex);
                Process.GetCurrentProcess().Kill();
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            if (null != ex)
                LogUtil.LogFatal(ex.ToString());

            DevexpressUtil.ShowExceptionDialog(ex);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (null != ex)
                LogUtil.LogFatal(ex.ToString());

            DevexpressUtil.ShowExceptionDialog(ex);
        }

        private static void SetExceptionCatch()
        {
            //处理未捕获的异常   
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常   
            Application.ThreadException += Application_ThreadException;
            //处理非UI线程异常   
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }
    }
}
