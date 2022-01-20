<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/SiteDashboard.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="Account_ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="DashboardHeadContent">
    <!-- <link href="../Styles/Design/Gray/css/better-modal.css" rel="Stylesheet" type="text/css" id="Link1" /> -->
    <link href="../Styles/Design/Gray/css/form.css" rel="Stylesheet" type="text/css" id="Link2" />
    <link href="../Styles/Design/Gray/css/grid.css" rel="Stylesheet" type="text/css" id="Link3" />
    <!-- <link href="../Styles/Design/Gray/css/login.css" rel="Stylesheet" type="text/css" id="Link4" /> -->
    <!-- <link href="../Styles/Design/Gray/css/modal.css" rel="Stylesheet" type="text/css" id="Link5" /> -->
    <link href="../Styles/Design/Gray/css/subscription-management.css" rel="Stylesheet" type="text/css" id="Link6" />    
    <link href="../Styles/Design/Gray/css/template.css" rel="Stylesheet" type="text/css" id="Link7" /> 
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="DashboardMainContent">
  <table align="center" style="background-image: url('../Images/imagedropdown.gif'); background-repeat: no-repeat" id="tabChangePassword">
  <tr align="center" id="trChangePassword">
    <td align="center" id="tdChangePassword">
     <asp:Panel ID="Panel1" runat="server" CssClass="PasswordRecorvery">
      <asp:ChangePassword ID="ChangeUserPassword" runat="server" 
        CancelDestinationPageUrl="~/Default.aspx" EnableViewState="False" ContinueDestinationPageUrl="~/Default.aspx" >
          <ChangePasswordTemplate>
              <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;" 
                  align="center">
                  <tr align="center">
                      <td >
                          <table cellpadding="0">
                              <tr>
                                  <td align="center" colspan="3" style="font-weight: bold">
                                      Change Your Password</td>
                              </tr>
                              <tr>
                                  <td align="right"><br />
                                      <asp:Label ID="CurrentPasswordLabel" runat="server" 
                                          AssociatedControlID="CurrentPassword">Password:</asp:Label>
                                  </td>
                                  <td colspan="2"><br />
                                      <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" 
                                          ControlToValidate="CurrentPassword" ErrorMessage="Password is required." 
                                          ToolTip="Password is required." ValidationGroup="ChangeUserPassword">*</asp:RequiredFieldValidator>
                                  </td>
                              </tr>
                              <tr>
                                  <td align="right"><br />
                                      <asp:Label ID="NewPasswordLabel" runat="server" 
                                          AssociatedControlID="NewPassword">New Password:</asp:Label>
                                  </td>
                                  <td colspan="2"><br />
                                      <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" 
                                          ControlToValidate="NewPassword" ErrorMessage="New Password is required." 
                                          ToolTip="New Password is required." ValidationGroup="ChangeUserPassword">*</asp:RequiredFieldValidator>
                        
                                  </td>
                              </tr>
                              <tr>
                                  <td align="right"><br />
                                      <asp:Label ID="ConfirmNewPasswordLabel" runat="server" 
                                          AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                                  </td>
                                  <td colspan="2"><br />
                                      <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" 
                                          ControlToValidate="ConfirmNewPassword" 
                                          ErrorMessage="Confirm New Password is required." 
                                          ToolTip="Confirm New Password is required." >*</asp:RequiredFieldValidator>
                             
                                  </td>
                              </tr>
                              <tr>
                                  <td align="center" colspan="3">
                                      <asp:CompareValidator ID="NewPasswordCompare" runat="server" 
                                          ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                          Display="Dynamic" 
                                          ErrorMessage="The Confirm New Password must match the New Password entry." 
                                          ValidationGroup="ChangeUserPassword"></asp:CompareValidator>
                                  </td>
                              </tr>
                              <tr>
                                  <td align="center" colspan="3" style="color:Red;">
                                      <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                  </td>
                              </tr>
                              <tr>
                              <td></td>
                                  <td align="left"><br />
                                      <asp:Button ID="ChangePasswordPushButton" runat="server" 
                                          CommandName="ChangePassword" Text="Change Password" 
                                          ValidationGroup="ChangeUserPassword" />
                                  </td>
                                  <td align="left"><br />
                                      <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                                          CommandName="Cancel" Text="Cancel" />
                                  </td>
                              </tr>
                          </table>
                      </td>
                  </tr>
              </table>
          </ChangePasswordTemplate>
        <SuccessTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;" align="center">
                <tr align="center">
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" style="color:#FFFFFF; font-weight:bold; font-size: medium;">
                                    Change Password Complete</td>
                            </tr>
                            <tr>
                                <td style="color: #3366CC; font-size: medium;">
                                    Your password has been changed!</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" 
                                        CommandName="Continue" Text="Continue" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </SuccessTemplate>
    </asp:ChangePassword>
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