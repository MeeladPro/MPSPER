using System;
using System.Windows.Forms;
using System.Drawing;


namespace MPSPER
{
    public class TrayApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private Form1 mainForm;

        public TrayApplicationContext()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            mainForm = new Form1();

            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Open", null, OnOpen);
            trayMenu.Items.Add("Exit", null, OnExit);

            trayIcon = new NotifyIcon()
            {
                Icon = new Icon(SystemIcons.Application, 40, 40),
                ContextMenuStrip = trayMenu,
                Text = "MPSPER",
                Visible = true
            };

            trayIcon.DoubleClick += OnOpen;
        }

        private void OnOpen(object sender, EventArgs e)
        {
            if (mainForm.Visible)
            {
                mainForm.Activate();
            }
            else
            {
                mainForm.Show();
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                trayIcon.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
