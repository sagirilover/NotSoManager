using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotSoManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static IntPtr hWnd = (IntPtr)0;

        static Color counterPixel = Color.FromArgb(255, 125, 133, 148);

        static Size steamSize = new Size(330, 480);
        static int steamArea = steamSize.Width * steamSize.Height;

        static Size steamExtendedSize = new Size(390, 480);
        static int steamExtendedArea = steamExtendedSize.Width * steamExtendedSize.Height;

        static Point loginTextBox = new Point(117, 89);
        static Point passTextBox = new Point(117, 123);

        
        public static void Open(string x)
        {
            System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo();
            p.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.FileName = "cmd";
            p.Arguments = "/C start" + " " + x;
            System.Diagnostics.Process.Start(p);
        }
        public static void Login(string login, string password)
        {
            if (!WinAPI.CheckProcessByName("steam"))
            {
                Open(@"steam://start");
            }
            Process steam = WinAPI.WaitForProcessByName("steam");

            Size windowSize = WinAPI.GetWindowSize(steam.MainWindowHandle);
            WinAPI.SetForegroundWindow(steam.MainWindowHandle);
            Thread.Sleep(10);

            if (windowSize != steamSize && windowSize != steamExtendedSize)
            {
                int windowArea = windowSize.Width * windowSize.Height;
                if(windowArea > steamArea || windowArea > steamExtendedArea)
                {
                    steam.Kill();
                    steam.WaitForExit();
                    steam.Dispose();
                }
                Thread.Sleep(20);
                Login(login, password);
                return;
            }
            else
            {
                WinAPI.SetForegroundWindow(steam.MainWindowHandle);
                Thread.Sleep(10);
                Bitmap steamImg = WinAPI.GetImgByName("steam");

                dynamic oldClipboard = Clipboard.GetDataObject();

                while (!WinAPI.PixelScan(steamImg, loginTextBox, counterPixel))
                {
                    SendKeys.Send("{TAB}");
                    steamImg = WinAPI.GetImgByName("steam");
                }
                PasteFromClipboard(login);

                while (!WinAPI.PixelScan(steamImg, passTextBox, counterPixel))
                {
                    SendKeys.Send("{TAB}");
                    steamImg = WinAPI.GetImgByName("steam");
                }
                PasteFromClipboard(password);

                SendKeys.Send("{ENTER}");

                Clipboard.SetDataObject(oldClipboard);
            }
        }

        public static void Checks()
        {
            bool opened = false;

            while (true)
            {
                Thread.Sleep(500);

                if (Process.GetProcessesByName("steam").Length <= 0)
                    continue;

                Size windowSize = WinAPI.GetWindowSize(WinAPI.WaitForProcessByName("steam").MainWindowHandle);
                if (windowSize != steamSize && windowSize != steamExtendedSize)
                {
                    opened = false;
                    continue;
                }

                if (!opened)
                {
                    WinAPI.ShowWindow(hWnd,1);
                    opened = true;
                }
                    
            }
        }

        public static void ClearTextBox()
        {
            Thread.Sleep(1);
            SendKeys.Send("^A");
            SendKeys.Send("{BACKSPACE}");
        }

        public static void PasteFromClipboard(string paste)
        {
            Thread.Sleep(1);
            ClearTextBox();
            Clipboard.SetText(paste);
            SendKeys.Send("^A");
            SendKeys.Send("^V");
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form form = new AddForm(this);
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            hWnd = this.Handle;
            FileSystem.Init();

            RefreshGrid();

            Thread checksThread = new Thread(Checks)
            {
                IsBackground = true,
            };
            checksThread.Start();
        }
        public void RefreshGrid(bool pass = false)
        {
            accountGrid.Rows.Clear();
            foreach (KeyValuePair<string, Account> acc in FileSystem.Accounts)
            {
                accountGrid.Rows.Add(acc.Key, acc.Value.Login, pass ? acc.Value.Password : new string('*', acc.Value.Password.Length));
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow toRemove = accountGrid.SelectedRows[0];
            string name = toRemove.Cells[0].Value.ToString();
            if (FileSystem.Accounts.ContainsKey(name))
            {
                FileSystem.Accounts.Remove(name);
                FileSystem.Save();
            }
            accountGrid.Rows.Remove(accountGrid.SelectedRows[0]);
        }

        private void passCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid(passCheckBox.Checked);
        }

        private void accountGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Account toLogin = FileSystem.Accounts[accountGrid.SelectedRows[0].Cells[0].Value.ToString()];
            Login(toLogin.Login, toLogin.Password);
        }
    }
}
