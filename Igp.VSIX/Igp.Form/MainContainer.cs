using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Igp.Core.Helpers;

namespace Igp.Form.Addin
{
    public partial class MainContainer : System.Windows.Forms.Form
    {
        public MainContainer()
        {
            InitializeComponent();
        }

        private void MainContainer_Load(object sender, EventArgs e)
        {
            if (UserHelper.UserIdentity?.Id > 0)
            {
                formPanel.Controls.Clear();
                formPanel.Controls.Add(new TransactionControl());
            }
            else
            {
                formPanel.Controls.Clear();
                formPanel.Controls.Add(new AppSettingsControl());
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            formPanel.Controls.Clear();
            formPanel.Controls.Add(new AppSettingsControl());
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            if (UserHelper.UserIdentity?.Id > 0)
            {
                formPanel.Controls.Clear();
                formPanel.Controls.Add(new TransactionControl());
            }
            else {
                MessageBox.Show("User not found,please open settings and " +Environment.NewLine  +  
                                "save username,password and connectionString");
            }
        }
    }
}
