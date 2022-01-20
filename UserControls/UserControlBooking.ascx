<%@ Control ClassName="MyUserControlBooking" Language="C#" AutoEventWireup="true" CodeFile="UserControlBooking.ascx.cs" Inherits="UserControls_UserControlBooking" %>
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
    .Blue
    {
        font-family: 'Times New Roman' , Times, serif;
        font-size: small;
        color: Blue;
        text-align: left;    
    }
        
    .BlueLarge
    {
        /*font-family: Bernard MT Condensed;*/
        font-family: 'Times New Roman' , Times, serif;
        font-size: x-large;
        color: #003366;
        text-align: left;
        font-weight: bold;
        cursor: pointer;             
    }
    
    .BlueLarge2
    {
        /*font-family: Bernard MT Condensed;*/
        font-family: 'Times New Roman' , Times, serif;
        font-size: x-large;
        color: #003366;
        text-align: left;
        font-weight: bold;    
        text-align:left;
        vertical-align:top;
    }
    
    .NomalSmall
    {
        font-family: 'Times New Roman' , Times, serif;
        font-size: small;
        text-align: left;
        
    }
    .AmountCaption
    {
        font-family: 'Times New Roman' , Times, serif;
        font-size: small;
        color: #000000;
        text-align: center;    
    }
    
    .Amount
    {
        font-family: 'Times New Roman' , Times, serif;
        font-size: medium;
        color: #333333;
        text-align: center;    
    }
    
    .TotalAmount
    {
        font-family: 'Times New Roman' , Times, serif;
        font-size: large;
        color: Green;
        text-align: center;
        font-weight: bold;
    }
    
    .Man
    {
        background-position: center center;
        background-image: url('../Images/png/man1.png');
        background-repeat: no-repeat;
        width: 26px;
        height: 60px;
    }
    
    .Check
    {
        background-position: center center;
        background-image: url('../Images/png/Check.png');
        background-repeat: no-repeat;
        width: 24px;
        height: 24px;
    }
    
    .Conditions
    {
        font-family: 'Times New Roman' , Times, serif;
        font-size: small;
        color:  Green;
        text-align: left;    
    }
    
    .Pointer
    {
        cursor: pointer;
    }
        
    .nextbuttonlarge
    {
        border-style: none;
        border-color: inherit;
        border-width: 0px;
        font-weight: bold;
        width: 105px;
        height: 37px;
        color : White ;
        background-image: url('../Images/Buttons/next.png');
        background-repeat: no-repeat;
        cursor: pointer;
        font-size: large;
        font-family: Times New Roman;
    }
    
</style>

    
    
<asp:Panel ID="PanelBookNow" runat="server"  CssClass="BookNowPanel">
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>     
           
            <table  style="background-image: url('../Images/media_bg4.jpg'); width:100%; background-repeat: repeat;" >
                <tr >
                    <td  width="100%" class="BlueLarge">
                        <asp:Label ID="lblRoomType" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            
            <asp:Panel ID="RoomType_AnimatedModalPopupPanel" runat="server" BorderStyle="Solid" 
                Style="display: none"  CssClass="modalPopupB">
                <table style="height: 100%; width: 100%">
                    <tr valign="top">
                        <td width="90%" align="left" valign="top">
                            <table>
                                <tr>                  
                                    <td height="200px" width="500px" valign="top">                                    
                                        <table>
                                            <tr>
                                                <td class="BlueLarge2">
                                                    <asp:Label ID="lblRoomType2" runat="server" Text=""></asp:Label>
                                                    <asp:Image ID="imgProperties" runat="server" 
                                                        Height="150"
                                                        Width="300" />                                                                                         
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="font-size: large; font-weight: bold; font-family: 'Times New Roman', Times, serif">
                                                    Bed Size:
                                                    <asp:Label ID="lblBedSize" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td style="font-size: large; font-weight: bold; font-family: 'Times New Roman', Times, serif">
                                                    Maximum Occupancy:
                                                    <asp:Label ID="lblMaximumOccupancy" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>        
                                        </table>
                                    </td>   
                                    <td width="40px"></td>                             
                                    <td  width="400px" valign="top" class="NomalSmall">                                    
                                        <asp:GridView ID="GridViewRoomFeatures" runat="server" AutoGenerateColumns="False" 
                                            CellPadding="1" ForeColor="#333333" GridLines="None" Font-Size="Small" 
                                            Width="144px">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Room Features" DataField="RoomFeatureName" />
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>                                         
                                    </td>
                                </tr>                             
                            </table>
                        </td>
                        <td width="10%" align="right" valign="top">
                            <asp:Button ID="CloseButton" runat="server" Text="X" />
                        </td>
                    </tr>                               
                </table>
            </asp:Panel>   

            <ajaxToolkit:ModalPopupExtender ID="RoomType_AnimatedModalPopupExtender1" runat="server"
                    CancelControlID="CloseButton" Enabled="True" PopupControlID="RoomType_AnimatedModalPopupPanel"
                    TargetControlID="lblRoomType">                
            </ajaxToolkit:ModalPopupExtender>

        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> 
             
            <ww:ErrorDisplay runat="server" ID="Message1" Width="400px" />     
		
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
		        AssociatedUpdatePanelID="UpdatePanel1">
		        <ProgressTemplate>
			        <table align="center">
				        <tr align="center">
					        <td align="center">
						        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/processing.gif" />					    
					        </td>
				        </tr>
			        </table>
		        </ProgressTemplate>
	        </asp:UpdateProgress>           
            

            <table style="background-image: url('../Images/media_bg4.jpg'); height: 140px; width:100%; background-repeat: repeat;" >
                    <tr >                  
                        <td height="130px" width="140px" align="center" class="Pointer">
                            <asp:Image ID="imgLogo" runat="server" 
                            Height="130px" ImageAlign="Middle"
                            Width="140px"/>
                        </td>                               

                        <td  width="200px" align="center">
                            <table >        
                                <tr>
                                    <td >
                                        <div align="center" class="Check"> </div>
                                    </td>       
               
                                    <td class="Conditions">
                                        <asp:Label ID="lblBookNowPolicy" runat="server" Text="Book now, pay later!"></asp:Label>    
                                    </td>    
                                    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtenderBookNowPolicy" 
                                        runat="server" TargetControlID="lblBookNowPolicy" 
                                        PopupControlID="PanelBookNowPolicy" PopupPosition="Top" 
                                        OffsetX="-50" OffsetY="-20" />                             
                                </tr>  
                                <tr>       
                                    <td class="Conditions" colspan="2"></td>                                 
                                </tr>
                                <tr>       
                                    <td class="Conditions" colspan="2"></td>                                 
                                </tr> 
                                <tr>
                                    <td >
                                        <div align="center" class="Check"> </div>
                                    </td>       
                     
                                    <td class="Conditions">
                                        <asp:Label ID="lblCancellationPolicy" runat="server" Text="Cancellation policy"></asp:Label>    
                                    </td>    
                                    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtenderCancellationPolicy" 
                                        runat="server" TargetControlID="lblCancellationPolicy" 
                                        PopupControlID="PanelCancellationPolicy" PopupPosition="Top" 
                                         OffsetX="-50" OffsetY="-20" />                        
                                </tr> 
                           </table>
                        </td>
                        <td  width="100px" align="center">
                        <table>
                            <tr>
                                 <td>
                                    <asp:Image ID="imgMan" runat="server"/>
                                </td>
                            </tr>
                        </table>
                        
                        </td>
                        <td valign="top" align="center" width="200px">
                            <table>
                                <tr>
                                    <td class="AmountCaption">
                                        <asp:Label ID="Label2" runat="server" Text="Price for 1 night"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Amount">
                                        <asp:Label ID="lblPriceforOneNight" runat="server" 
                                            Font-Strikeout="True" Font-Overline="False" Font-Underline="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr><td height="20px"></td></tr>
                                <tr>
                                    <td class="AmountCaption">
                                        <asp:Label ID="lblPriceforTotalNightCaption" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TotalAmount">
                                        <asp:Label ID="lblPriceforTotalNights" runat="server"></asp:Label>
                                    </td>
                                </tr>
                 
                            </table>
                        </td>
                        <td  width="200px" valign="top">
                            <table>
                               <tr align="left" class="Blue">                            
                                    <td valign="top">
                                        No. of Rooms:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboNumberOfRooms" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="cboNumberOfRooms_SelectedIndexChanged">
                                        </asp:DropDownList>                             
                                        <br /><br />                                                                    
                                   
                                    </td>
                                </tr> 
                                <tr align="left" class="Blue">                            
                                    <td valign="top">
                                        No. of Adults:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboNumberOfAdults" runat="server">
                                        </asp:DropDownList>
                             
                                     <br /> <br />                               
                                    </td>
                                </tr>                                      
                                <tr align="left" class="Blue">                      
                                    <td align="right" colspan="2">
                                        <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click"
                                            CssClass="nextbuttonlarge" Font-Italic="True"/>
                                    </td>
                                </tr>                
                            </table>
                        </td>                               
                    </tr>
            </table>
            
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

            <ajaxToolkit:ModalPopupExtender ID="imgLogo_AnimatedModalPopupExtender1" runat="server"
                    CancelControlID="CloseButton" Enabled="True" PopupControlID="RoomType_AnimatedModalPopupPanel"
                    TargetControlID="imgLogo">                
            </ajaxToolkit:ModalPopupExtender> 

       </ContentTemplate>
    </asp:UpdatePanel>
       
</asp:Panel>


<asp:Panel ID="PanelBookNowPolicy" runat="server"
    Style="display: none"  CssClass="dropShadowPanel4Policy">
    <table style="height: 100%; width: 100%">             
        <tr valign="top">
            <td width="100%" align="left" valign="top">
                <asp:Label ID="lblBookNowPolicyText" runat="server"></asp:Label>
            </td>                    
        </tr>                
    </table>
</asp:Panel>

<asp:Panel ID="PanelCancellationPolicy" runat="server"
    Style="display: none"  CssClass="dropShadowPanel4Policy">
    <table style="height: 100%; width: 100%">
        <tr valign="top">
            <td width="100%" align="left" valign="top">
                <asp:Label ID="lblCancellationPolicyText" runat="server"></asp:Label>
            </td>                    
        </tr>                
    </table>
</asp:Panel>


<ajaxToolkit:DropShadowExtender ID="DropShadowExtenderBookNowPolicy" runat="server"
        TargetControlID="PanelBookNowPolicy"
        Width="5"
        Rounded="true"
        Radius="6"
        Opacity=".75" />
    
<ajaxToolkit:DropShadowExtender ID="DropShadowExtenderCancellationPolicy" runat="server"
        TargetControlID="PanelCancellationPolicy"
        Width="5"
        Rounded="true"
        Radius="6"
        Opacity=".75" />

