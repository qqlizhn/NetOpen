using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;

namespace netOpen
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
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new netOpen_MainWindow());
        }
    }
}
