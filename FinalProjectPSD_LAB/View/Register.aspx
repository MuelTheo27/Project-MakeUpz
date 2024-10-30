<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Navbar.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FinalProjectPSD_LAB.View.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <div>
        <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
        <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="EmailTxt" runat="server" TextMode="Email"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
        <div>
            <asp:RadioButtonList ID="GenderRbl" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Label ID="DOBLbl" runat="server" Text="Date Of Birth"></asp:Label>
        <div>
             <asp:TextBox runat="server" TextMode="Date" ID="DOB"/>
             <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text="Erro" ForeColor ="red" Visible="false"></asp:Label>
    </div>
    <div>
        <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
    </div>
</div>
</asp:Content>
