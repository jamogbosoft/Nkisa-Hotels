<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="SlideThemes/8/js-image-slider4mainpage.css" rel="stylesheet" type="text/css" />
    <script src="SlideThemes/8/js-image-slider.js" type="text/javascript"></script>
    <link href="SlideThemes/8/tooltip.css" rel="stylesheet" type="text/css" />
    <!--<script src="SlideThemes/8/tooltip.js" type="text/javascript"></script> -->
    <link href="Styles/generic.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        imageSlider.thumbnailPreview(function (thumbIndex) { return "<img src='SlideImages/thumb" + (thumbIndex + 1) + ".jpg' style='width:70px;height:44px;' />"; });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table >
        <tr >
            <td id="Bking" class="Booking"  width="100%">
              
               <asp:UpdatePanel ID="UpdatePanel1a" runat="server">
                <ContentTemplate>
                    <ww:ErrorDisplay runat="server" ID="Message1" Width="180px" /> 
                    <table>
                        <tr>
                            <td align="center" colspan="2"  >
                                <asp:Label ID="Label1" runat="server" Text="Book Online" Font-Bold="True" 
                                    Font-Names="Agency FB" Font-Overline="False" Font-Size="X-Large" 
                                    Font-Underline="True" ForeColor="White"></asp:Label>     
                                    <br /><br /><br />                   
                            </td>   
                                         
                        </tr>
                    

                    <tr align="left" class="Maroon">
                            <td valign="top">
                                Branch:
                            </td>
                            <td>
                                <asp:DropDownList ID="cboBranch" runat="server">
                                </asp:DropDownList>
                             
                             <br />                                  
                            </td>
                        </tr>   
                         

                        <tr align="left" >
                            <td valign="top" class="Maroon">
                                Check-In:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCheckIn" runat="server" Width="120px" 
                                    ValidationGroup="Group1" AutoPostBack="True" 
                                    ontextchanged="txtCheckIn_TextChanged" 
                                    onKeyPress = "return false;" 
                                    onkeydown = "return false;"
                                    onCopy = "return false;"
                                    onCut = "return false;"                                    
                                    onPaste = "return false;"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="customCalendarExtenderCheckIn" 
                                        runat="server" TargetControlID="txtCheckIn"
									    Format="dd MMM. yyyy"  />

                               								
								<asp:RequiredFieldValidator ID="RequiredFieldValidatorCheckIn" 
									runat="server" ControlToValidate="txtCheckIn" 
																				
									    ErrorMessage="Check-In Date cannot be empty." ForeColor="Red" 
																				    SetFocusOnError="True" 
									    ValidationGroup="Group1" Display="Dynamic" CssClass="BlackColor">*</asp:RequiredFieldValidator>									
								

							    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidatorCheckInEx"
									TargetControlID="RequiredFieldValidatorCheckIn"
									HighlightCssClass="validatorCalloutHighlight" PopupPosition="Left"  />									
								 
                                  <ajaxToolkit:TextBoxWatermarkExtender ID="WatermarkExtendertxtCheckIn" runat="server"
                                        TargetControlID="txtCheckIn"
                                        WatermarkText="Check In Date"
                                        WatermarkCssClass="watermarked" />                   

                                    <br />
                                   
                            </td>
                        </tr>   
                         <tr align="left" >
                            <td valign="top" class="Maroon">
                                Check-Out:
                            </td>
                            <td class="BlackColor">
                                <asp:TextBox ID="txtCheckOut" runat="server" Width="120px" 
                                    ValidationGroup="Group1"
                                     onKeyPress = "return false;" 
                                    onkeydown = "return false;"
                                    onCopy = "return false;"
                                    onCut = "return false;"                                    
                                    onPaste = "return false;" AutoPostBack="True" 
                                    ontextchanged="txtCheckOut_TextChanged"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="customCalendarExtenderCheckOut" 
                                        runat="server" TargetControlID="txtCheckOut"
									    Format="dd MMM. yyyy" />

								
								<asp:RequiredFieldValidator ID="RequiredFieldValidatorCheckOut" 
									runat="server" ControlToValidate="txtCheckOut" 
																				
									    ErrorMessage="Check-Out Date cannot be empty." ForeColor="Red" 
																				    SetFocusOnError="True" 
									    ValidationGroup="Group1" Display="Dynamic">*</asp:RequiredFieldValidator>
																	

							    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidatorCheckOutEx"
									TargetControlID="RequiredFieldValidatorCheckOut"
									HighlightCssClass="validatorCalloutHighlight" PopupPosition="Left" />

                                <ajaxToolkit:TextBoxWatermarkExtender ID="WatermarkExtendertxtCheckOut" runat="server"
                                        TargetControlID="txtCheckOut"
                                        WatermarkText="Check Out Date"
                                        WatermarkCssClass="watermarked" />
                                                                   
                            </td>
                            
                        </tr>

                        <tr align="left" class="Maroon">                            
                        <td valign="top">
                                Nights:
                            </td>
                            <td>
                                <asp:Label ID="lblNumberOfNights" runat="server"></asp:Label>                            
                             <br />                                  
                            </td>
                        </tr> 
                       <tr align="left" class="Maroon">                            
                        <td valign="top">
                                Rooms:
                            </td>
                            <td>
                                <asp:DropDownList ID="cboNumberOfRooms" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="cboNumberOfRooms_SelectedIndexChanged">
                                </asp:DropDownList>
                             
                             <br />                                  
                            </td>
                        </tr> 
                       <tr align="left" class="Maroon">                            
                        <td valign="top">
                               Adults:
                            </td>
                            <td>
                                <asp:DropDownList ID="cboNumberOfAdults" runat="server">
                                </asp:DropDownList>
                             
                             <br />                                  
                            </td>
                        </tr>   
                   </table>
                                       
                </ContentTemplate>
              </asp:UpdatePanel> 

              <table align="right">
                <tr align="right" class="Maroon">                      
                    <td align="right">                                               
                        <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click"
                            ValidationGroup="Group1" CssClass="nextbuttonlarge" Font-Italic="True"/>
                    </td>
                </tr>              
              </table>                               
                      
            </td>
            <td width="1%"></td>
            <td align="center"  width="100%">
                <div id="sliderFrame">
                    <div id="slider">
                        <img src="Photogallery/imgs/Slide1.jpg" alt="" />
                        <img src="Photogallery/imgs/Slide2.jpg" alt="" />
                        <img src="Photogallery/imgs/R8.jpg" alt="" />
                        <img src="Photogallery/imgs/Slide4.jpg" alt="" />
                        <img src="Photogallery/imgs/R1.jpg" alt="" /> 
                        <img src="Photogallery/imgs/R25.jpg" alt="" />  
                        <img src="Photogallery/imgs/R5.jpg" alt="" /> 
                        <img src="Photogallery/imgs/R34.jpg" alt="" /> 
                        <img src="Photogallery/imgs/R9.jpg" alt="" /> 
                        <img src="Photogallery/imgs/R32.jpg" alt="" /> 
                        <img src="Photogallery/imgs/R11.jpg" alt="" /> 
                        <img src="Photogallery/imgs/R39.jpg" alt="" />                                              

                    </div>
                </div>
            </td>
        </tr>

    </table>
    
                  
    <br /><br />
    <table>
        <tr>
            <td>
                <h2>Welcome to Nkisa Hotels</h2>
                
            </td>
        </tr>
        <tr>
            <td>
                Welcome to Nkisa Hotels We invite you to experience everything we have to offer, from our contemporary settings to our nourishing and delicious dining options and more.
            </td>
        </tr>
    </table>
    <hr />

    <br /><br />
    <table>
        <tr valign="top" align="left">
           <td  width="300px">
            <table>
            <tr><td align="center">                
                <asp:Image ID="imgSearch" runat="server" 
                    ImageUrl="~/Images/png/girl_laptop1.png" Height="150px" />
              </td></tr>
            <tr><td align="center" 
                    style="font-family: Impact; font-size: x-large; color: #808080">
                1<br />
                <br />
                SEARCH
            </td></tr>
            <tr><td align="center" 
                    
                    style="font-family: 'TIMes New Roman', Times, serif; color: #333333; font-size: large; font-weight: bold;">
                <br />
                   Enter your destination in the search bar. Select the branch, check-in and 
                check-out dates, number of rooms and number of people, and Search.    
               
            </td></tr>
            </table>
                       
            </td>
            <td width="20px"></td>
                       <td  width="300px">
            <table>
            <tr><td align="center">
                <asp:Image ID="Image1" runat="server" 
                    ImageUrl="~/Images/png/guy_with_laptop.png" Height="150px" />
            </td></tr>
            <tr><td align="center" 
                    style="font-family: Impact; font-size: x-large; color: #808080">
                2<br />
                <br />
                COMPARE
            </td></tr>
            <tr><td align="center" 
                    
                    style="font-family: 'TIMes New Roman', Times, serif; color: #333333; font-size: large; font-weight: bold;">
                <br />
                    Browse room types, price or amenities. We always have the perfect stay for you at the best price.    
               
            </td></tr>
            </table>
                       
            </td>
            <td width="20px"></td>
                       <td  width="300px">
            <table>
            <tr><td align="center">
                <asp:Image ID="Image2" runat="server" 
                    ImageUrl="~/Images/png/man-running.png" Width="215px" Height="150px" />
            </td></tr>
            <tr><td align="center" 
                    style="font-family: Impact; font-size: x-large; color: #808080">
                3<br />
                <br />
                BOOK NOW or PAY LATER!
            </td></tr>
            <tr><td align="center" 
                    
                    style="font-family: 'TIMes New Roman', Times, serif; color: #333333; font-size: large; font-weight: bold;">
                <br />
                    Simply click on Book now. You can choose to pay online or later when you arrive at the hotel. Pack your bags and enjoy your stay.    
               
            </td></tr>
            </table>
                       
            </td>
        </tr>
        </table>
                
  
</asp:Content>
