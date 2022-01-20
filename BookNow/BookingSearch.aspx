<%@ Page Title="Book Now" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="True" CodeFile="BookingSearch.aspx.cs" Inherits="BookNow_BookingSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>

<%@ Register src="../UserControls/UserControlBookingHeader.ascx" tagname="ControlBookingHeader" tagprefix="uc1" %>
<%@ Register src="../UserControls/UserControlBooking.ascx" tagname="ControlBooking" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   
     
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 
        
        <ww:ErrorDisplay runat="server" ID="Message1" Width="400px" />    

        <asp:PlaceHolder ID="phControlBookingHeader" runat="server">
            <uc1:ControlBookingHeader ID="ControlBookingHeader1" runat="server" Visible="True"/> 
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="phControlBooking" runat="server"> 
            <uc2:ControlBooking ID="ControlBooking1" runat="server" Visible="False"/>       
            <uc2:ControlBooking ID="ControlBooking2" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking3" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking4" runat="server" Visible="False"/>         
            <uc2:ControlBooking ID="ControlBooking5" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking6" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking7" runat="server" Visible="False"/>         
            <uc2:ControlBooking ID="ControlBooking8" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking9" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking10" runat="server" Visible="False"/>         
            <uc2:ControlBooking ID="ControlBooking11" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking12" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking13" runat="server" Visible="False"/>         
            <uc2:ControlBooking ID="ControlBooking14" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking15" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking16" runat="server" Visible="False"/>         
            <uc2:ControlBooking ID="ControlBooking17" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking18" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking19" runat="server" Visible="False"/>         
            <uc2:ControlBooking ID="ControlBooking20" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking21" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking22" runat="server" Visible="False"/>         
            <uc2:ControlBooking ID="ControlBooking23" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking24" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking25" runat="server" Visible="False"/>         
            <uc2:ControlBooking ID="ControlBooking26" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking27" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking28" runat="server" Visible="False"/>         
            <uc2:ControlBooking ID="ControlBooking29" runat="server" Visible="False"/>
            <uc2:ControlBooking ID="ControlBooking30" runat="server" Visible="False"/>
        </asp:PlaceHolder>  

      </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>

