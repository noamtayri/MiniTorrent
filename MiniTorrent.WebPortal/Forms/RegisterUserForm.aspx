<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Portal.Master" AutoEventWireup="true" CodeBehind="RegisterUserForm.aspx.cs" Inherits="MiniTorrent.WebPortal.Forms.RegisterUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="UserName:"></asp:Label>
        <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
        &nbsp;
        <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
    </p>
    <p style="margin-left: 40px">
        <asp:Button ID="CreateUserButton" runat="server" Text="Register" />
    </p>
    <p>
    </p>
</asp:Content>
