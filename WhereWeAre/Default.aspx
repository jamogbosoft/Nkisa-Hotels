<%@ Page Title="Where we are!" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
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
                        <img src="../Photogallery/imgs/Slide4.jpg" alt="" />
                        <img src="../Photogallery/imgs/Slide2.jpg" alt="" />
                        <img src="../Photogallery/imgs/Slide1.jpg" alt="" />
                           <img src="../Photogallery/imgs/R51.jpg" alt="" />
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <br /><br />

    <table align="center">
        <tr>
            <td >
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" CssClass="RoomsAndServices">
                         
                         <h2>Where We Are</h2>
                         <br /><br /><br />
                         <table class="WhereWeAre">
                            <hr />
                            <tr valign="top">
                                <td >
                                    <h3><strong><span>ANNEX</span></strong></h3>
                                    Nkisa Hotels, <br />
                                    Opp. Shell Location (EPC) Ukwugba, <br />
                                    Egbema-Oguta Road, <br />
                                    Ohaji/Egbema LGA, <br />
                                    Imo State, <br />
                                    Nigeria. <br />
                                    Email:  <a href="mailto:support@nkisahotels.com">support@nkisahotels.com</a><br />
                                    Tel: +2348024532141<br /><br />
                        
                                </td>
                                <td width="100px"></td>
                                <td >
                                    <h3><strong><span>HEAD QUARTERS</span></strong></h3>   
                                    Nkisa Hotels, <br />          
                                    Opp. Mgbede Main Market, <br />
                                    Mgbede-Ebocha Road, <br />
                                    ONELGA, <br />
                                    Rivers State, <br />
                                    Nigeria. <br />
                                    Email: <a href="mailto:support@nkisahotels.com">support@nkisahotels.com</a><br />
                                    Tel: +2347082895327<br />
                                </td>
                            </tr>
                            
                            <tr>
                                <td colspan="3">
                                    <br /><br />
                                    <a href="#" onclick="window.open('http://www.facebook.com/nkisahotels/','Window1',
			                                    'menubar=no,width=430,height=500,toolbar=no,resizeable=yes,scrollbars=yes');">Facebook</a>
                                </td>
                            </tr>
                         </table> 
                         <hr />                  
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
          </tr>
    </table>
</asp:Content>
