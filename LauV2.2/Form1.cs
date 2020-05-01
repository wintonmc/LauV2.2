using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using LauV2._2.chormium2;
using MetroFramework.Controls;

namespace LauV2._2
{
    // este te da el form bonito
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public ChromiumWebBrowser JuegoWebBrowser;
        public ChromiumWebBrowser DiscortWebBrowser;
        public FormState formState = new FormState();
        public Form1()
        {
            InitializeComponent();
         
            this.Margin = new Padding(0, 0, 0, 0);
            this.Padding = new Padding(0, 0, 0, 0);
            this.Text = ConfigurationManager.AppSettings["Nombre"];
            //this.FormBorderStyle = FormBorderStyle.None;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TabParent.BackColor = Color.FromArgb(17, 39, 24);
            IniciarConfiguracionDewebrpwser();
            IniciarWebBrowser();
            this.Load += Form1_Load;

        }

        private  void Form1_Load(object sender, EventArgs e)
        {
            JuegoWebBrowser.FrameLoadEnd += (ob, ev) =>
            {
                JuegoWebBrowser.ExecuteScriptAsync(File.ReadAllText("Js/Main.js"));
            };
            //JuegoWebBrowser.KeyDown += (ob, ev) =>
            //{
            //    if (ev.KeyCode == Keys.Escape)
            //    {
            //        formState.Restore(this);
            //    }
            //};
           
            //formState.Maximize(this);
        }

        private void IniciarConfiguracionDewebrpwser()
        {
            var settings = new CefSettings();
            settings.CachePath = "chache";
            settings.CefCommandLineArgs.Add("enable-npapi", "1");
            Cef.Initialize(settings);
          

        }
        public void IniciarWebBrowser()
        {

            JuegoWebBrowser = JuegoWebBrowser ?? new ChromiumWebBrowser(ConfigurationManager.AppSettings["MainUrl"]);
            
            this.JuegoWebBrowser.Dock = DockStyle.Fill;
           
            var tab = new MetroTabPage { 
             Text = "Juego",
             
            };
            var tab2 = new MetroTabPage
            {
                Text = "Abrir Discort",
                

            };
            TabParent.SelectedIndexChanged += (ob, ev) =>
            {
                if (TabParent.SelectedIndex == 1)
                {
                    DiscortWebBrowser = DiscortWebBrowser ?? new ChromiumWebBrowser(ConfigurationManager.AppSettings["Discort"]);
                    this.DiscortWebBrowser.Dock = DockStyle.Fill;
                    DiscortWebBrowser.Parent = tab2;
                    tab2.Text = "Discord";
                }
                

            };
            this.TabParent.TabPages.Add(tab);
            this.TabParent.TabPages.Add(tab2);
            JuegoWebBrowser.Parent = tab;
          
            //JuegoWebBrowser.FrameLoadEnd += JuegoWebBrowser_FrameLoadEnd;
            // agragamos el browser ala tabla 
            //MainLayout.Controls.Add(ChromiumWebBrowser, 0, 1);

            // para qie llenen todo el contenedor 

        }
       
       
        private void pbclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool Toggle = true;
        private void pbVentana_Click(object sender, EventArgs e)
        {
            Toggle = (Toggle) ? false : true;
            if (!Toggle)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            
        }

        
    

    }
}
