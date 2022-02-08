﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MyRedisDictionary
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string executablePath = Path.GetDirectoryName(Application.ExecutablePath);
            string redisPath = executablePath.Substring(0, executablePath.IndexOf("bin")) + @"redis-2.8.12\redis-server.exe";
            Process.Start(redisPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dictionary());
        }
    }
}
