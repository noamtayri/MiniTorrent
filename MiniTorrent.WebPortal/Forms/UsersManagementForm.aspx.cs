using MiniTorrent.WebPortal.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniTorrent.WebPortal.Forms
{
    public partial class UsersManagementForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string userName = SearchUserNameTextBox.Text;
            var client = new MiniTorrentServiceClient();
            User user = client.GetUser(userName);
            UserNameTextBox.Text = user.UserName;
            PasswordTextBox.Text = user.Password;
            EnableDisableCheckBox.Checked = user.EnableDisable;
        }
    }
}