using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightweightHtmlWidgets
{
    static class Program
    {
        public static String NEW_LINE = "\r\n";

        [STAThread]
        static void Main(String[] Args)
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) => 
            {
                File.WriteAllText("last_error_information.txt", e.ExceptionObject.ToString());
                DialogResult Result = MessageBox.Show("An error occured!" + Program.NEW_LINE + Program.NEW_LINE + "Would you like to report the error and open a new ticket on 'http://github.com/GameplayJDK/LightweightHtmlWidgets/issues'?" + Program.NEW_LINE + "(Please include the content of 'last_error_information.txt')!", "Unhandled exception:", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (Result == DialogResult.Yes)
                {
                    Process.Start("http://github.com/GameplayJDK/LightweightHtmlWidgets/issues");
                }
                else if (Result == DialogResult.No)
                {
                    Process.Start("explorer.exe", "/select,last_error_information.txt");
                }
                Application.Exit();
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Window(Args));
        }
    }
}
