<%@ Page Title="Offers" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../SlideThemes/8/js-image-slider.css" rel="stylesheet" type="text/css" />
    <script src="../SlideThemes/8/js-image-slider.js" type="text/javascript"></script>
    <link href="../SlideThemes/8/tooltip.css" rel="stylesheet" type="text/css" />
    <!--<script src="SlideThemes/8/tooltip.js" type="text/javascript"></script> -->
    <link href="../Styles/generic.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        imageSlider.thumbnailPreview(function (thumbIndex) { return "<img src='SlideImages/thumb" + (thumbIndex + 1) + ".jpg' style='width:70px;height:44px;' />"; });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table align="center">
        <tr align="center">           
            <td align="center">
                <div id="sliderFrame">
                    <div id="slider">
                        <img src="../Photogallery/imgs/E1.jpg" alt="Your big day is special to us, too. We can help you plan your day." />
                        <img src="../Photogallery/imgs/E2.jpg" alt="We can provide the ideal atmosphere and service for your wedding rehearsal, ceremony, reception and more." />
                        <img src="../Photogallery/imgs/E3.jpg" alt="Your big day is special to us, too. We can help you plan your day." />
                        <img src="../Photogallery/imgs/E4.jpg" alt="From the right setting to the right menu, we can help with every detail of your event." />
                        <img src="../Photogallery/imgs/E5.jpg" alt="Your big day is special to us, too. We can help you plan your day." />
                        <img src="../Photogallery/imgs/E6.jpg" alt="Your happiness is our happiness." />
                        <img src="../Photogallery/imgs/E7.jpg" alt="Your big day is special to us, too. We can help you plan your day." />
                        <img src="../Photogallery/imgs/E8.jpg" alt="Our professional atmosphere, helpful technology and planning tools can ensure your meeting is a success." />     
                        <img src="../Photogallery/imgs/E9.jpg" alt="Your big day is special to us, too. We can help you plan your day." />
                        <img src="../Photogallery/imgs/E10.jpg" alt="We understand planning successful events requires continued connections to your team and guests. Nkisa Hotels helps perfect your entire show." />     
                        <img src="../Photogallery/imgs/E11.jpg" alt="Your big day is special to us, too. We can help you plan your day." />
                        <img src="../Photogallery/imgs/E12.jpg" alt="From the right setting to the right menu, we can help with every detail of your event." />
                        <img src="../Photogallery/imgs/E13.jpg" alt="Our professional atmosphere, helpful technology and planning tools can ensure your meeting is a success." />                        
                        <img src="../Photogallery/imgs/E14.jpg" alt="From the right setting to the right menu, we can help with every detail of your event." />                                             

                    </div>
                </div>
            </td>
        </tr>
    </table>
    <br /><br /><br /><br />
    <table>
        <tr valign="top" align="left">
           <td  width="300px">
            <span style="font-family: 'Times New Roman', Times, serif; font-size: medium; font-weight: bold; text-align: center; vertical-align: top;">MEETINGS</span><br /><br />
                    Our professional atmosphere, helpful technology and planning tools can ensure your meeting is a success.    
               <br /><br /><br /><br />
               <asp:HyperLink ID="HyperLink6" NavigateUrl="~/Events/Meeting.aspx" runat="server" ForeColor="Red" Text="Schedule a meeting >>"></asp:HyperLink>
           
            </td>
            <td width="20px"></td>
            <td  width="300px">
                <span style="font-family: 'Times New Roman', Times, serif; font-size: medium; font-weight: bold; text-align: center; vertical-align: top;">SPECIAL EVENTS</span><br /><br />
                    From the right setting to the right menu, we can help with every detail of your event.      
               <br /><br /><br /><br /><br />
               <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Events/Events.aspx" runat="server" ForeColor="Red" Text="Plan an event >>"></asp:HyperLink>
           
            </td>
            <td width="20px"></td>
            <td width="300px">
                <span style="font-family: 'Times New Roman', Times, serif; font-size: medium; font-weight: bold; text-align: center; vertical-align: top;">WEDDINGS</span><br /><br />
                    Your big day is special to us, too. We can provide the ideal atmosphere and service for your wedding rehearsal, ceremony, reception and more.
               <br /><br /><br /><br />
               <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Events/Wedding.aspx" runat="server" ForeColor="Red" Text="Plan a wedding >>"></asp:HyperLink>
           
            </td>
        </tr>
    
    </table>
</asp:Content>
