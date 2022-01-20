<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentReceipt.aspx.cs" Inherits="PaymentReceipt" %>
<%@ Register Assembly="Westwind.Web" Namespace="Westwind.Web.Controls" TagPrefix="ww"  %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Payment Receipt</title>
         <link rel="Stylesheet" href="../Styles/Payment.css"  type="text/css" id="Link2" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div align="center">
                    <ww:ErrorDisplay runat="server" ID="Message1" Width="400px" /> 
            </div>
            
            <div style="text-align: center;" align="center">  
                <table align="center">
                    <tr align="center">
                        <td align="center">
                             <asp:Panel ID="panelPaymentStatement" runat="server" 
                                 CssClass="errordisplay" Visible="False" Width="650px">                  
		                        <h2><asp:Label ID="lblTransactionStatement" runat="server"></asp:Label></h2>
		                        <p><strong>
                                    <asp:Label ID="lblRRRCaption" runat="server"></asp:Label>
                                    <asp:Label ID="lblRRR" runat="server"></asp:Label>
                                </strong></p>		            
		                        <p><b><asp:Label ID="lblReasonCaption" runat="server"></asp:Label> </b> <asp:Label ID="lblReason" runat="server"></asp:Label></p>
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnPayViaRemita" runat="server" Text="Pay Via Remita" 
                                                CssClass="ok2buttonmedium" onclick="btnPayViaRemita_Click" 
                                                Font-Italic="True" />
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnPrintYourReceipt" runat="server" Text="Print Your Payment Receipt" 
                                                onclick="btnPrintYourReceipt_Click" CssClass="ok4buttonmedium" 
                                                Font-Italic="True" />
                                        </td>
                                        

                                    </tr>
                                </table>
                                
                            </asp:Panel>    
                        </td>
                    </tr>
                </table> 
                           
            </div>           
        </form>
    </body>
</html>
