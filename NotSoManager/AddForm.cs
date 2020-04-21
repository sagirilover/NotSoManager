using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotSoManager
{
    public partial class AddForm : Form
    {
        static MainForm f = null;
        public AddForm(MainForm form)
        {
            InitializeComponent();
            f = form;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (FileSystem.Accounts.ContainsKey(nameTextBox.Text))
                FileSystem.Accounts[nameTextBox.Text] = new Account(loginTextBox.Text, passTextBox.Text);
            else
                FileSystem.Accounts.Add(nameTextBox.Text, new Account(loginTextBox.Text, passTextBox.Text));
            FileSystem.Save();
            this.Close();
            f.RefreshGrid();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
