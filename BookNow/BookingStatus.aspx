<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookingStatus.aspx.cs" Inherits="PaymentReview" %>
<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Booking Status</title>
    <link rel="stylesheet" type="text/css" media="print" href="../Styles/Print.css" /> 
    <link href="~/Styles/Payment.css" rel="Stylesheet" type="text/css" id="Link1" />    
    <link id="Linkicon" runat="server" rel="icon" href="~/favicon.ico" type="image/ico" />
</head>

<body>
    
    <form id="frmPaymentReview" runat="server">

    <div class="page">
     <div class="main">
     
     
     
      <table>
        <tr align="center">
            <td align="center" colspan="3">
                <ww:ErrorDisplay runat="server" ID="Message1" Width="400px" />   
            </td>
        </tr>
        <tr valign="top">          
            <td width="550px">   
             <div class="sidebar">
                <div class="sidebarheader">Payment Review</div>
                <div class="sidebarcontent">  

    <asp:Panel ID="panelPaymentReview" runat="server">
     <table width="100%" >
                
        <tr style="font-weight: bold;">
            <td align="left">
                <asp:Label ID="Label1" runat="server" Text="Surname:"></asp:Label>
            </td>
            <td align="left">                
                 <asp:Label ID="lblSurname" runat="server" ></asp:Label>           
            </td>
        </tr>      
        <tr style="font-weight: bold;">
            <td align="left">
                <asp:Label ID="Label2" runat="server" Text="First Name:" ></asp:Label>
            </td>                 
            <td align="left">                
                 <asp:Label ID="lblFirstName" runat="server" ></asp:Label>  
            </td>          
        </tr>  
        <tr style="font-weight: bold;">
            <td align="left">
                <asp:Label ID="Label8" runat="server" Text="Email Address:" ></asp:Label>
            </td>                 
            <td align="left">                
                 <asp:Label ID="lblEmailAddress" runat="server" ></asp:Label>  
            </td>          
        </tr> 
        <tr style="font-weight: bold;">
            <td align="left">
                <asp:Label ID="Label9" runat="server" Text="Phone Number:" ></asp:Label>
            </td>                 
            <td align="left">                
                 <asp:Label ID="lblPhoneNumber" runat="server" ></asp:Label>  
            </td>          
        </tr>  
        <tr style="font-weight: bold;">
            <td align="left">
                <asp:Label ID="Label3" runat="server" Text="Mode of Payment:" ></asp:Label>
            </td>                 
            <td align="left">                
                 <asp:Label ID="lblModeOfPayment" runat="server" ></asp:Label>  
            </td>          
        </tr>  

        <tr style="font-weight: bold;">
            <td align="left" class="BookingNumber">
                <asp:Label ID="Label4" runat="server" Text="Booking Ref.:" ></asp:Label>
            </td>                 
            <td align="left" class="BookingNumber">                
                 <asp:Label ID="lblBookingID" runat="server" ></asp:Label>  
            </td>          
        </tr> 
         
        <tr><td align="left"  colspan="2">  
            <table align="center">
                <tr valign="top">
                    <td align="center" 
                        style="font-size: small; color: #008080; font-weight: bold;">     
                        <asp:Label ID="lblBookingMessage" runat="server" 
                            Text="Thanks"></asp:Label>
                    </td>
                </tr>                      
            </table>            
        </td></tr>
        <tr><td align="left"  colspan="2">  
            <div style="text-align: center;" align="center">   
                <asp:Panel ID="panelPaymentStatement" runat="server" 
                    CssClass="errordisplay">                  
		            <h2><asp:Label ID="lblTransactionStatement" runat="server"></asp:Label></h2>
		            <h3 class="RRR2"><strong >
                        <asp:Label ID="lblRRRCaption" runat="server"></asp:Label>
                        <asp:Label ID="lblRRR" runat="server"></asp:Label>
                    </strong></h3>		            
		            <p><asp:Label ID="lblReasonCaption" runat="server"></asp:Label> <asp:Label ID="lblReason" runat="server"></asp:Label></p>
                    <p class="RRR2"> <asp:HyperLink ID="HyperLinkRetryPayment" runat="server">[HyperLinkRetryPayment]</asp:HyperLink></p>                    

                </asp:Panel>                
            </div>   
        </td></tr>     
        <tr><td align="left"  colspan="2">                         
            <asp:Panel ID="panelDetails1" runat="server">
                <table width="100%">                
                <tr>
                    <td align="left" style="font-size: small; color: #008080">
                        <asp:Label ID="Label5" runat="server" Text="1. Print this Invoice or copy the RRR and visit the nearest First Bank Plc of your choice. Write the RRR on the teller. Request to make payment for NKISA HOTELS using Remita."></asp:Label>
                    </td>
                </tr> 
                <tr>
                    <td style="font-size: small; color: #008080">
                        <ul style="list-style-type:square; font-weight: bold;">
                            <li>Account Name: Nkisa Hotels.</li>
                            <li>Account No: 0000000000</li>
                            <li>Bank: First Bank</li>
                        </ul> 
                    </td>
                </tr>
                <tr>
                    <td align="left" style="font-size: small; color: #008080">
                        <asp:Label ID="Label10" runat="server" Text="2. Our Customer Service will call you in the next 10 minutes to confirm your booking. You will also receive an email with your booking confirmation details."></asp:Label>
                    </td>
                </tr> 
                </table>
            </asp:Panel>           
        </td></tr>
        <tr><td colspan="2">  
            <asp:Panel ID="panelDetails2" runat="server">
            <table >  
                <tr valign="top" align="center">
                    <td style="font-size: small; color: #008080" align="center">     
                        <asp:Label ID="lblConfirmMailMessage" runat="server" 
                            Text="Please check your mail now to confirm your booking."></asp:Label>
                    </td>
                </tr>                 
                <tr valign="top">
                    <td  style="font-size: small; color: #008080">     
                        <br />
                        <asp:Label ID="lblCancellationMessage" runat="server" 
                            Text="If cancelled up to ..."></asp:Label>
                    </td>
                </tr>
            </table>   
            </asp:Panel>         
        </td></tr>

        <tr><td align="left"  colspan="2">  
            <table align="center">                
                <tr class="dontprint">
                    <td align="center" class="dontprint">                                   
                        <asp:Button ID="btnHome" runat="server" Text="Home" 
                            CssClass="okbuttonlarge" PostBackUrl="~/" Font-Italic="True" />            
                    </td>
                    <td width="50px"></td>
                    <td align="center" class="dontprint">  
                        <a href="#" onclick="window.print();return false;">       
                           <asp:Button ID="btnPrint" runat="server" Text="Print" 
                            CssClass="okbuttonlarge" Font-Italic="True" />
                        </a>              
                    </td>    
                                                      
                </tr>
            </table>            
        </td></tr>

     </table>   
     </asp:Panel>
        
                </div>
               </div>                 
            </td>
            <td width="5px"></td>
            <td width="360px">
                <div class="sidebar">
                    <div class="sidebarheader">Booking Summary</div>                            
                    <div class="sidebarcontentb">
                    <asp:Panel ID="panelBookingSummary" runat="server">
                    <table style="height: 105px; width:100%; " >
                        <tr valign="top">                  
                            <td height="98px" width="105px" align="left" valign="top">
                                <asp:Image ID="imgLogo" runat="server" 
                                Height="98px" ImageAlign="Left"
                                Width="105px"/>
                            </td>                               

                            <td  width="250px" align="center">

                                <table  style="width:100%; " >
                                    <tr valign="top" >
                                        <td  width="100%" class="LargeText">
                                            <asp:Label ID="lblRoomType" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr valign="top" >
                                        <td  width="100%" class="SmallText">
                                            <br />
                                            <asp:Label ID="lblBranchAddress" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                            </td>                                          
                        </tr>
                        <tr valign="top" >
                            <td  width="100%" class="LargeTextDetails" colspan="2">
                                <hr />
                                Your Booking Details
                                <hr />
                            </td>
                        </tr>

                        <tr valign="top" >
                            <td  width="100%" class="SmallText" colspan="2">
                                Room Type: <asp:Label ID="lblRoomType2" 
                                    runat="server" Font-Bold="True"></asp:Label><br />
                                Maximum Occupancy: 
                                <asp:Label ID="lblMaximumOccupancy" runat="server" Font-Bold="True"></asp:Label><br />
                                Number of Room(s): 
                                <asp:Label ID="lblNumberOfRooms" runat="server" Font-Bold="True"></asp:Label><br />
                                Number of Adult(s): 
                                <asp:Label ID="lblNumberOfAdults" runat="server" Font-Bold="True"></asp:Label><br />
                                Check-In Date: <asp:Label ID="lblCheckInDate" runat="server" Font-Bold="True"></asp:Label><br />
                                Check-Out Date: 
                                <asp:Label ID="lblCheckOutDate" runat="server" Font-Bold="True"></asp:Label><br />
                                Number of Nights: 
                                <asp:Label ID="lblNumberOfNights" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>

                        <tr valign="top" >
                            <td  width="100%" class="LargeTextDetails" colspan="2">
                                <hr />
                                Your Payment Details
                                <hr />
                            </td>
                        </tr>

                        <tr valign="top" >
                            <td  width="100%" class="SmallText" colspan="2">
                                <table>
                                    <tr>
                                        <td align="left" width="200px">
                                            <asp:Label ID="Label6" runat="server" Text="Price for 1 night:"></asp:Label><br />
                                        </td>
                                        <td align="right" class="AmountText" width="200px">
                                            <asp:Label ID="lblPriceForOneNight" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="200px">
                                            <asp:Label ID="lblRoomsTimesNightsCaption" runat="server" ></asp:Label><br />
                                        </td>
                                        <td align="right" class="AmountText" width="200px">
                                            <asp:Label ID="lblRoomsTimesNightsAmount" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="200px" class="TotalAmountCaption">
                                            <asp:Label ID="Label7" runat="server" Text="Total Price"></asp:Label><br />
                                        </td>
                                        <td align="right" class="TotalAmountText" width="200px">
                                            <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>

                   </div>
                </div>
            </td>           
        </tr>
    </table>
    </div>
    </div>
    </form>
</body>
</html>
