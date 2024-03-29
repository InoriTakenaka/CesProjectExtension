﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SystemSettingExtension
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
            wndInterface.InstallDev();
            Application.Run(new WndMain());
        }
    }
}
