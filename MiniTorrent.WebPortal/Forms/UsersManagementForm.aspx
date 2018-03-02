<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Portal.Master" AutoEventWireup="true" CodeBehind="UsersManagementForm.aspx.cs" Inherits="MiniTorrent.WebPortal.Forms.UsersManagementForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Enter Username:"></asp:Label>
        <asp:TextBox ID="SearchUserNameTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
    </p>
        <p>
            <asp:CheckBox ID="EnableDisableCheckBox" runat="server" Text="Enabled" />
        </p>
    <p>
        </p>
    <p>
        <asp:Button ID="UpdateUserButton" runat="server" Text="Update" OnClick="UpdateUserButton_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="DeleteUserButton" runat="server" Text="Delete" />
        </p>
    <p>
        </p>
</asp:Content>
