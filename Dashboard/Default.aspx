<%@ Page Title="Personal Details" Language="C#" MasterPageFile="~/SiteDashboard.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" Runat="Server">
    <!-- <link href="../Styles/Design/Gray/css/better-modal.css" rel="Stylesheet" type="text/css" id="Link1" /> -->
    <link href="../Styles/Design/Gray/css/form.css" rel="Stylesheet" type="text/css" id="Link2" />
    <link href="../Styles/Design/Gray/css/grid.css" rel="Stylesheet" type="text/css" id="Link3" />
    <!-- <link href="../Styles/Design/Gray/css/login.css" rel="Stylesheet" type="text/css" id="Link4" /> -->
    <!-- <link href="../Styles/Design/Gray/css/modal.css" rel="Stylesheet" type="text/css" id="Link5" /> -->
    <link href="../Styles/Design/Gray/css/subscription-management.css" rel="Stylesheet" type="text/css" id="Link6" />    
    <link href="../Styles/Design/Gray/css/template.css" rel="Stylesheet" type="text/css" id="Link7" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" Runat="Server">
    
        <ww:ErrorDisplay runat="server" ID="Message1" Width="350px" />   

    <table width="100%" align="right">
        
        <tr><td align="left" colspan="3"
                    style="font-family: 'Arial Black'; font-size: x-large; color: #808080">
                Personal Details
        </td></tr>


        <tr align="right">
           
            <td>
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label1" runat="server" Text="Surname *"></asp:Label>
                            <br /> <br /> 
                        </td>
                        <td align="left">                
                            <asp:TextBox ID="txtSurname" runat="server" Width="350px" Font-Size="Large" 
                                MaxLength="15"></asp:TextBox>                                
                                <br /> <br />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSurName" 
	                            runat="server" ControlToValidate="txtSurName" 
	                            ErrorMessage="Surname cannot be empty." ForeColor="Red" 
	                            SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                            <ajaxToolkit:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtenderSurName"
                                runat="server"
                                TargetControlID="txtSurName" 
	                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-'" /> 
	                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidatorSurNameEx"
	                            TargetControlID="RequiredFieldValidatorSurName"
	                            HighlightCssClass="validatorCalloutHighlight" PopupPosition="BottomLeft" />      
                            <br /> <br />         
                        </td>
                    </tr> 
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="First Name *" ></asp:Label>
                            <br /> <br />
                        </td>
                        <td align="left">                
                            <asp:TextBox ID="txtFirstName" runat="server" Width="350px" Font-Size="Large" MaxLength="15"></asp:TextBox>
                            <br /> <br />
                         </td>
                         <td> 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" 
	                            runat="server" ControlToValidate="txtFirstName" 
	                            ErrorMessage="First Name cannot be empty." ForeColor="Red" 
	                            SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                            <ajaxToolkit:FilteredTextBoxExtender
                                ID="FirstNameEx1"
                                runat="server"
                                TargetControlID="txtFirstName" 
	                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-'" /> 
	                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="FirstNameEx2"
	                            TargetControlID="RequiredFieldValidatorFirstName"
	                            HighlightCssClass="validatorCalloutHighlight" PopupPosition="BottomLeft" />
                             <br /> <br /> 
                        </td>           
                    </tr>
                    <tr align="right">
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" Text="Email Address *"></asp:Label>
                            <br /> <br />
                        </td>
                        <td align="right">
                              <asp:TextBox ID="txtEmailAddress" runat="server" Width="350px" Font-Size="Large" 
                                    MaxLength="30"></asp:TextBox>
                                    <br /> <br />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailAddress" 
	                            runat="server" ControlToValidate="txtEmailAddress" 
	                            ErrorMessage="Email Address cannot be empty." ForeColor="Red" 
	                            SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmailAddress" 
                                runat="server" ControlToValidate="txtEmailAddress" 
                                ErrorMessage="Invalid e-mail address." SetFocusOnError="True" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ForeColor="Red" ValidationGroup="Group1">*</asp:RegularExpressionValidator>
                             
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="EmailAddressEx1"
	                            TargetControlID="RequiredFieldValidatorEmailAddress"
	                            HighlightCssClass="validatorCalloutHighlight"  PopupPosition="BottomLeft" />
                                   
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="EmailAddressEx2"
                                TargetControlID="RegularExpressionValidatorEmailAddress"
                                HighlightCssClass="validatorCalloutHighlight" PopupPosition="BottomLeft" /> 
                                <br /> <br /> 
                        </td>
                    </tr> 
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label4" runat="server" Text="Phone Number *" ></asp:Label>
                            <br /> <br />
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhoneNumber" runat="server"  MaxLength="14" Width="350px" 
                                Font-Size="Large"></asp:TextBox>
                                <br /> <br />
                        </td>
                        <td>
                            <ajaxToolkit:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtenderPhoneNumber"
                                runat="server"
                                TargetControlID="txtPhoneNumber" FilterType="Custom" ValidChars="+0123456789" />

                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNumber" 
	                            runat="server" ControlToValidate="txtPhoneNumber" 
	                            ErrorMessage="Phone number cannot be empty." ForeColor="Red" 
	                            SetFocusOnError="True" ValidationGroup="Group1">*</asp:RequiredFieldValidator>  
                       
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhoneNumber" 
                                runat="server" ControlToValidate="txtPhoneNumber" 
                                ErrorMessage="Invalid Phone Number." SetFocusOnError="True" 
                                ValidationExpression="([+]([0-9]+))|([0-9]+)" 
                                ForeColor="Red" ValidationGroup="Group1">*</asp:RegularExpressionValidator>
                
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="PhoneNumberEx1"
	                            TargetControlID="RequiredFieldValidatorPhoneNumber"
	                            HighlightCssClass="validatorCalloutHighlight"  PopupPosition="BottomLeft" /> 
                
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="PhoneNumberEx2"
                                TargetControlID="RegularExpressionValidatorPhoneNumber"
                                HighlightCssClass="validatorCalloutHighlight" PopupPosition="BottomLeft" />   
                                <br /> <br />
                        </td>

                    </tr> 
                    
                    <tr align="right">
                    <td colspan="2">                
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="okbuttonlarge"  
                            ValidationGroup="Group1" onclick="btnUpdate_Click"/>                        
                    </td>
                </tr>            
                </table>
            </td>

        </tr>     
    </table>   
</asp:Content>

