using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Igp.Security;

namespace Igp.Form.Addin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] parameters)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.UnauthenticatedPrincipal);
            try
            {
                ServiceHelper.VerifyUser();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            Application.Run(new MainContainer());
        }

    }
}
