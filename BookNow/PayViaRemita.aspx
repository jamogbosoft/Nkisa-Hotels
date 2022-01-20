<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayViaRemita.aspx.cs" Inherits="PayViaRemita" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Pay Via Remita</title>        
        <link href="~/Styles/Payment.css" rel="Stylesheet" type="text/css" id="Link1" /> 
    </head>
    <body>
        <form id="form1" method="POST" action="http://www.remitademo.net/remita/ecomm/finalize.reg" runat="server">
            <div>                
                <asp:HiddenField id="merchantId" runat="server" />
                <asp:HiddenField id="hash" runat="server" />
                <asp:HiddenField id="rrr" runat="server" />
                <asp:HiddenField id="responseurl" runat="server" />                    
            </div>                       
        </form>
        <script type="text/javascript">document.getElementById("form1").submit();</script>      
    </body>
</html>
