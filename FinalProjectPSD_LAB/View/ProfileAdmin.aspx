﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Navbar.Master" AutoEventWireup="true" CodeBehind="ProfileAdmin.aspx.cs" Inherits="FinalProjectPSD_LAB.View.ProfileAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <asp:Label ID="UsernamLBLe" runat="server" Text="Username:"></asp:Label>
            <asp:Label ID="UsernameName" runat="server"></asp:Label>
        </div>

        <div>
            <asp:Label ID="PasswordLBL" runat="server" Text="Password:"></asp:Label>
            <asp:Label ID="PasswordName" runat="server"></asp:Label>
        </div>

        <div>
            <asp:Label ID="EmailLBL" runat="server" Text="Email:"></asp:Label>
            <asp:Label ID="EmailName" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="GenderLBL" runat="server" Text="Gender:"></asp:Label>
            <asp:Label ID="GenderName" runat="server" ></asp:Label>
        </div>
    </div>
</asp:Content>
