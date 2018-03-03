using MiniTorrent.WebPortal.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniTorrent.WebPortal.Forms
{
    public partial class InfoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new MiniTorrentServiceClient();
            OnlineUsersLabel.Text = client.GetOnlineUsers().ToString();
            AllUsersLabel.Text = client.GetUsersAmount().ToString();
            AllFilesLabel.Text = client.GetFilesAmount().ToString();
        }

        protected void SearchFileButton_Click(object sender, EventArgs e)
        {

        }
    }
}