using MiniTorrent.WebPortal.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniTorrent.WebPortal.Forms
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            string userName = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;
            var client = new MiniTorrentServiceClient();
            client.AddNewUser(userName, password);
            UserNameTextBox.Text = " ";
            PasswordTextBox.Text = " ";
        }
    }
}