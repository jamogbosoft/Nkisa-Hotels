<%@ Page Title="Room Types" Language="C#" MasterPageFile="~/SiteAdmin.master" AutoEventWireup="true" CodeFile="RoomTypes.aspx.cs" Inherits="RoomTypes" EnableSessionState="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="AdminHeadContent" Runat="Server">
	
    
	
    <style type="text/css">
        .style1
        {
            height: 38px;
        }
    </style>
	
    
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminMainContent" Runat="Server">  

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>

        <!--     -->
        <ww:ErrorDisplay runat="server" ID="Message1" />       
	    <!--   -->	

        <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
        AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="False">
        <ProgressTemplate>            
            <div align="center">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/processing.gif" />
            </div>                    
        </ProgressTemplate>
    </asp:UpdateProgress>
   

   <table cellspacing="0" height="100%" cellpadding="4" rules="all"
           bordercolor="#CCDDEF" border="1" style="border-style:None;border-collapse:collapse; width: 100%;">
                

    <tr class="callOutStyle">
        <td  align="center" colspan="2">Add/Update Room Types</td>
    </tr>
    <tr>
				<td valign="top" width="60%">
                    <table cellspacing="0" cellpadding="0" width="100%">
					 <tr>
						<td   valign="middle" width="30%" height="30px">Branch: <br /><br /> </td>
                        <td  width="70%">                             
                            <asp:DropDownList ID="cboBranch" runat="server" 
                                Font-Overline="False" Font-Size="Small" 
                                Height="24px" 
                                 ValidationGroup="Group1" AutoPostBack="True" 
                                onselectedindexchanged="cboBranch_SelectedIndexChanged">
                             </asp:DropDownList>      
                             
                             <br /><br />             
                        </td>                   
                        
                            
					</tr>
                    
                    <tr>
						<td height="30px" >
                            Room Type: <br /><br />
                        </td> 
                                                
                         <td  >                         
                             <asp:TextBox ID="txtRoomTypeName" runat="server" MaxLength="25" Width="200px" 
                                 ValidationGroup="Group1"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRoomTypeName" 
	                            runat="server" ControlToValidate="txtRoomTypeName" 
	                            ErrorMessage="Room Type cannot be empty." ForeColor="Red" 
	                            SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>

                             <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtenderRoomTypeName"
	                            TargetControlID="RequiredFieldValidatorRoomTypeName"
	                            HighlightCssClass="validatorCalloutHighlight" />																	
								
                               <br /><br />
                        </td>   

                        
                           
					</tr>                    
                     <tr>
						<td height="30px">Price Per Night: <br /><br /></td>
							
	                    <td >                         
                             <asp:TextBox ID="txtPricePerNight" runat="server" Width="60px" 
                                 ValidationGroup="Group1" MaxLength="6"></asp:TextBox>  

                            <ajaxToolkit:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtenderAmountPaid"
                                runat="server"
                                TargetControlID="txtPricePerNight" FilterType="Numbers" />

                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorPricePerNight" 
	                            runat="server" ControlToValidate="txtPricePerNight" 
	                            ErrorMessage="Price Per Night cannot be empty." ForeColor="Red" 
	                            SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>                             	
                                    
                              <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtenderPricePerNight"
	                            TargetControlID="RequiredFieldValidatorPricePerNight"
	                            HighlightCssClass="validatorCalloutHighlight" />    
                                
                                <br /><br />                                              
                        </td>                         
						                        
					</tr>  
                     <tr>
						<td height="30px">Bed Size: <br /><br /></td>
							
	                    <td  >                         
                             <asp:TextBox ID="txtBedSize" runat="server" Width="200px" ValidationGroup="Group1" 
                                 MaxLength="25"></asp:TextBox>  
                             
                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorBedSize" 
	                            runat="server" ControlToValidate="txtBedSize" 
	                            ErrorMessage="Bed Size cannot be empty." ForeColor="Red" 
	                            SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>                             	
                                    
                              <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtenderBedSize"
	                            TargetControlID="RequiredFieldValidatorBedSize"
	                            HighlightCssClass="validatorCalloutHighlight" />    
                                
                                <br /><br />                                                   
                        </td>                         
						                        
					</tr> 
                     <tr>
						<td height="30px">Max. Occupancy: <br /><br /></td>
							
	                    <td >                         
                                   <asp:DropDownList ID="cboMaxOccupancy" runat="server">
                                       <asp:ListItem>1</asp:ListItem>
                                       <asp:ListItem>2</asp:ListItem>
                                       <asp:ListItem>3</asp:ListItem>
                                       <asp:ListItem>4</asp:ListItem>
                                       <asp:ListItem>5</asp:ListItem>
                                       <asp:ListItem>6</asp:ListItem>
                                       <asp:ListItem>7</asp:ListItem>
                                       <asp:ListItem>8</asp:ListItem>
                                       <asp:ListItem>9</asp:ListItem>
                                       <asp:ListItem>10</asp:ListItem>
                         </asp:DropDownList>    
                         <br /><br />                                   
                        </td>      
                                            
						                        
					</tr> 
                      
                     <tr>							
	                    <td colspan="2" height="20px">                         
                                                                            
                        </td>                         
						                        
					</tr>             
                    <tr>				                            
                         <td colspan="2" align="center" >    
                              <asp:Button ID="btnCancel1" runat="server" CausesValidation="False" 
                                onclick="btnCancel_Click" Text="Cancel" CssClass="submitbutton" 
                                  Font-Italic="True" />    
                                
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;    
                                
                                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" 
                                ValidationGroup="Group1" CssClass="submitbutton" Font-Italic="True" />                 
                         </td>                   
					</tr>  
				</table></td>

                <td valign="top" width="40%">
                    <table>
                        <tr valign="top">
                            <td >                                                
                                <asp:Image ID="RoomTypeImage" runat="server" AlternateText="Room Type Image" 
                                    Height="120px" Width="300px" />                                                
                            </td>
						</tr>
                        <tr valign="top">
							<td class="style1" >
                                <asp:FileUpload ID="FileUploadRoomTypeImage" runat="server" TabIndex="19" /><br/>
								<small style="FONT-SIZE: 7pt; COLOR: darkgray">(Upload the room type image, not more than 500KB)</small><br />
							</td>
                        </tr>
                    
                    </table>
                </td>
			</tr>
		</table>
	
       <table cellspacing="0" height="100%" cellpadding="4" rules="all"
            bordercolor="#CCDDEF" border="1" 
            style="border-style:None;border-collapse:collapse; width: 100%;" 
             align="center">
                               
            <tr class="bodyText"  height="100%" valign="top" align="center">
                <td style="padding-left:10;padding-right:10;" align="center" valign="top">  

                                <asp:GridView ID="GridViewRoomTypes" runat="server" AllowPaging="True" 
                                    CaptionAlign="Top" CellPadding="3" GridLines="None" 
                                ShowHeaderWhenEmpty="True" Font-Names="Times New Roman" Font-Size="Small" 
                                    onpageindexchanging="GridViewRoomTypes_PageIndexChanging" 
                                    onselectedindexchanged="GridViewRoomTypes_SelectedIndexChanged" 
                                    style="margin-left: 0px" Width="100%" ShowFooter="True" 
                                    Font-Overline="False" Font-Strikeout="False" AutoGenerateColumns="False" BackColor="White" 
                                                                        BorderColor="White" 
                                    BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" >
                                <AlternatingRowStyle HorizontalAlign="Center" 
                                        VerticalAlign="Middle" Wrap="True" />
                                    <Columns>
                                       <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                                    CommandName="Select" ImageUrl="~/Images/Buttons/ButtonEdit.jpg" Text="Edit" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RoomTypeID" FooterText="RoomTypeID" 
                                            HeaderText="RoomTypeID" />
                                        <asp:BoundField DataField="BranchID" FooterText="BranchID" 
                                            HeaderText="BranchID">
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RoomTypeName" FooterText="Room Type" 
                                            HeaderText="Room Type">
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PricePerNight" FooterText="Price Per Night" 
                                            HeaderText="Price Per Night">
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BedSize" FooterText="Bed Size" 
                                            HeaderText="Bed Size" />
                                        <asp:BoundField DataField="MaxOccupancy" FooterText="Max. Occupancy" 
                                            HeaderText="Max. Occupancy" >
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#DEDFDE" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                                <SortedAscendingHeaderStyle BackColor="#594B9C" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                                <SortedDescendingHeaderStyle BackColor="#33276A" HorizontalAlign="Center" 
                                        VerticalAlign="Middle" />
                            </asp:GridView>
                        <br/>
                    </td>
                    
                </tr>
            </table>
           <asp:UpdateProgress ID="UpdateProgress5" runat="server" 
            AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <table align="center">
                    <tr align="center">
                        <td align="center">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/processing.gif" />
                        </td>
                    </tr>
                </table>
            </ProgressTemplate>
        </asp:UpdateProgress>

    </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="btnCancel1" />
             <asp:PostBackTrigger ControlID="btnSave" />
         </Triggers>
</asp:UpdatePanel>
    
    </asp:Content>
