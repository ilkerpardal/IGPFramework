using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Igp.Form.Addin
{
    public partial class AppSettingsControl : UserControl
    {
        public AppSettingsControl()
        {
            InitializeComponent();
        }

        private void AppSettingsControl_Load(object sender, EventArgs e)
        {
            txtServer.Text = Properties.Settings.Default.ConnectionString;
            txtPassword.Text = Properties.Settings.Default.Password;
            txtUsername.Text = Properties.Settings.Default.UserName;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ConnectionString = txtServer.Text;
            Properties.Settings.Default.UserName = txtUsername.Text;
            Properties.Settings.Default.Password = txtPassword.Text;
            Properties.Settings.Default.Save();

            if (VerifyUser(txtServer.Text, txtUsername.Text, txtPassword.Text))
                MessageBox.Show("Settings have saved");
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if(VerifyUser(txtServer.Text, txtUsername.Text, txtPassword.Text))
                MessageBox.Show("Connection is successful");
        }

        private bool VerifyUser(string connectionString, string userName, string password)
        {
            try
            {
                ServiceHelper.VerifyUser(connectionString, userName, password);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
