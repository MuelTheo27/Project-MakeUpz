<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="FinalProjectPSD_LAB.View.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div> 
        <%if (Session["user"] != null)
            {
        %>
    <%if (((FinalProjectPSD_LAB.Models.User)Session["user"]).UserRole == "customer")
                { %>

                <asp:GridView runat="server" ID="TransactionDetailTables" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />

                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Product Name"/>
                        <asp:BoundField DataField="Makeup.MakeupBrand.MakeupBrandName" HeaderText="Product Brand" />
                        <asp:BoundField DataField="Makeup.MakeupBrand.MakeupBrandRating" HeaderText="Product Rating" />
                        <asp:BoundField DataField="Makeup.MakeupType.MakeupTypeName" HeaderText="Product Type"/>
                        <asp:BoundField DataField="Makeup.MakeupWeight" HeaderText="Weight" />
                        <asp:BoundField DataField="Makeup.MakeupPrice" HeaderText="Price"  />
                    </Columns>
                </asp:GridView>
                <% }
            }%>
            
    </div>
</asp:Content>
