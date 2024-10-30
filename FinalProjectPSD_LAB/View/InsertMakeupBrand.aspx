<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertMakeupBrand.aspx.cs" Inherits="FinalProjectPSD_LAB.View.InsertMakeupBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["user"] != null)
    {
%>
<%if (((FinalProjectPSD_LAB.Models.User)Session["user"]).UserRole == "admin")
    { %>
<div>
    <div>
        <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
         <asp:Label ID="RatingLbl" runat="server" Text="Rating"></asp:Label>
        <asp:TextBox ID="RatingTxt" runat="server" TextMode="Number"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text="Error" ForeColor="Red" Visible="false"></asp:Label>
    </div>
    <div>
        <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click"/>
    </div>
</div>
<%} %>
<%} %>
</asp:Content>
