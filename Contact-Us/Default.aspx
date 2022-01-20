<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Contact_Us_ContactUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script language="javascript" type="text/javascript">
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div id="fb-root"></div>

    <h1 >
        <span style="font-family: 'Agency FB'; font-size: xx-large; font-weight: bold; font-style: normal; font-variant: normal; color: #008080; text-align: left">Contact Us</span>
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/writting.png" />
    </h1>
    <ul>
        <li><span class="ContactUsIL"><strong>Do you need information on booking a room?</strong></span></li>
        <li><span class="ContactUsIL"><strong>Do you have any comments about our website? </strong></span></li>
        <li><span class="ContactUsIL"><strong>Do you want to send a personal note to us?</strong></span></li>
        <li><span class="ContactUsIL"><strong>Whatever the reason, we want to hear from you.</strong></span></li>
    </ul>
    <p>
        <span class="ContactUsILFill"><strong>
        <span >Fill out the form below or contact:</span></strong></span>
    </p>
    <p >
        <span class="ContactUsIL">
            The Manager,<br />
            Nkisa Hotels, <br />
            Opp. Shell Location (EPC) Ukwugba, <br />
            Ohaji/Egbema LGA, <br />
            Imo State, <br />
            Nigeria. <br />
            Tel: +2348024532141<br /><br />
            <strong>or send us a personal note on</strong>
        </span>
    </p>
    <p >
        <a href="mailto:support@nkisahotels.com" 
            title="Click here to send us a personal note">
        <span class="ContactUsIL">
        <strong><span style="font-family: times new roman,times;">
        <span style="color: rgb(255,0, 100);">support@nkisahotels.com</span></span></strong></span></a>
    </p>
    

      <table >
        <tr>
            <td>           
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
    
                        <ww:ErrorDisplay runat="server" ID="Message1" Width="400px" />     

                      <asp:Panel ID="Panel1" runat="server" CssClass="dropShadowPanel">
                            <div style="padding:10px">  
                                <table>
                        <tr>
                            <td width="230px" class="Maroon">
                                <asp:Label ID="Label1" runat="server" Text="Surname:"></asp:Label>
                                    <br />
                            </td>  
                            <td style="color: #FF0000">*</td>      
                            <td colspan="2">
                                <asp:TextBox ID="txtSurname" runat="server" Width="300px" 
                                    CssClass="TextBoxWater" MaxLength="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSurName" 
	                                    runat="server" ControlToValidate="txtSurName" 
	                                    ErrorMessage="Surname cannot be empty." ForeColor="Red" 
	                                    SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:FilteredTextBoxExtender
                                        ID="FilteredTextBoxExtenderSurName"
                                        runat="server"
                                        TargetControlID="txtSurName" 
	                                    ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" /> 
	                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidatorSurNameEx"
	                                    TargetControlID="RequiredFieldValidatorSurName"
	                                    HighlightCssClass="validatorCalloutHighlight" />
                                <br />
                            </td>
            
                        </tr>
                        <tr>
                            <td width="230px" class="Maroon">
                                <asp:Label ID="Label2" runat="server" Text="First Name:"></asp:Label>
                                    <br />
                            </td>  
                            <td style="color: #FF0000">*</td>      
                            <td colspan="2">
                                <asp:TextBox ID="txtFirstName" runat="server" Width="300px" 
                                    CssClass="TextBoxWater" MaxLength="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" 
	                                    runat="server" ControlToValidate="txtFirstName" 
	                                    ErrorMessage="First Name cannot be empty." ForeColor="Red" 
	                                    SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:FilteredTextBoxExtender
                                        ID="FilteredTextBoxExtenderFirstName"
                                        runat="server"
                                        TargetControlID="txtFirstName" 
	                                    ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" /> 
	                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidatorFirstNameEx"
	                                    TargetControlID="RequiredFieldValidatorFirstName"
	                                    HighlightCssClass="validatorCalloutHighlight" />
                                <br />
                            </td>
                        </tr>
        
                        <tr>
                            <td width="230px" class="Maroon">
                                <asp:Label ID="Label3" runat="server" Text="Email Address:"></asp:Label>
                                    <br />
                            </td>  
                            <td style="color: #FF0000">*</td>      
                            <td colspan="2">
                                <asp:TextBox ID="txtEmailAddress" runat="server" Width="300px" CssClass="TextBoxWater" 
                                    MaxLength="30"></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailAddress" 
	                                    runat="server" ControlToValidate="txtEmailAddress" 
	                                    ErrorMessage="Email Address cannot be empty." ForeColor="Red" 
	                                    SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>

                                     <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmailAddress" 
                                        runat="server" ControlToValidate="txtEmailAddress" 
                                        ErrorMessage="Invalid e-mail address." SetFocusOnError="True" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                        ForeColor="Red" ValidationGroup="Group1">*</asp:RegularExpressionValidator>
                             
                                     <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidatorValidatorEmailAddressEx"
	                                    TargetControlID="RequiredFieldValidatorEmailAddress"
	                                    HighlightCssClass="validatorCalloutHighlight"  />
                                   
                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RegularExpressionValidatorEmailAddressEx"
                                        TargetControlID="RegularExpressionValidatorEmailAddress"
                                        HighlightCssClass="validatorCalloutHighlight" />                                
	                       
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="230px" valign="top" class="Maroon">
                                <asp:Label ID="Label4" runat="server" Text="Message:"></asp:Label>
                                    <br /><br />
                            </td>  
                            <td style="color: #FF0000" valign="top">*</td>      
                            <td colspan="2">
                                <asp:TextBox ID="txtMessage" runat="server" Width="300px" Height="200px" 
                                    MaxLength="250" TextMode="MultiLine" CssClass="TextBoxWater"></asp:TextBox>
                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" 
	                                runat="server" ControlToValidate="txtMessage" 
	                                ErrorMessage="Message cannot be empty." ForeColor="Red" 
	                                SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>

	                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidatorMessageEx"
	                                TargetControlID="RequiredFieldValidatorMessage"
	                                HighlightCssClass="validatorCalloutHighlight" />
                                    <br /><br />
                            </td>
                        </tr>
                        <tr align="center">            
                            <td colspan="2"></td>
                            <td align="center"> 
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                    onclick="btnCancel_Click" CausesValidation="False" /></td> 
                            <td align="center"> 
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                                    onclick="btnSubmit_Click" ValidationGroup="Group1" /></td>
                        </tr>
                    </table>
     
                     <hr />
                     <table>
                        <tr>
                            <td width="280px">
            
                            </td>
                            <td>
                                 <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
		                            AssociatedUpdatePanelID="UpdatePanel1">
		                            <ProgressTemplate>
			                            <table align="center">
				                            <tr align="center">
					                            <td align="center">
						                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/processing.gif" 
                                                        EnableTheming="True" />
					                            </td>
				                            </tr>
			                            </table>
		                            </ProgressTemplate>
	                            </asp:UpdateProgress>

                    <!--                               -->
	                <ww:ErrorDisplay runat="server" ID="Message2" Width="250px" />       
	                <!--                               -->
                            </td>
                        </tr>
                     </table>
     

                    <table>
                        <tr>
                            <td style="color: #FF0000">*</td> 
                            <td class="Maroon" > = Required Field</td>         
                        </tr>
                    </table>
                    <hr />
           
                    <asp:Panel ID="CollapseHeader" runat="server" style="cursor: pointer;">
                        <asp:Label ID="LabelDetails" runat="server" Text="Show Details..." 
                            CssClass="Maroon2"></asp:Label>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" style="overflow:hidden;height:0" CssClass="Maroon"> 
                        All the required fields are compulsory, please supply all the required fields before sending your message.            
                    </asp:Panel>
                    <ajaxToolkit:CollapsiblePanelExtender ID="cpe1" runat="Server"
                        TargetControlID="Panel2"
                        Collapsed="true"
                        CollapsedText="Show Details..."
                        ExpandedText="Hide Details"
                        TextLabelID="LabelDetails"
                        ExpandControlID="CollapseHeader"
                        CollapseControlID="CollapseHeader"
                        SuppressPostBack="true" />
                </div>
            </asp:Panel>
            <ajaxToolkit:DropShadowExtender ID="DropShadowExtender1" runat="server"
            BehaviorID="DropShadowBehavior1"
            TargetControlID="Panel1"
            Width="5"
            Rounded="true"
            Radius="6"
            Opacity=".75"
            TrackPosition="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </td>
    <td width="20px"> </td>
    <td width="300px" valign="top">
         <div class="fb-like-box" data-href="https://www.facebook.com/nkisahotels/" data-width="300px" data-colorscheme="light" data-show-faces="true" data-header="true" data-stream="false" data-show-border="true"></div> 
    </td>
</tr>
</table>

         
</asp:Content>

