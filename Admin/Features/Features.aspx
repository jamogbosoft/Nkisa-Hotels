<%@ Page Title="Room Features" Language="C#" MasterPageFile="~/SiteAdmin.master" AutoEventWireup="true" CodeFile="Features.aspx.cs" Inherits="Features" EnableSessionState="True" %>

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
            <table align="center">
                <tr align="center">
                    <td align="center">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/processing.gif" />
                    </td>
                </tr>
            </table>
        </ProgressTemplate>
    </asp:UpdateProgress>
   

   <table cellspacing="0" height="100%" cellpadding="4" rules="all"
                                   bordercolor="#CCDDEF" border="1" 
                                
              style="border-style:None;border-collapse:collapse; width: 100%;">
    <tr class="callOutStyle">
        <td  align="center" colspan="2">Add/Update Room Features</td>
    </tr>
    <tr>
				<td valign="top">
                    <table cellspacing="0" cellpadding="0" width="100%">
					                     
                    <tr>
						<td height="30px" >Room Feature:</td>
                                                
                         <td  >                         
                             <asp:TextBox ID="txtRoomFeatureName" runat="server" MaxLength="25" Width="300px" 
                                 ValidationGroup="Group1"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRoomFeatureName" 
	                            runat="server" ControlToValidate="txtRoomFeatureName" 
	                            ErrorMessage="Room Feature cannot be empty." ForeColor="Red" 
	                            SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>

                             <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtenderRoomFeatureName"
	                            TargetControlID="RequiredFieldValidatorRoomFeatureName"
	                            HighlightCssClass="validatorCalloutHighlight" />																	
									
                        </td>                         
                           				                            
                         <td align="left" >   
                                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Update" 
                                ValidationGroup="Group1" CssClass="submitbutton" Font-Italic="True" />   

                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;    

                              <asp:Button ID="btnCancel1" runat="server" CausesValidation="False" 
                                onclick="btnCancel_Click" Text="Back" CssClass="submitbutton" 
                                    Font-Italic="True" />    
                                             
                         </td>                   
					</tr>  
				</table></td>

               
			</tr>
		</table>
	
       <table cellspacing="0" height="100%" cellpadding="4" rules="all"
            bordercolor="#CCDDEF" border="1" 
            style="border-style:None;border-collapse:collapse; width: 100%;" 
             align="center">
                               
            <tr class="bodyText"  height="100%" valign="top" align="center">
                <td style="padding-left:10;padding-right:10;" align="center" valign="top">  

                                <asp:GridView ID="GridViewRoomFeatures" runat="server" AllowPaging="True" 
                                    CaptionAlign="Top" CellPadding="3" GridLines="None" 
                                ShowHeaderWhenEmpty="True" Font-Names="Times New Roman" Font-Size="Small" 
                                    onpageindexchanging="GridViewRoomFeatures_PageIndexChanging" 
                                    onselectedindexchanged="GridViewRoomFeatures_SelectedIndexChanged" 
                                    style="margin-left: 0px" Width="100%" ShowFooter="True" 
                                    Font-Overline="False" Font-Strikeout="False" AutoGenerateColumns="False" BackColor="White" 
                                                                        BorderColor="White" 
                                    BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" PageSize="20" >
                                <AlternatingRowStyle HorizontalAlign="Center" 
                                        VerticalAlign="Middle" Wrap="True" />
                                    <Columns>
                                       <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                                    CommandName="Select" ImageUrl="~/Images/Buttons/ButtonEdit.jpg" Text="Edit" />
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FeatureID" FooterText="FeatureID" 
                                            HeaderText="FeatureID" />
                                        <asp:BoundField DataField="FeatureName" FooterText="Feature" 
                                            HeaderText="Feature">
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
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
