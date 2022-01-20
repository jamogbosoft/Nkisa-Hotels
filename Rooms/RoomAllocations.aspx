<%@ Page Title="Room Allocation" Language="C#" MasterPageFile="~/SiteAdmin.master" AutoEventWireup="true" CodeFile="RoomAllocations.aspx.cs" Inherits="RoomAllocations" EnableSessionState="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="AdminHeadContent" Runat="Server">
	
    <link href="../../Styles/generic.css" rel="stylesheet" type="text/css" />
     
    <style type="text/css">
         .style51
        {
           /* width: 219px; */
        }
    </style>
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminMainContent" Runat="Server">  

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>

          <ww:ErrorDisplay runat="server" ID="Message1" />       
	    
<asp:UpdateProgress ID="UpdateProgress2" runat="server" 
        AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="False">
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
   
<table id="CreatNewOrUpdateInformation">
<tr valign="top">
<td valign="top">
    <table width="100%" valign="top" id="AppConfigTable">

        <tr valign="top">
            


<!--         ddd                      --> 

<td width="34%" valign="top">
                <table cellspacing="0" width="100%" cellpadding="0" border="0" 
                    style="height: 360px">
                    <tr height="49%" valign="top">
                        <td valign="top">



                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
<ContentTemplate>
    <table cellspacing="0" cellpadding="5" class="newlrbBorders" >
    <tr class="callOutStyle" valign="top">
        <td class="style40" align="center" valign="top">Bookings</td>
    </tr>
    <tr dir="ltr" valign="top" >
        <td class="style8" valign="top">

            <table cellspacing="0" cellpadding="0" 
                style="border-collapse:collapse; width: 429px;">
	<tr style="height:100%;" valign="top">
		<td class="style35" colspan="0" rowspan="0" valign="top">
            <table cellspacing="0" cellpadding="0" 

style="height:100%;width:100%; ">
			<tr valign="top">
				<td class="style9" valign="top">
                    <table cellspacing="0" cellpadding="0" style="height:65%; width:99%;">

                    <tr valign="top" align="right">
						    
                             <td  valign="top"> 
                            
                                <asp:DropDownList ID="cboNewBookings" runat="server" 
                                        Font-Overline="False" Font-Size="Small" AutoPostBack="True" 
                                    Height="25px" onselectedindexchanged="cboNewBookings_SelectedIndexChanged">
                                    <asp:ListItem>NON-ALLOCATED BOOKINGS</asp:ListItem>
                                    <asp:ListItem>ALLOCATED BOOKINGS</asp:ListItem>
                                    <asp:ListItem>EXPIRED BOOKINGS</asp:ListItem>
                                    </asp:DropDownList>       
                                           
                          </td>
                          
                             <td  valign="top" align="right">                                                                   
                                 <asp:TextBox ID="txtBookingID" runat="server"></asp:TextBox>
                                 <ajaxToolkit:TextBoxWatermarkExtender ID="WatermarkExtenderBookingID" runat="server"
                                        TargetControlID="txtBookingID"
                                        WatermarkText="Booking Ref."
                                        WatermarkCssClass="watermarked" />
                          </td>
                          <td  valign="top" align="right">                                                                   
                                 <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                     onclick="btnSearch_Click" />
                          </td>
                        
                          
					</tr>
                            
				</table></td>

			</tr>
		</table></td>
	</tr>

</table>
        </td>
    </tr>
</table> 

<!--                             -->

                <table cellspacing="0" cellpadding="0" border="0" 
                    
        style="border-style: None; border-collapse: collapse; width: 100%;">
                    <tbody style="border-style: None; border-collapse: collapse; width: 98%;" 
                        valign="top">
                    <tr height="49%" valign="top">
                        <td valign="top">
                            <table cellspacing="0" height="100%" cellpadding="4" rules="all"
                                   bordercolor="#CCDDEF" border="1" 
                                style="border-style:None;border-collapse:collapse; width: 99%;">
                                

                                <tr class="bodyText"  height="100%" valign="top">
                                    <td style="padding-left:10;padding-right:10;" valign="top">
                                        

                                <asp:GridView ID="GridViewBookings" runat="server" AllowPaging="True" 
                                    CaptionAlign="Top" CellPadding="0" 
                                ForeColor="#333333" GridLines="None" 
                                ShowHeaderWhenEmpty="True" Font-Names="Times New Roman" Font-Size="Small" 
                                    onpageindexchanging="GridViewBookings_PageIndexChanging" 
                                    onselectedindexchanged="GridViewBookings_SelectedIndexChanged" 
                                    style="margin-left: 0px" Width="435px" ShowFooter="True" 
                                    Font-Overline="False" Font-Strikeout="False" 
                                            AutoGenerateColumns="False" >
                                <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" Wrap="True" />
                                    <Columns>
                                         <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                                    CommandName="Select" ImageUrl="~/Images/Buttons/ButtonSelect1.jpg" Text="Select" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="BookingID" FooterText="BookingID" 
                                             HeaderText="BookingID">
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CustomersName" FooterText="Name" 
                                             HeaderText="Name">
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                         <HeaderStyle Wrap="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CheckInDate" FooterText="Check-In Date" 
                                            HeaderText="Check-In Date">
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CheckOutDate" FooterText="Check-Out Date" 
                                            HeaderText="Check-Out Date" />
                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                                        Height="40px" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" 
                                        Height="40px" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                            </asp:GridView>


                

                                    </td>
                                </tr>
                                </table>
                        </td>
                    </tr>

                </table>                
     
                 

      <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
        AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>
            <table align="center">
                <tr align="center" valign="top">
                    <td align="center" valign="top">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/processing.gif" />
                    </td>
                </tr>
            </table>
        </ProgressTemplate>
    </asp:UpdateProgress>

  </ContentTemplate>

  </asp:UpdatePanel>






                            
                            

                        </td>
                    </tr>

                </table>
            </td>


<!--        ddd                  -->
            
             

            <td width="34%" valign="top">
                <table cellspacing="0" width="100%" cellpadding="0" border="0" 
                    style="height: 360px">
                    <tr height="49%" valign="top">
                        <td valign="top">



                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
    <table cellspacing="0" cellpadding="5" class="newlrbBorders" >
    <tr class="callOutStyle" valign="top">
        <td class="style40" align="center" valign="top">Booking Details</td>
    </tr>


    <tr valign="top">
	<td class="style9" valign="top">
        <table cellspacing="0" cellpadding="0" style="height:65%; width:99%; font-weight: bold">
                
        <tr valign="top" align="center">
            <td  valign="top" align="center" colspan="2">
                <asp:Label ID="lblCustomerName" runat="server" Font-Bold="True" 
                    Font-Size="Medium" ForeColor="#003399"></asp:Label><br />
                <asp:Label ID="lblEmailAddress" runat="server" Font-Bold="True" 
                    Font-Size="Small" ForeColor="#003399"></asp:Label><br />
                <asp:Label ID="lblPhoneNumber" runat="server" Font-Bold="True" 
                    Font-Size="Small" ForeColor="#003399"></asp:Label><br /><br />
            </td>                            
        </tr>
        
        <tr valign="top">
			<td valign="top" width="150px">
                Booking Ref.:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblBookingID" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>
        <tr valign="top">
			<td  valign="top">
                Branch:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblBranch" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>    
        <tr valign="top">
			<td  valign="top">
                Room Type:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblRoomType" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr> 
        <tr valign="top">
			<td  valign="top">
                Price per Night:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblPricePerNight" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>    
        <tr valign="top">
			<td  valign="top">
                Booking Date:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblBookingDateAndTime" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>   
        <tr valign="top">
			<td  valign="top">
                Check-In Date:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblCheckInDate" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>   
        <tr valign="top">
			<td  valign="top">
                Check-Out Date:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblCheckOutDate" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>   
        <tr valign="top">
			<td  valign="top">
                Number of Night(s):
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblNumberOfNights" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>   
        <tr valign="top">
			<td  valign="top">
                Number of Room(s):
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblNumberOfRooms" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>   
        <tr valign="top">
			<td  valign="top">
                Number of Adult(s):
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblNumberOfAdults" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>   
        <tr valign="top">
			<td  valign="top">
                Total Amount:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblTotalAmount" runat="server" 
                    ForeColor="#006699" ></asp:Label>                                                                               
            </td>                          
		</tr>   
        <tr valign="top">
			<td  valign="top">
                Mode of Payment:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblModeOfPayment" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>           
        <tr valign="top">
			<td  valign="top">
                Payment Completed:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblPaymentCompleted" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr> 
         
        <tr valign="top">
			<td  valign="top">
                Booking Cancelled:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblBookingCancelled" runat="server"></asp:Label>                                                                               
            </td>                          
		</tr>  
        <tr valign="top" >
			<td  valign="top">
            <asp:Label ID="lblCancellationDateCaption" runat="server" Text="Cancellation Date:"></asp:Label> 
                
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblCancellationDate" runat="server" 
                    ForeColor="Red"></asp:Label>                                                                               
            </td>                          
		</tr>   
        <tr valign="top">
			<td  valign="top">
                Allocation Completed:
            </td>
            <td  valign="top"> 
                <asp:Label ID="lblRoomAllocationCompleted" runat="server" ></asp:Label>                                                                               
            </td>                          
		</tr>     
	</table></td>

    </tr>

    <tr class="callOutStyle" valign="top">
        <td class="style40" align="center" valign="top">Room Allocation Details</td>
    </tr>

    <tr dir="ltr" valign="top" >
        <td class="style8" valign="top">

            <table cellspacing="0" cellpadding="0" 
                style="border-collapse:collapse; width: 429px;">
	<tr style="height:100%;" valign="top">
		<td class="style35" colspan="0" rowspan="0" valign="top">
            <table cellspacing="0" cellpadding="0" style="height:100%;width:109%; ">
            
			<tr valign="top">
				<td class="style9" valign="top">
                    <table cellspacing="0" cellpadding="0" style="height:65%; width:90%;">
                                       
                    
                    <tr valign="top">
						<td align="left"  valign="top">
                            Branch: 
                         </td>                            
                             
                        <td class="style51" valign="top"> 
                            
                            <asp:DropDownList ID="cboBranch" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="cboBranch_SelectedIndexChanged">
                            </asp:DropDownList>
                          
                        </td>
					</tr>
                    <tr valign="top">
						<td align="left"  valign="top">
                            Room Type: 
                        </td>
                        <td class="style51" valign="top"> 
                                               
                            <asp:DropDownList ID="cboRoomType" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="cboRoomType_SelectedIndexChanged">
                            </asp:DropDownList>
                             
                                             
                        </td>
					</tr>
                        <tr valign="top">
						<td align="left"  valign="top">
                            Room Number:
                        </td>
                        <td class="style51" valign="top"> 
                                               
                            <asp:DropDownList ID="cboRoomNumber" runat="server">
                            </asp:DropDownList>
                                               
                        </td>
					</tr>  
                    <tr valign="top">
                        <td align="right" class="style37" colspan="2" valign="top">
                            &nbsp;</td>
                    </tr>                         
                    <tr valign="top">
                        <td></td>
                        <td align="center" class="style35"  valign="top">
                            <asp:Button ID="btnAllocate" runat="server" CssClass="okbuttonlarge" 
                                onclick="btnAllocate_Click" ValidationGroup="Group2" Font-Italic="True" 
                                Text="Allocate" />
                            </span>
                        </td>
                    </tr>
				</table></td>

			</tr>
		</table></td>
	</tr>

</table>
        </td>
    </tr>
</table> 

<!--                             -->

                

      <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
        AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>

         <table align="center">
                <tr align="center" valign="top">
                    <td align="center" valign="top">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/processing.gif" />
                    </td>
                </tr>
            </table>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
    <ww:ErrorDisplay runat="server" ID="Message2" Width="400px" /> 
    
    

                <table cellspacing="0" cellpadding="0" border="0" 
                    
        style="border-style: None; border-collapse: collapse; width: 100%;">
                    <tbody style="border-style: None; border-collapse: collapse; width: 98%;" 
                        valign="top">
                    <tr height="49%" valign="top">
                        <td valign="top">
                            <table cellspacing="0" height="100%" cellpadding="4" rules="all"
                                   bordercolor="#CCDDEF" border="1" 
                                style="border-style:None;border-collapse:collapse; width: 99%;">
                                
                                <tr class="bodyText"  height="100%" valign="top">
                                    <td style="padding-left:10;padding-right:10;" valign="top">
                                        <asp:GridView ID="GridViewRoomAllocations" runat="server" AllowPaging="True"
        CaptionAlign="Top" CellPadding="1" 
    ForeColor="Black" GridLines="None" 
    ShowHeaderWhenEmpty="True" Font-Names="Times New Roman" Font-Size="Small" 
        onselectedindexchanged="GridViewAllocations_SelectedIndexChanged" 
        style="margin-left: 0px" Width="433px" ShowFooter="True" 
        Font-Overline="False" Font-Strikeout="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                                            BorderWidth="1px" 
                                            onpageindexchanging="GridViewAllocations_PageIndexChanging" 
                                            AutoGenerateColumns="False" >
    <AlternatingRowStyle BackColor="PaleGoldenrod" HorizontalAlign="Center" 
            VerticalAlign="Middle" Wrap="True" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                        CommandName="Select" ImageUrl="~/Images/Buttons/ButtonDelete.jpg" 
                        onclick="ImageButton1_Click" Text="Delete" />

                        <ajaxToolkit:ConfirmButtonExtender  ID="ConfirmDelete" 
                            ConfirmText="Are you sure you want to delete this role?" Enabled="True" runat="server" 
                            TargetControlID="ImageButton1">
                        </ajaxToolkit:ConfirmButtonExtender>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="BookingID" FooterText="Booking Ref" 
                HeaderText="Booking Ref">
            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
            </asp:BoundField>
            <asp:BoundField DataField="RoomNumber" FooterText="Room Number" 
                HeaderText="Room Number">
            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="True" />
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="CheckedOut" FooterText="Checked Out" 
                HeaderText="Checked Out">
            <FooterStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
            <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="Tan" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" 
            HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
    <RowStyle HorizontalAlign="Center" 
            VerticalAlign="Middle" />
    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" 
            HorizontalAlign="Center" VerticalAlign="Middle" />
    <SortedAscendingCellStyle BackColor="#FAFAE7" HorizontalAlign="Center" 
            VerticalAlign="Middle" />
    <SortedAscendingHeaderStyle BackColor="#DAC09E" HorizontalAlign="Center" 
            VerticalAlign="Middle" />
    <SortedDescendingCellStyle BackColor="#E1DB9C" HorizontalAlign="Center" 
            VerticalAlign="Middle" />
    <SortedDescendingHeaderStyle BackColor="#C2A47B" HorizontalAlign="Center" 
            VerticalAlign="Middle" />
</asp:GridView>

                                    </td>
                                </tr>
                                </table>
                        </td>
                    </tr>

                </table>

       
  </ContentTemplate>

  </asp:UpdatePanel>






                            
                            

                        </td>
                    </tr>

                </table>
            </td>
            </tr> 
            </table>

            
            </td>
        </tr>

        

    </table>

    </ContentTemplate>
         
</asp:UpdatePanel>
    
    </asp:Content>
