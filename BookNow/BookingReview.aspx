<%@ Page Title="Booking Review" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BookingReview.aspx.cs" Inherits="BookingReview" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <link rel="stylesheet" href="../build/css/intlTelInput.css" type="text/css" id="Link1"  />
     <link rel="Stylesheet" href="../Styles/Payment.css"  type="text/css" id="Link2" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    

     <table>
        <tr valign="top">
            <td width="550px">   
             <div class="sidebar">
                <div class="sidebarheader">Booking Review</div>
                <div class="sidebarcontent">  
                    

 <!--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> -->
    
    <ww:ErrorDisplay runat="server" ID="Message1" Width="400px" />   

    <asp:Panel ID="panelPaymentReview" runat="server">
    <table width="100%">
        
        <tr><td align="left" colspan="3"
                    style="font-family: 'Arial Black'; font-size: x-large; color: #808080">
                1 Guest Information
        </td></tr>


        <tr>
            <td align="left">
                <asp:Label ID="Label1" runat="server" Text="Surname *"></asp:Label>
            </td>
            <td width="30px"></td>
            <td align="left">
                <asp:Label ID="Label2" runat="server" Text="First Name *" ></asp:Label>
            </td>
        </tr>        
        <tr>
            <td align="left">                
                <asp:TextBox ID="txtSurname" runat="server" Width="240px" Font-Size="Large" 
                    MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSurName" 
	                runat="server" ControlToValidate="txtSurName" 
	                ErrorMessage="Surname cannot be empty." ForeColor="Red" 
	                SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                <ajaxToolkit:FilteredTextBoxExtender
                    ID="FilteredTextBoxExtenderSurName"
                    runat="server"
                    TargetControlID="txtSurName" 
	                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-'" /> 
	            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidatorSurNameEx"
	                TargetControlID="RequiredFieldValidatorSurName"
	                HighlightCssClass="validatorCalloutHighlight" PopupPosition="BottomLeft" />      
                <br /> <br />         
            </td>
            <td width="30px">                
            </td>
            <td align="left">                
                <asp:TextBox ID="txtFirstName" runat="server" Width="240px" Font-Size="Large" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" 
	                runat="server" ControlToValidate="txtFirstName" 
	                ErrorMessage="First Name cannot be empty." ForeColor="Red" 
	                SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                <ajaxToolkit:FilteredTextBoxExtender
                    ID="FirstNameEx1"
                    runat="server"
                    TargetControlID="txtFirstName" 
	                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-'" /> 
	            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="FirstNameEx2"
	                TargetControlID="RequiredFieldValidatorFirstName"
	                HighlightCssClass="validatorCalloutHighlight" PopupPosition="BottomLeft" />
                 <br /> <br /> 
            </td>           
            
        </tr>        
        <tr>
            <td align="left">
                <asp:Label ID="Label3" runat="server" Text="Email Address *"></asp:Label>
            </td>
            <td width="30px"></td>
            <td align="left">
                <asp:Label ID="Label4" runat="server" Text="Phone Number *" ></asp:Label>
            </td>
        </tr>        
        <tr>
        <td align="left">
            <table>
                <tr>
                    <td>
                          <asp:TextBox ID="txtEmailAddress" runat="server" Width="240px" Font-Size="Large" 
                                MaxLength="30"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailAddress" 
	                        runat="server" ControlToValidate="txtEmailAddress" 
	                        ErrorMessage="Email Address cannot be empty." ForeColor="Red" 
	                        SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmailAddress" 
                            runat="server" ControlToValidate="txtEmailAddress" 
                            ErrorMessage="Invalid e-mail address." SetFocusOnError="True" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ForeColor="Red" ValidationGroup="Group1">*</asp:RegularExpressionValidator>
                             
                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="EmailAddressEx1"
	                        TargetControlID="RequiredFieldValidatorEmailAddress"
	                        HighlightCssClass="validatorCalloutHighlight"  PopupPosition="BottomLeft" />
                                   
                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="EmailAddressEx2"
                            TargetControlID="RegularExpressionValidatorEmailAddress"
                            HighlightCssClass="validatorCalloutHighlight" PopupPosition="BottomLeft" /> 
                    </td>
                </tr>
              </table>                      
                
            </td>
            <td width="30px">                
            </td>
            <td align="left">
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPhoneNumber" runat="server"  MaxLength="14" Width="240px" 
                                Font-Size="Large"></asp:TextBox>
                        </td>
                        <td>
                            <ajaxToolkit:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtenderPhoneNumber"
                                runat="server"
                                TargetControlID="txtPhoneNumber" FilterType="Custom" ValidChars="+0123456789" />

                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNumber" 
	                            runat="server" ControlToValidate="txtPhoneNumber" 
	                            ErrorMessage="Phone number cannot be empty." ForeColor="Red" 
	                            SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>  
                       
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhoneNumber" 
                                runat="server" ControlToValidate="txtPhoneNumber" 
                                ErrorMessage="Invalid Phone Number." SetFocusOnError="True" 
                                ValidationExpression="([+]([0-9]+))|([0-9]+)" 
                                ForeColor="Red" ValidationGroup="Group1">*</asp:RegularExpressionValidator>
                
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="PhoneNumberEx1"
	                            TargetControlID="RequiredFieldValidatorPhoneNumber"
	                            HighlightCssClass="validatorCalloutHighlight"  PopupPosition="BottomLeft" /> 
                
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="PhoneNumberEx2"
                                TargetControlID="RegularExpressionValidatorPhoneNumber"
                                HighlightCssClass="validatorCalloutHighlight" PopupPosition="BottomLeft" />   
                        </td>
                    </tr>
                </table>               
                                
            </td>                       
        </tr>

        <tr><td align="left" colspan="3"
                    style="font-family: 'Arial Black'; font-size: x-large; color: #808080">
                2 Your Payment Details
        </td></tr>

        <tr align="center">
            <td align="center" class="TotalAmount" colspan="3">
                <asp:Label runat="server" ID="lblYouWillPay" Text="You will pay">
                </asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td align="center" class="PaymentDetails" colspan="3">
                After registering your booking, you will receive payment instructions.
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <br />
                <asp:Label ID="Label5" runat="server" Text="Select your payment option *"></asp:Label>
            </td>            
        </tr>     
        <tr>
            <td align="center" colspan="3">                
               <asp:DropDownList ID="cboPaymentOptions" runat="server" Font-Bold="True" 
                    Font-Overline="False" Font-Size="Medium" Font-Strikeout="False"></asp:DropDownList>
               <br />
            </td>            
        </tr>
        <tr><td align="center"  colspan="3"
                    style="font-family: 'Arial Black'; font-size: x-large; color: #808080">                 
            <asp:Image ID="imgPaymentOptions" runat="server" ImageAlign="Middle" 
                        ImageUrl="~/Images/PaymentOptions/remita-payment-logo-horizonal.png" />
        </td></tr>
         <tr><td align="justify" colspan="3" style="font-size: x-small; color: #008080">                    
                    All payments require that you obtain an invoice that generates a reference number called the Remita Retrival Reference (RRR).
                    You can make payments online using Debit Cards, Internet Banking platform or any branch of commercial banks nationwide.
                    To use debit cards (MasterCard, Verve, VISA, UnionPay) follow the guide.
                    If you intend to make payments in the bank, Print the Invoice or copy the RRR and visit the nearest First Bank Plc of your choice. Write the RRR on the teller. Request to make payment for NKISA HOTELS using Remita. 
        </td></tr>        
        <!--
         <tr align="center"><td align="center" colspan="3" >
            <recaptcha:RecaptchaControl
                ID="myrecaptcha"
                runat="server"
                PublicKey="6LeCxAgUAAAAAA430BClIJhYUKwQWgB-mfjkET48"
                PrivateKey="6LeCxAgUAAAAAJwbfntC_rWnAr40Iv9ranjMJc1R"
                EnableTheming="True"                 
            />        
            <asp:Label ID="lblVerificationMessage" ForeColor="Red" runat="server" 
                 Font-Bold="True"></asp:Label>
        </td></tr>
        -->

        <!-- --------------------------------------------------------------------------------------------
        <tr align="center">
            <td align="center" colspan="3">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="False">
                    <ProgressTemplate>                       
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/processing.gif" />                                
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>             
        ------------------------------------------------------------------------------------------------- -->
        <tr>
            <td colspan="3">
                <table align="center">
                    <tr >
                        <td >
                            <asp:Button ID="btnBack" runat="server" Text="Back" 
                                CssClass="previousbuttonlarge" onclick="btnBack_Click" 
                                Font-Italic="True" />
                        </td>
                        <td width="50px"></td>
                        <td >
                            <asp:Button ID="btnBookNow" runat="server" Text="Book Now" 
                                onclick="btnBookNow_Click" CssClass="okbuttonlarge"  
                                ValidationGroup="Group1" Font-Italic="True"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>   
    </asp:Panel>

    <asp:Label ID="LRoomTypeID" runat="server" Text="0" Visible="False"></asp:Label>
    <asp:Label ID="LBranchName" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="LBranchAddress" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="LCheckInDate" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="LCheckOutDate" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="LNumberOfRooms" runat="server" Text="0" Visible="False"></asp:Label>
    <asp:Label ID="LNumberOfAdults" runat="server" Text="0" Visible="False"></asp:Label> 
    <asp:Label ID="LNumberOfNights" runat="server" Text="0" Visible="False"></asp:Label>  

    <asp:Label ID="LRoomTypeBranchID" runat="server" Text="0" Visible="False"></asp:Label>
    <asp:Label ID="LBranchID" runat="server" Text="0" Visible="False"></asp:Label>
    <asp:Label ID="LRoomTypeName" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="LPricePerNight" runat="server" Text="0" Visible="False"></asp:Label>
    <asp:Label ID="LBedSize" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="LMaxOccupancy" runat="server" Text="0" Visible="False"></asp:Label> 

    <asp:Label ID="LTotalAmount" runat="server" Text="0" Visible="False"></asp:Label>

  <script  type="text/javascript" src="../build/js/jquery-latest.min.js"></script>
    <script  type="text/javascript" src="../build/js/intlTelInput.js"></script>
    <script  type="text/javascript">
        $("#MainContent_MainContent_txtPhoneNumber").intlTelInput({
            initialCountry: "ng"
        });
    </script>

    
 <!--   </ContentTemplate>
    </asp:UpdatePanel>   -->
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
 
</asp:Content>

