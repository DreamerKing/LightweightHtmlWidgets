using Awesomium.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightweightHtmlWidgets
{
    public partial class Window : Form
    {
        private Uri Target;
        private IniParser Parser;
        private PythonInstance Python;

        public Window(String[] Args)
        {
            WebPreferences Preferences = new WebPreferences();

            try
            {
                if (File.Exists("Settings.ini"))
                {

                    this.Parser = new IniParser("Settings.ini");

                    this.Target = new Uri(this.Parser.GetSettingOrDefault("Uri", "Target", @"[[CurrentDirectory]]\Default.html").Replace("[[CurrentDirectory]]", Environment.CurrentDirectory));

                    Preferences.AcceptCharset = this.Parser.GetSettingOrDefault("Preferences", "AcceptCharset", "iso-8859-1,*,utf-8");
                    Preferences.AcceptLanguage = this.Parser.GetSettingOrDefault("Preferences", "AcceptLanguage", "en-us,en");
                    Preferences.AllowInsecureContent = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "AllowInsecureContent", "true"));
                    Preferences.AppCache = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "AppCache", "true"));
                    Preferences.CanScriptsAccessClipboard = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "CanScriptsAccessClipboard", "false"));
                    Preferences.CanScriptsCloseWindows = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "CanScriptsCloseWindows", "true"));
                    Preferences.CanScriptsOpenWindows = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "CanScriptsOpenWindows", "true"));
                    Preferences.CustomCSS = this.Parser.GetSettingOrDefault("Preferences", "CustomCSS", "");
                    Preferences.Dart = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "Dart", "true"));
                    Preferences.Databases = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "Databases", "false"));
                    Preferences.DefaultEncoding = this.Parser.GetSettingOrDefault("Preferences", "DefaultEncoding", "iso-8859-1");
                    Preferences.EnableGPUAcceleration = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "EnableGPUAcceleration", "false"));
                    Preferences.FileAccessFromFileURL = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "FileAccessFromFileURL", "false"));
                    Preferences.Javascript = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "Javascript", "true"));
                    Preferences.LoadImagesAutomatically = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "LoadImagesAutomatically", "true"));
                    Preferences.LocalStorage = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "LocalStorage", "true"));
                    Preferences.Plugins = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "Plugins", "true"));
                    Preferences.ProxyConfig = this.Parser.GetSettingOrDefault("Preferences", "ProxyConfig", "");
                    Preferences.RemoteFonts = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "RemoteFonts", "true"));
                    Preferences.ShrinkStandaloneImagesToFit = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "ShrinkStandaloneImagesToFit", "true"));
                    Preferences.SmoothScrolling = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "SmoothScrolling", "false"));
                    Preferences.UniversalAccessFromFileURL = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "UniversalAccessFromFileURL", "false"));
                    Preferences.WebAudio = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "WebAudio", "true"));
                    Preferences.WebGL = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "WebGL", "false"));
                    Preferences.WebSecurity = Boolean.Parse(this.Parser.GetSettingOrDefault("Preferences", "WebSecurity", "true"));

                    this.Python = new PythonInstance(File.ReadAllText(Parser.GetSettingOrDefault("Ipy", "Script", "Ipy_Interface.py")), Parser.GetSettingOrDefault("Ipy", "Class", "Ipy_Interface"));
                }
                else
                {
                    MessageBox.Show("Unable to find Settings ini!", "Application error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("Failed to load Settings corectly!", "Application error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            InitializeComponent();

                this.Visible = false;

            this.Control.WebSession = WebCore.CreateWebSession(Preferences);

            this.Control.DocumentReady += (s, e) =>
            {
                JSObject Ipy = Control.CreateGlobalJavascriptObject("Ipy");
                Ipy.Bind("InvokeApi", false, this.Interface);

                if (this.Visible == false)
                {
                    this.Visible = true;
                }
            };
            // -> Available after 'DocumentReady' event:
            // Ipy.InvokeApi(
            //     function (Argument) { JSON.parse(Argument); },        // -> Callback
            //     "Test",                                               // -> Function
            //     JSON.stringify({  })                                  // -> Argument
            // );

            this.Control.Source = this.Target;
        }

        void Interface(object sender, JavascriptMethodEventArgs e)
        {
            if (!e.Arguments[0].IsObject && !e.Arguments[1].IsString && !e.Arguments[2].IsString)
            {
                return;
            }

            JSObject Callback = e.Arguments[0];
            String Function = e.Arguments[1];
            String Argument = e.Arguments[2];

            try
            {
                String result = (String) this.Python.CallFunction(Function, Argument);

                Callback.InvokeAsync("call", Callback, result);
            }
            catch
            {
                // Do nothing...
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //EXIT
            this.Close();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //RELOAD
            this.Control.Reload(true);
        }
    }
}
