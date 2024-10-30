    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Navbar.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="FinalProjectPSD_LAB.View.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
    <%if (Session["user"] != null)
        { %>
    <asp:Label runat="server" ID="HeaderLbl">Hi <%:((FinalProjectPSD_LAB.Models.User)Session["user"]).Username %> <---> Role: <%:((FinalProjectPSD_LAB.Models.User)Session["user"]).UserRole %></asp:Label>
    <%} %>
    <%if (Session["user"] != null)
        {
    %>
    <%if (((FinalProjectPSD_LAB.Models.User)Session["user"]).UserRole == "admin")
        { %>
    <asp:GridView runat="server" ID="UserDataGrid" EmptyDataText="No User"></asp:GridView>
    <%} %>
    <%} %>
</div>
</asp:Content>
