<%@ Control ClassName="MyUserControlBookingHeader" Language="C#" AutoEventWireup="true" CodeFile="UserControlBookingHeader.ascx.cs" Inherits="User_ControlBookingHeader" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<style type="text/css">
    
    .BookNowPanel
    {
        border: 4px double #C0C0C0;
        padding: 0px;
        width: 100%;
        height: 100%;
        background-image: url('../Images/media_bg4.jpg');
    }
            
    .BlueLargeText
    {
        /*font-family: Bernard MT Condensed;*/
        font-family: 'Times New Roman' , Times, serif;
        font-size: x-large;
        color: #003366;
        text-align: center;
        font-weight: bold;   
    }
    
    .BlueLargeText2
    {
        /*font-family: Bernard MT Condensed;*/
        font-family: 'Times New Roman' , Times, serif;
        font-size: large;
        color: #003366;
        text-align: center;
        font-weight: bold;    
        text-align:left;
        vertical-align:top;
    }
    .NomalSmallText
    {
        font-family: 'Times New Roman' , Times, serif;
        font-size: medium;
        font-weight: bold;
        text-align: left;        
    }
    
        
</style>

 
     <asp:Panel ID="PanelBookNow" runat="server"  CssClass="BookNowPanel">
        <table style="background-image: url('../Images/media_bg4.jpg'); background-repeat: repeat;" 
             align="center" >
                <tr align="center" valign="top" >               
                    <td  width="100%" class="BlueLargeText">
                        <asp:Label ID="lblBranchName" runat="server"></asp:Label>
                    </td> 
                 </tr>
                 <tr align="center" valign="top" >        
                    <td  width="100%" class="BlueLargeText2">
                        <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                        <br /><br /><br />
                    </td>                                                     
                </tr>                
        </table>
        <table style="background-image: url('../Images/media_bg4.jpg'); background-repeat: repeat;" 
             width="100%" >
                <tr align="left" valign="top" >               
                    <td class="NomalSmallText">Check In Date:
                        <asp:Label ID="lblCheckInDate" runat="server" ForeColor="#003366"></asp:Label>
                    </td> 
                    <td  class="NomalSmallText">Check Out Date:
                        <asp:Label ID="lblCheckOutDate" runat="server" ForeColor="#003366"></asp:Label>
                    </td> 
                    <td  class="NomalSmallText">Number of Nights:
                        <asp:Label ID="lblNumberOfNights" runat="server" ForeColor="#003366"></asp:Label>
                    </td> 
                 </tr>
                 
        </table>
       </asp:Panel>      
