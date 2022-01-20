<%@ Page Title="Scheduled Meetings" Language="C#" MasterPageFile="~/SiteAdminMessages.master" AutoEventWireup="true" CodeFile="ScheduledMeetings.aspx.cs" Inherits="ScheduledMeetings" EnableSessionState="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>


<asp:Content ID="HeaderContent" ContentPlaceHolderID="AdminHeadContent" Runat="Server">
	
    </asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminMainContent" Runat="Server">  

    <h1 >
        <span style="font-family: 'Agency FB'; font-size: xx-large; font-weight: bold; font-style: normal; font-variant: normal; color: #008080; text-align: left">Scheduled Meetings</span>
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/writting.png" />
    </h1>

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
                    style="border-style:None;border-collapse:collapse; width: 98%;">
                               
                    <tr class="bodyText"  height="100%" valign="top" align="center">
                        <td style="padding-left:10;padding-right:10;" align="center" valign="top">                               

                                            
                                <asp:GridView ID="GridViewScheduledMeetings" runat="server" AllowPaging="True"
                                    CaptionAlign="Top" CellPadding="3" GridLines="Horizontal" 
                                ShowHeaderWhenEmpty="True" Font-Names="Times New Roman" Font-Size="Small"
                                    style="margin-left: 0px" Width="892px" ShowFooter="True" 
                                    Font-Overline="False" Font-Strikeout="False" 
                                    BackColor="White" BorderColor="#E7E7FF" 
                                    BorderWidth="1px" 
                                    onpageindexchanging="GridViewScheduledMeetings_PageIndexChanging" 
                                    AutoGenerateColumns="False" 
                                    PageSize="25" 
                                    onselectedindexchanged="GridViewScheduledMeetings_SelectedIndexChanged" 
                                    BorderStyle="None" >
                                <AlternatingRowStyle BackColor="#F7F7F7" HorizontalAlign="Left" 
                                        VerticalAlign="Middle" Wrap="True" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                                    CommandName="Select" ImageUrl="~/Images/Buttons/ButtonDelete.jpg" 
                                                    onclick="ImageButtonDelete_Click" Text="Delete" />

                                                    <ajaxToolkit:ConfirmButtonExtender  ID="ConfirmDelete" 
                                                    ConfirmText="Are you sure you want to delete this message?" Enabled="True" runat="server" 
                                                    TargetControlID="ImageButton1"></ajaxToolkit:ConfirmButtonExtender>

                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="MeetingID" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TDT" FooterText="Received On" 
                                            HeaderText="Received On">
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="True" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Names" FooterText="Guest Name" 
                                            HeaderText="Guest Name" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Email" FooterText="Email" HeaderText="Email" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SDT" FooterText="Date &amp; Time" 
                                            HeaderText="Date &amp; Time" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Duration" FooterText="Duration" 
                                            HeaderText="Duration">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Capacity" FooterText="Capacity" 
                                            HeaderText="Capacity" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Comment" FooterText="Comment" HeaderText="Comment">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" Font-Bold="True" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" 
                                        ForeColor="#F7F7F7" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" 
                                        HorizontalAlign="Right" />
                                <RowStyle HorizontalAlign="Center" 
                                        VerticalAlign="Middle" BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#738A9C" ForeColor="#F7F7F7" 
                                        HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" />
                                <SortedAscendingCellStyle BackColor="#F4F4FD" HorizontalAlign="Left" 
                                        VerticalAlign="Middle" />
                                <SortedAscendingHeaderStyle BackColor="#5A4C9D" HorizontalAlign="Left" 
                                        VerticalAlign="Middle" />
                                <SortedDescendingCellStyle BackColor="#D8D8F0" HorizontalAlign="Left" 
                                        VerticalAlign="Middle" />
                                <SortedDescendingHeaderStyle BackColor="#3E3277" HorizontalAlign="Left" 
                                        VerticalAlign="Middle" />
                            </asp:GridView>                                           
                            <br/>
                        </td>
                    </tr>
                    <tr >
                        <td align="center">
                            <asp:Button ID="btnDeleteAll" runat="server" onclick="btnDeleteAll_Click" 
                                CssClass="submitbutton" Text="Delete All" Font-Italic="True" />
                                                       
                            <ajaxToolkit:ConfirmButtonExtender  ID="ConfirmDeleteAll" 
                                ConfirmText="Are you sure you want to DELETE ALL these messages?" Enabled="True" runat="server" 
                                 TargetControlID="btnDeleteAll"></ajaxToolkit:ConfirmButtonExtender>
                
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
    </asp:UpdatePanel>
    
</asp:Content>
