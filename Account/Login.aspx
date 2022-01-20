<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Account/SiteAccount.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        #TableSignIn
        {
            height: 250px;
            width: 587px;
        }
        .SignIn
        {
            background-image: url('../Images/login_info_bg.gif'); background-repeat: no-repeat;
        }
        .WhiteText
        {
             color:White;
        }
        
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <table id="TableSignIn" align="center" class="SignIn" style="font-family: 'Courier New', Courier, monospace; font-size: medium; font-weight: bolder; font-style: normal; font-variant: normal; text-transform: none; color: #FFFFFF">
<tr id="SignIntd">

    <td id="SignIntdd" align="center" >
            
                You do not have access to the page<br />
                &nbsp;you are trying to visit,<br />
                please Sign-in first.
                <br /><br />
                For you to manage your bookings, <br />you need to create an account first.
     </td>
    
    </tr>    
    
    </table>

</asp:Content>