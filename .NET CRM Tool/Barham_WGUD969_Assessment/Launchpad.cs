using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barham_WGUD969_Assessment.Classes;

namespace Barham_WGUD969_Assessment
{
    internal static class Launchpad
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            DBConnection.stopConnection();
        }
    }
}
