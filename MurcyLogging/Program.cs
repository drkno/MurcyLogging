using System;
using System.Windows.Forms;

namespace MurcyLogging
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var login = new LoginWindow();
            login.ShowDialog();
            Application.Run(new MainWindow(login.Session));
        }
    }
}
