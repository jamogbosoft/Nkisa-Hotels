<%@ Page Title="Password Recovery" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PasswordRecovery.aspx.cs" Inherits="PasswordRecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style49
        {
            width: 369px;
        }
        .style50
        {
            width: 185px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table id="PasswordRecovery" align="center" 
        style="background-image: url('../Images/imagedropdown.gif'); background-repeat: no-repeat;">
<tr align="center">
<td align="center" class="style49">
   
        <asp:Panel ID="Panel1" runat="server" CssClass="PasswordRecorvery">
            <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" Width="466px">
                <MailDefinition Subject="Password Reset">
                </MailDefinition>
                <SuccessTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0" style="width:369px;">
                                    <tr>
                                        <td style="color: #FFFFFF; font-weight: bold; font-size: small;">
                                            Your password has been sent to you.</td>
                                    </tr>

                                    <tr>
                                  <td></td>
                                         <td align="right">
                                              <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" Text="Continue" 
                                                  PostBackUrl="~/Default.aspx" />
                                          </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </SuccessTemplate>
                <UserNameTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <tr>
                                        <td align="center" colspan="3" 
                                            style="color: White; font-weight: bold;">
                                            Forgot Your Password?</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            Enter your User Name to receive your password.</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="UserName" runat="server" Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                                ToolTip="User Name is required." ValidationGroup="PasswordRecovery1" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="color: Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                  <td></td>
                                        <td align="center"><br />
                                            <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" 
                                                ValidationGroup="PasswordRecovery1" />
                                        </td>
                                        <td align="center"><br />
                                              <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                                                  CommandName="Cancel" Text="Cancel" PostBackUrl="~/Default.aspx" />
                                          </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </UserNameTemplate>
            </asp:PasswordRecovery>
            </asp:Panel>

            <ajaxToolkit:DropShadowExtender ID="DropShadowExtender1" runat="server"
                BehaviorID="DropShadowBehavior1"
                TargetControlID="Panel1"
                Width="8"
                Rounded="true"
                Radius="6"
                Opacity=".75"
                TrackPosition="true" />

          
       </td>
    </tr>
    </table>
</asp:Content>

