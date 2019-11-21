using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReportPrinterForVehAsm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WndMainInterface wndInterface = new WndMainInterface();
#if DEBUG
            wndInterface.InstallDev();
#else
            wndInterface.InstallDev(null,null,null,null,null);
#endif
            Application.Run(new WndMain(true));
        }
    }
}
