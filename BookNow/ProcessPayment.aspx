<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcessPayment.aspx.cs" Inherits="ProcessPayment" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Generating RRR</title>        
    </head>
    <body>
        <form id="form1" method="POST" action="http://www.remitademo.net/remita/ecomm/init.reg" runat="server">
            <div>
                <asp:HiddenField id="payerName" runat="server" />
                <asp:HiddenField id="payerEmail" runat="server" />
                <asp:HiddenField id="payerPhone" runat="server" />
                <asp:HiddenField id="orderId" runat="server" />
                <asp:HiddenField id="merchantId" runat="server" />
                <asp:HiddenField id="serviceTypeId" runat="server" />
                <asp:HiddenField id="responseurl" runat="server" />
                <asp:HiddenField id="amt" runat="server" />
                <asp:HiddenField id="hash" runat="server" />
                <asp:HiddenField id="paymenttype" runat="server" />
            </div>
        </form>
        <script type="text/javascript">document.getElementById("form1").submit();</script>
    </body>
</html>
