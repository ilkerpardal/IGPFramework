using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Igp.Dto.Common.Menus;

namespace Igp.Form.Addin
{
    public partial class TransactionControl : UserControl
    {
        public TransactionControl()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMenuTransaction();
        }

        private void TransactionControl_Load(object sender, EventArgs e)
        {
            SetFormData();
        }
        
        public async void SaveMenuTransaction()
        {
            MenuTransactionDto model = new MenuTransactionDto()
            {
                MenuId = Convert.ToInt32(cmbMenu.SelectedValue),
                Description = richTxtDescription.Text,
                TransactionName = txtTransactionName.Text
            };
            await ServiceHelper.SaveMenuTransaction(model);
            MessageBox.Show("Transaction has saved");
        }

        public async void SetFormData()
        {
            cmbMenu.DataSource = await ServiceHelper.GetMenus();
        }
    }
}
