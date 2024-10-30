<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Navbar.Master" AutoEventWireup="true" CodeBehind="ManagerAdminMakeup.aspx.cs" Inherits="FinalProjectPSD_LAB.View.ManagerAdminMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["user"] != null)
    {
%>
<%if (((FinalProjectPSD_LAB.Models.User)Session["user"]).UserRole == "admin")
    { %>
<div>
    <asp:Button ID="InsertMakeupBtn" runat="server" Text="Insert Makeup" OnClick="InsertMakeupBtn_Click"  />
    <asp:Button ID="InsertMakeupTypeBtn" runat="server" Text="Insert Makeup Type" style="margin-left: 10px" OnClick="InsertMakeupTypeBtn_Click" />
    <asp:Button ID="InsertMakeupBrandBtn" runat="server" Text="Insert Makeup Brand" style="margin-left: 10px" OnClick="InsertMakeupBrandBtn_Click" />
    <br />
</div>
<div>
    <asp:GridView runat="server" ID="MakeupGrid" EmptyDataText="Empty" >       
    </asp:GridView>
    <br />
</div>
<div>
    <asp:GridView runat="server" ID="MakeupTypeGrid" EmptyDataText="Empty">
        
    </asp:GridView>

    <br />

</div>
<div>
    <asp:GridView runat="server" ID="MakeupBrandGrid" EmptyDataText="Empty" >
    </asp:GridView>

    <br />
</div>
<%} %>
<%} %>
</asp:Content>
