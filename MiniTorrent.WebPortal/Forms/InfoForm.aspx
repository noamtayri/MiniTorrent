<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Portal.Master" AutoEventWireup="true" CodeBehind="InfoForm.aspx.cs" Inherits="MiniTorrent.WebPortal.Forms.InfoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p></p>
    <p></p>
    <asp:Label ID="FileNameSearchLabel" runat="server" Text="File name:"></asp:Label>
    <asp:TextBox ID="FileNameSearchTextBox" runat="server" Width="428px"></asp:TextBox>
    <asp:Button ID="SearchFileButton" runat="server" Text="Search" OnClick="SearchFileButton_Click" />
    <br />
    <br />
    <asp:ListBox ID="FilesListBox" runat="server" Height="246px" Width="644px"></asp:ListBox>
    <br />
    <br />
    <asp:Button ID="RefreshButton" runat="server" Text="Refresh" OnClick="RefreshButton_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Online users:"></asp:Label>
    <asp:Label ID="OnlineUsersLabel" runat="server" Text=" " Enabled="False"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="All users:"></asp:Label>
    <asp:Label ID="AllUsersLabel" runat="server" Text=" " Enabled="False"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="All files:"></asp:Label>
    <asp:Label ID="AllFilesLabel" runat="server" Text=" " Enabled="False"></asp:Label>
    <br />
    <br />
</asp:Content>
