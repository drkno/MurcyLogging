using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agilefantasy;
using Agilefantasy.Agilefant;

namespace MurcyLogging
{
    public partial class LoginWindow : Form
    {

        public AgilefantSession Session { get; private set; }
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var username = usernameTextBox.Text;
            var password = passwordTextBox.Text;
            try
            {
                Session = await AgilefantSession.Login(username, password);
            }
            catch (SecurityException exception)
            {
                errorLabel.Text = exception.Message;
                return;
            }
            Close();
        }

        private void LoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Session == null)
                Environment.Exit(0);
        }
    }
}
