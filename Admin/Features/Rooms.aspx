<%@ Page Title="Rooms" Language="C#" MasterPageFile="~/SiteAdmin.master" AutoEventWireup="true" CodeFile="Rooms.aspx.cs" Inherits="Rooms" EnableSessionState="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="AdminHeadContent" Runat="Server">
	
    <link href="../../Styles/generic.css" rel="stylesheet" type="text/css" />

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

<tr valign="top">
<td valign="top" colspan="2">
    <table width="100%" valign="top" id="AppConfigTable">

        <tr valign="top">
            


<!--         ddd                      --> 

<td width="24%" valign="top">
    <table cellspacing="0" width="100%" cellpadding="0" border="0" 
        style="height: 360px">
        <tr height="49%" valign="top">
            <td valign="top">
            
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>

                <table cellspacing="0" cellpadding="0" border="0" style="border-style: None; border-collapse: collapse; width: 100%;">
                    <tbody style="border-style: None; border-collapse: collapse; width: 98%;" 
                        valign="top">
                    <tr height="49%" valign="top">
                        <td valign="top">
                            <table cellspacing="0" height="100%" cellpadding="4" rules="all"
                                   bordercolor="#CCDDEF" border="1" 
                                style="border-style:None;border-collapse:collapse; width: 99%;">
                                
                                <tr class="callOutStyle" valign="top">
                                    <td class="style40" align="center" valign="top" colspan="2">Room Types</td>
                                </tr>

                                <tr>
	                                <td   valign="middle" height="30px">Branch:</td>
                                    <td  >                             
                                        <asp:DropDownList ID="cboBranch" runat="server" 
                                            Font-Overline="False" Font-Size="Small" 
                                            Height="24px" 
                                                ValidationGroup="Group1" AutoPostBack="True" 
                                            onselectedindexchanged="cboBranch_SelectedIndexChanged">
                                            </asp:DropDownList>                   
                                    </td>                 
                                </tr>
                                <tr class="bodyText"  height="100%" valign="top">
                                    <td style="padding-left:10;padding-right:10;" valign="top" colspan="2">
                                        

                                <asp:GridView ID="GridViewRoomTypes" runat="server" AllowPaging="True" 
                                    CaptionAlign="Top" CellPadding="0" 
                                ForeColor="#333333" GridLines="None" 
                                ShowHeaderWhenEmpty="True" Font-Names="Times New Roman" Font-Size="Small" 
                                    onpageindexchanging="GridViewRoomTypes_PageIndexChanging" 
                                    onselectedindexchanged="GridViewRoomTypes_SelectedIndexChanged" 
                                    style="margin-left: 0px" Width="435px" ShowFooter="True" 
                                    Font-Overline="False" Font-Strikeout="False" PageSize="15" 
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
                                        <asp:BoundField DataField="RoomTypeID" FooterText="Room Type ID" 
                                             HeaderText="Room Type ID">
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="BranchID" FooterText="Branch ID" 
                                             HeaderText="Branch ID" />
                                         <asp:BoundField DataField="RoomTypeName" FooterText="Room Type" 
                                             HeaderText="Room Type" >
                                         <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                         <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                         <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                         </asp:BoundField>
                                         <asp:BoundField DataField="PricePerNight" FooterText="Price Per Night" 
                                             HeaderText="Price Per Night" />
                                         <asp:BoundField DataField="MaxOccupancy" FooterText="Max Occupancy" 
                                             HeaderText="Max Occupancy" />
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
    <Triggers>
        <asp:PostBackTrigger ControlID="btnCancel" />
    </Triggers>
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
                        <td class="style40" align="center" valign="top" colspan="2">Rooms</td>
                    </tr>

                    <tr valign="top" align="center">
	    <td  valign="top" align="center">
            <asp:Label ID="lblRoomType" runat="server" Font-Bold="True" 
                Font-Size="Medium" ForeColor="#003399"></asp:Label><br />                
         </td>
    </tr>
        
    <tr  valign="top" >
        <td  valign="top">

            <table cellspacing="0" cellpadding="0" 
                style="border-collapse:collapse; width: 429px;">
	<tr style="height:100%;" valign="top">
		<td class="style35" colspan="0" rowspan="0" valign="top">
            <table cellspacing="0" cellpadding="0" style="height:100%;width:100%; ">
        <tr valign="top">
			<td align="right">
                <asp:Label ID="Label2" runat="server" Text="Room Number:" Font-Bold="True"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList
                    ID="cboRoomNumbers" runat="server">
                </asp:DropDownList>
             </td>
             <td align="left">
                <asp:ImageButton ID="ImageButtonEditFeatures" runat="server" 
                     CausesValidation="False" ImageUrl="~/Images/Buttons/ButtonEdit.jpg" Text="Edit" 
                     onclick="ImageButtonEditFeatures_Click" />
            </td>
		</tr>

                
        <tr valign="top">
            <td align="right"  colspan="3" valign="top">
                &nbsp;</td>
        </tr>                         
                <tr valign="top">
                    <td align="center" class="style35" colspan="3" valign="top">
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                            CssClass="submitbutton" onclick="btnCancel_Click" Text="Cancel" 
                            Font-Italic="True" />
                        <span class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnUpdate" runat="server" CssClass="submitbutton" 
                            onclick="btnUpdate_Click" ValidationGroup="Group2" Text="Add" 
                            Font-Italic="True" />
                        </span>
                    </td>
                </tr>
		</table></td>
	</tr>

</table>
        </td>
    </tr>
</table> 

     
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
                                    <td style="padding-left:10;padding-right:10;" valign="top" >
                                        <asp:GridView ID="GridViewRooms" runat="server" AllowPaging="True"
        CaptionAlign="Top" CellPadding="1" 
    ForeColor="Black" GridLines="None" 
    ShowHeaderWhenEmpty="True" Font-Names="Times New Roman" Font-Size="Small" 
        onselectedindexchanged="GridViewRooms_SelectedIndexChanged" 
        style="margin-left: 0px" Width="433px" ShowFooter="True" 
        Font-Overline="False" Font-Strikeout="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                                            BorderWidth="1px" 
                                            onpageindexchanging="GridViewRooms_PageIndexChanging" 
                                            AutoGenerateColumns="False" PageSize="15" >
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
            <asp:BoundField DataField="BranchID" FooterText="BranchID" 
                HeaderText="BranchID">
            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
            </asp:BoundField>
            <asp:BoundField DataField="RoomTypeID" FooterText="RoomTypeID" 
                HeaderText="RoomTypeID">
            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="True" />
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="RoomTypeName" FooterText="Room Type" 
                HeaderText="Room Type" >
            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="RoomNumber" FooterText="RoomNumber" 
                HeaderText="RoomNumber" >
            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
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
    <Triggers>
        <asp:PostBackTrigger ControlID="btnCancel" />
        <asp:PostBackTrigger ControlID="btnUpdate" />
    </Triggers>
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
