<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentReview.aspx.cs" Inherits="PaymentReview" %>
<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Review</title>
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
     <table width="100%">
                
        <tr>
            <td align="left">
                <asp:Label ID="Label1" runat="server" Text="Surname:"></asp:Label>
            </td>
            <td align="left">                
                 <asp:Label ID="lblSurname" runat="server" ></asp:Label>           
            </td>
        </tr>      
        <tr>
            <td align="left">
                <asp:Label ID="Label2" runat="server" Text="First Name:" ></asp:Label>
            </td>                 
            <td align="left">                
                 <asp:Label ID="lblFirstName" runat="server" ></asp:Label>  
            </td>          
        </tr>  
        <tr>
            <td align="left">
                <asp:Label ID="Label8" runat="server" Text="Email Address:" ></asp:Label>
            </td>                 
            <td align="left">                
                 <asp:Label ID="lblEmailAddress" runat="server" ></asp:Label>  
            </td>          
        </tr> 
        <tr>
            <td align="left">
                <asp:Label ID="Label9" runat="server" Text="Phone Number:" ></asp:Label>
            </td>                 
            <td align="left">                
                 <asp:Label ID="lblPhoneNumber" runat="server" ></asp:Label>  
            </td>          
        </tr>  
        <tr>
            <td align="left">
                <asp:Label ID="Label3" runat="server" Text="Mode of Payment:" ></asp:Label>
            </td>                 
            <td align="left">                
                 <asp:Label ID="lblModeOfPayment" runat="server" ></asp:Label>  
            </td>          
        </tr>  

        <tr>
            <td align="left" class="BookingNumber">
                <asp:Label ID="Label4" runat="server" Text="Booking Ref.:" ></asp:Label>
            </td>                 
            <td align="left" class="BookingNumber">                
                 <asp:Label ID="lblBookingID" runat="server" ></asp:Label>  
            </td>          
        </tr> 
        
        <tr align="left">
            <td align="left" class="YouWillPay" colspan="2">
                <asp:Label runat="server" ID="lblYouWillPay" Text="You will pay">
                </asp:Label>
            </td>
        </tr>
        
        <tr><td align="left"  colspan="2">  
            <table>
                <tr valign="middle">
                    <td align="left"  > 
                        <asp:Image ID="imgPaymentOptions" runat="server" ImageAlign="Left"                         
                            ImageUrl="~/Images/PaymentOptions/remita-payment-logo-vertical.png" />
                    </td>
                    <td>
                        <table>
                            <tr valign="top">
                                <td align="justify" style="font-size: x-small; color: #008080">                    
                                    All payments require that you obtain an invoice that generates a reference number called the Remita Retrival Reference (RRR).
                                    You can make payments online using Debit Cards, Internet Banking platform or any branch of commercial banks nationwide.
                                    To use debit cards (MasterCard, Verve, VISA, UnionPay) follow the guide.
                                    If you intend to make payments in the bank, Print the Invoice or copy the RRR and visit the nearest First Bank Plc of your choice. Write the RRR on the teller. Request to make payment for NKISA HOTELS using Remita.<br /><br />
                                </td>
                            </tr>
                            <tr class="dontprint">                         
                                <td align="center" class="dontprint">                
                                    <asp:Button ID="btnGenerateRRR" runat="server" Text="Generate RRR" 
                                        PostBackUrl="~/BookNow/ProcessPayment.aspx" CssClass="ok2buttonmedium" 
                                        Font-Italic="True" />        
                                </td>                                
                            </tr>
                        </table>
                   </td>                        
                </tr>
            </table>             
        </td></tr>
        
        
     </table>   
     </asp:Panel>
        
    <asp:Label ID="LModeOfPaymentValue" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="LTotalAmount" runat="server" Visible="False"></asp:Label>
            
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
