<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertMakeup.aspx.cs" Inherits="FinalProjectPSD_LAB.View.InsertMakeup" %>
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
         <asp:Label ID="PriceLbl" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="PriceTxt" runat="server" TextMode="Number"></asp:TextBox>
         <asp:Label ID="WeightLbl" runat="server" Text="Weight"></asp:Label>
        <asp:TextBox ID="WeightTxt" runat="server" TextMode="Number"></asp:TextBox>
     </div>
     <div>
         <asp:Label ID="TypeIDlbl" runat="server" Text="Type ID"></asp:Label>
         <asp:DropDownList ID="TypeIDDdl" runat="server"></asp:DropDownList>
         <asp:Label ID="BrandIDLbl" runat="server" Text="Brand ID"></asp:Label>
        <asp:DropDownList ID="BrandIDDdl" runat="server"></asp:DropDownList>
     </div>
     <div>
         <asp:Label ID="ErrorLbl" runat="server" Text="error" ForeColor="Red" Visible="false"></asp:Label>
     </div>
     <div>
         <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click" />
     </div>
 </div>
 <%} %>
 <%} %>
</asp:Content>
