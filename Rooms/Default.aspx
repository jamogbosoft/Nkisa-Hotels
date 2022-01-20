<%@ Page Title="Our Rooms" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" %>

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
                       
                        <img src="../Photogallery/imgs/R1.jpg" alt="" />  
                        <img src="../Photogallery/imgs/R2.jpg" alt="" />  
                        <img src="../Photogallery/imgs/R3.jpg" alt="" />  
                        <img src="../Photogallery/imgs/R4.jpg" alt="" />  
                        <img src="../Photogallery/imgs/R5.jpg" alt="" />  
                        <img src="../Photogallery/imgs/R6.jpg" alt="" />  
                        <img src="../Photogallery/imgs/R7.jpg" alt="" />   
                        <img src="../Photogallery/imgs/R8.jpg" alt="" /> 
			            <img src="../Photogallery/imgs/R9.jpg" alt="" /> 
                        <img src="../Photogallery/imgs/R10.jpg" alt="" />    
                        <img src="../Photogallery/imgs/R11.jpg" alt="" />
			            <img src="../Photogallery/imgs/R12.jpg" alt="" />   
                        <img src="../Photogallery/imgs/R13.jpg" alt="" />
                        <img src="../Photogallery/imgs/R14.jpg" alt="" />        
                        <img src="../Photogallery/imgs/R15.jpg" alt="" />  
                        <img src="../Photogallery/imgs/R16.jpg" alt="" />  
                        <img src="../Photogallery/imgs/R17.jpg" alt="" />   
                        <img src="../Photogallery/imgs/R18.jpg" alt="" /> 
			            <img src="../Photogallery/imgs/R19.jpg" alt="" /> 
                        <img src="../Photogallery/imgs/R20.jpg" alt="" />    
                        <img src="../Photogallery/imgs/R21.jpg" alt="" />
			            <img src="../Photogallery/imgs/R22.jpg" alt="" />              
                                                                            
                    </div>
                </div>
            </td>
        </tr>
    </table>

    <br /><br />
    <table align="center" >
        <tr>
            <td >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" CssClass="RoomsAndServices">
                    <h2 >
                        Rooms & Services
                    </h2><br /><br />
                        <strong><span>BEDROOMS & ACCOMMODATION</span></strong> <br />
                        <br />
                        All our accommodation is non-smoking with light maple 
                        furniture, harmonizing decor and private bathrooms. Our bathrooms are nice and 
                        bright with ample space to manoeuvre.<br />
                        All hotel bedrooms offer the following facilities:<br />
                        <br />
                        &nbsp;&nbsp;&nbsp; * Audible Smoke Alarms<br />
                        &nbsp;&nbsp;&nbsp; * Safe Deposit Box in Room<br />
                        &nbsp;&nbsp;&nbsp; * Private Bathroom<br />
                        &nbsp;&nbsp;&nbsp; * Hospitality Tray<br />
                        &nbsp;&nbsp;&nbsp; * Direct Dial Telephone<br />
                        &nbsp;&nbsp;&nbsp; * Complimentary Toiletries<br />
                        &nbsp;&nbsp;&nbsp; * Small Fridge<br />
                        &nbsp;&nbsp;&nbsp; * Satellite/Cable Colour TV<br />
                        &nbsp;&nbsp;&nbsp; * Wi-Fi<br />
                        &nbsp;&nbsp;&nbsp; * Air-Conditioning<br />
                        <br />
                       
                        
                        Room Service is available from 6:00am until 10:00pm.

                        </asp:Panel>

        <ajaxToolkit:DropShadowExtender ID="DropShadowExtender1" runat="server"
            BehaviorID="DropShadowBehavior1"
            TargetControlID="Panel1"
            Width="20"
            Rounded="true"
            Radius="20"
            Opacity=".75"
            TrackPosition="true" />

      </ContentTemplate>
    </asp:UpdatePanel>
            </td>

            <td></td>
        </tr>    
    </table>

</asp:Content>
