using MiniTorrent.WebPortal.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MiniTorrent.WebPortal.Forms
{
    public partial class UsersManagementForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {
            string oldUserName = SearchUserNameTextBox.Text;
            string newUserName = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;
            bool enable = EnableDisableCheckBox.Checked;
            var client = new MiniTorrentServiceClient();
            if (client.AdminUpdateUser(oldUserName, newUserName, password, enable))
            {
                MessageBox.Show("User updated");
                SearchUserNameTextBox.Text = "";
                UserNameTextBox.Text = "";
                PasswordTextBox.Text = "";
                EnableDisableCheckBox.Checked = false;
                SearchUserNameTextBox.Enabled = true;
            }
            else
            {
                MessageBox.Show("Username already exists");
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string userName = SearchUserNameTextBox.Text;
            var client = new MiniTorrentServiceClient();
            User user = client.AdminGetUser(userName);
            if (user == null)
            {
                MessageBox.Show("Username not found");
            }
            else
            {
                UserNameTextBox.Text = user.UserName;
                PasswordTextBox.Text = user.Password;
                EnableDisableCheckBox.Checked = user.EnableDisable;
                SearchUserNameTextBox.Enabled = false;
            }
        }

        protected void DeleteUserButton_Click(object sender, EventArgs e)
        {
            string userNameToDelete = SearchUserNameTextBox.Text;
            var client = new MiniTorrentServiceClient();
            client.DeleteUser(userNameToDelete);
            SearchUserNameTextBox.Text = "";
            UserNameTextBox.Text = "";
            PasswordTextBox.Text = "";
            EnableDisableCheckBox.Checked = false;
            SearchUserNameTextBox.Enabled = true;
            MessageBox.Show("User deleted");
        }
    }
}