<%@ Page Title="Branches" Language="C#" MasterPageFile="~/SiteAdmin.master" AutoEventWireup="true" CodeFile="Branches.aspx.cs" Inherits="Branches" EnableSessionState="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="AdminHeadContent" Runat="Server">
	
    <style type="text/css">
         .style51
        {
            height:30px;
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
   
<table id="CreatNewOrUpdateInformation">
<tr>
<td>
    <table width="100%" valign="top" id="AppConfigTable">

        <tr>
            <td valign="top" colspan="1" rowspan="1" >

        
    <table cellspacing="0" cellpadding="5" class="newlrbBorders" >
    <tr class="callOutStyle">
        <td class="style40" align="center">Update Branch</td>
    </tr>
    <tr dir="ltr" valign="top" >
        <td class="style8">

            <table cellspacing="0" cellpadding="0" 
                style="border-collapse:collapse; width: 428px;">
	<tr style="height:100%;">
		<td class="style35" colspan="0" rowspan="0">
            <table cellspacing="0" cellpadding="0" 

style="height:100%;width:112%; border-collapse:collapse; margin-top: 0px;">
			<tr>
				<td class="style9" valign="top">
                    <table cellspacing="0" cellpadding="0" 
                        style="height:90%; width:90%; margin-right: 1px;">
					    <tr>
						<td align="left"  valign="middle">
                            Branch: <br /><br />
                        </td>
                        <td class="style51" >                             

                                <asp:TextBox ID="txtBranch" runat="server" MaxLength="40" 
                                    ValidationGroup="Group1" Width="300px"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBranch" 
	                                                runat="server" ControlToValidate="txtBranch" 
	                                                ErrorMessage="Branch cannot be empty." ForeColor="Red" 
	                                                SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                                                
                            <br /><br />
                        </td>
					</tr>
                    
                   <tr>
						<td align="left"  valign="middle">
                            Address:</td><td class="style51" > 
                            

                                <asp:TextBox ID="txtAddress" runat="server" MaxLength="120" 
                                    ValidationGroup="Group1" Width="300px"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" 
	                                                runat="server" ControlToValidate="txtAddress" 
	                                                ErrorMessage="Address cannot be empty." ForeColor="Red" 
	                                                SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                                                
                 
                                     </td>
					</tr>

                        <caption>
                            &nbsp;&nbsp;
                            <tr>
                                <td align="right" class="style37" colspan="2" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <caption>
                                &nbsp;&nbsp;
                                <tr>
                                    <td align="center" class="style35" colspan="2" valign="top">
                                        <asp:Button ID="btnCancel1" runat="server" CausesValidation="False" 
                                            onclick="btnCancel_Click" Text="Cancel" CssClass="submitbutton" 
                                            Font-Italic="True" />
                                        <span class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" 
                                            ValidationGroup="Group1" CssClass="submitbutton" Font-Italic="True" />
                                        </span>
                                    </td>
                                </tr>
                            </caption>
                        </caption>
				</table></td>

			</tr>
		</table></td>
	</tr>

</table>
        </td>
    </tr>
</table> 


<!--                          -->
            </td>
             

            <td width="34%" valign="top">
                <table cellspacing="0" width="100%" cellpadding="0" border="0" 
                    style="height: 360px">
                    <tr height="49%">
                        <td>
                            <table cellspacing="0" height="100%" cellpadding="4" rules="all"
                                   bordercolor="#CCDDEF" border="1" 
                                style="border-style:None;border-collapse:collapse; width: 98%;">
                                <tr class="callOutStyle">
                                    <td style="padding-left:10;padding-right:10;" align="center" class="style40">
                                        Branches</td>
                                </tr>

                                <tr class="bodyText"  height="100%" valign="top" align="center">
                                    <td style="padding-left:10;padding-right:10;" align="center" valign="top">
    <asp:GridView ID="GridViewBranches" runat="server" AllowPaging="True" 
        CaptionAlign="Top" CellPadding="0" 
    ForeColor="#333333" GridLines="None" 
    ShowHeaderWhenEmpty="True" Font-Names="Times New Roman" Font-Size="Small" 
        onpageindexchanging="GridViewBranches_PageIndexChanging" 
        onselectedindexchanged="GridViewBranches_SelectedIndexChanged" 
        style="margin-left: 0px" Width="449px" ShowFooter="True" 
        Font-Overline="False" Font-Strikeout="False" AutoGenerateColumns="False" >
    <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" 
            VerticalAlign="Middle" Wrap="True" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                        CommandName="Select" ImageUrl="~/Images/Buttons/ButtonSelect1.jpg" Text="Select" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="BranchName" HeaderText="Branch" FooterText="Branch" >
            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="BranchID" HeaderText="BranchID" 
                FooterText="BranchID" />
            <asp:BoundField DataField="Address" FooterText="Address" HeaderText="Address">
            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
            HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
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


                        </td>
                    </tr>

                </table>
            </td>
            </tr> 
            </table>

            
            </td>
        </tr>

        <tr>
            <td align="right" class="style15" valign="bottom">
                <table align="right" width="" height="" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            
                            &nbsp;</td>
                    </tr>
                </table>
            </td>

        </tr>
        <tr>
            <td class="bottomRow" height="31" valign="top">
            </td>
        </tr>

    </table>

    </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="btnCancel1" />
         </Triggers>
</asp:UpdatePanel>
    
    </asp:Content>
