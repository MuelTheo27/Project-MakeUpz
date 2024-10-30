<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Navbar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalProjectPSD_LAB.View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <div>
        <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
        <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:CheckBox ID="RememberBtn" runat="server" Text="Remember Me" />
    </div>
    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text="ErrorLabel" ForeColor="Red" Visible="false"></asp:Label>
    </div>
    <div>
        <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
    </div>
</div>
</asp:Content>
