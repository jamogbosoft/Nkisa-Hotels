<%@ Page Title="Offers" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
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

                        <img src="../Photogallery/imgs/F1.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F2.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F3.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F4.jpg" alt="" /> 
                        <img src="../Photogallery/imgs/F5.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F6.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F7.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F8.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F9.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F10.jpg" alt="" /> 
                        <img src="../Photogallery/imgs/F11.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F12.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F13.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F14.jpg" alt="" /> 
                        <img src="../Photogallery/imgs/F15.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F16.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F17.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F18.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F19.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F20.jpg" alt="" /> 
                        <img src="../Photogallery/imgs/F21.jpg" alt="" />  
                        <img src="../Photogallery/imgs/F22.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F23.jpg" alt="" />    
                        <img src="../Photogallery/imgs/F24.jpg" alt="" /> 
                        <img src="../Photogallery/imgs/F25.jpg" alt="" />  
                       
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <br /><br />
    <table>
        <tr>
        <td width="20px"></td>
            <td style="text-align: justify">
                Whether you're planning a special occasion or simply need to unwind after a hectic workweek, make the most of your weekend and book a Bed & Breakfast package at one of our destinations.

                With special rates and breakfasts for two - from healthy to decadent - our Bed & Breakfast packages are the perfect way for you to relax and recharge. Book your weekend escape today.
                
            </td>

            <td width="20px"></td>
        </tr>
    
    </table>
</asp:Content>
