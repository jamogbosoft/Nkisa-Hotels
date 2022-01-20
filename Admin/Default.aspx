<%@ Page Title="Admin Home Page" Language="C#" MasterPageFile="~/SiteAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="AdminHeadContent">
   
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="AdminMainContent">

    <h1 >
        <span style="font-family: 'Agency FB'; font-size: xx-large; font-weight: bold; font-style: normal; font-variant: normal; color: #008080; text-align: left">Welcome to the Admin Home Page</span>
        <br />
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Admin.jpg" 
            Height="241px" Width="919px" />
    </h1>
</asp:Content>
