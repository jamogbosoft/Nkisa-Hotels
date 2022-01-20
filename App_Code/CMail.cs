using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using System.Web;

/// <summary>
/// Summary description for CMail
/// </summary>
public class CMail
{
    public CRemitaResponse Payment { get; set; }

    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string FullName { get { return this.Surname + " " + this.FirstName; } }
    public string Email { get; set; }
    public string BookingMessage { get; set; }
    public string PaymentMessage { get; set; }
    public bool IsPayment { get; set; }

    private CQueryStringEncryption QueryString = new CQueryStringEncryption();

    public string Message
    {
        get
        {
            string strMessage = this.MessageUpperHeader;
            if (this.IsPayment) { strMessage += this.MessagePaymentHeader; }
            else { strMessage += this.MessageBookingHeader; }
            strMessage += MessageLowerHeader + this.MessageBody + this.MessageFooter;

            return strMessage;
        }
    }

    private string RRRMessage
    {
        get
        {
            string strRRRMessage = @"<div class=""payment"">                                                    
		                                <div class=""paymentline"">" + this.PaymentMessage + @"</div>
		                                <p class=""rrr""><strong>Your Remita Retrieval Reference (RRR) is: " + this.Payment.RRR + @"</strong></p>
                                        <p>" + this.Payment.message + @"</p>                                
                                    </div>";
            return strRRRMessage;
        }
    }

    private string MessageUpperHeader
    {
        get
        {
            string strUpperHeader = @"<html>
                                        <head>
                                            <title></title>
                                            <style type=""text/css"">
                                                .container {width:640px; background-color:#ececec; margin: 0 auto;}
                                                .containerline {margin: 10px;}
                                                .bar {min-height:20px; border-radius:6px 6px 0px 0px; background-color:#003366; color:#7a7978;}
                                                .header {border-radius:0px 0px 6px 6px;}
                                                .header {padding:10px 0; font-family:HelveticaNeue, sans-serif; font-size:13px; line-height:18px; color:#fff; background-color:#006699; position:relative; clear:both;}                                                
                                                .headline p {padding:10px 0; font-size:20px !important; color:#FFFFFF; font-family:Georgia, ""Times New Roman"", Times, serif;}
                                                .footer {padding:1px 10px; font-family:HelveticaNeue, sans-serif; font-size:13px; line-height:18px; color:#FFFFFF; background-color:#006699; position:relative; clear:both; font-weight:bold;}
                                                 a {color:#FF6600; text-decoration:none; font-weight:bold;}
                                                .rrr {color: #FF6600;}   
                                                .payment {width:605px;; text-align:center; align:center; color: Navy !important; background-color:#CCFFFF !important; border: solid 4px  Aqua !important; {margin: 5px 5px; padding: 2px;}
                                                .paymentline {font-size:20px !important; font-weight:bold;}
                                                header,  section,  footer,  aside,   article,  figure {display:block;}
                                            </style>
                                        </head>
                                        <body>    
                                            <div id=""Container"" class=""container"">
                                                <div id=""Bar"" class=""bar""></div>
                                                <div id=""Header"" class=""header"">   
                                                    <div id=""Headline"" class=""headline"" align=""center"">             
                                                        <strong id=""Strongheader"">";
            return strUpperHeader;
        }
    }

    private string MessageBookingHeader { get { string strBookingHeader = "NKISA HOTELS ONLINE BOOKING CONFIRMATION"; return strBookingHeader; } }
    private string MessagePaymentHeader { get { string strPaymentHeader = "NKISA HOTELS ONLINE PAYMENT CONFIRMATION"; return strPaymentHeader; } }
    private string MessageLowerHeader { get { string strLowerHeader = "</strong></div></div>"; return strLowerHeader; } }

    private string MessageBody
    {
        get
        {
            string strBody = @"<table class=""containerline"">
                                <tr>
                                    <td >
                                        Dear " + this.FullName + ",<br /><br />" + this.BookingMessage + @"<br />
                                        Your Booking Reference is: 
                                        <strong style=""color: #003366"" > " + this.Payment.orderId + @" </strong><br />";
            if (this.IsPayment) { strBody += RRRMessage + "<br />"; }
            strBody += @"<br /><a href=""http://localhost/nkisahotels.com/BookNow/BookingStatus.aspx?i=" +
                    HttpUtility.UrlEncode(QueryString.Encrypt(this.Payment.orderId)) + @""">Click Here To Print Your Booking Receipt</a>
                                    </td>
                                </tr>        
                            </table>";
            return strBody;
        }
    }

    private string MessageFooter
    {
        get
        {
            string strFooter = @"<div id=""Footer"" class=""footer"" >
		                            <p>
                                       If you have enquiries, please send an email to <a href=""mailto:support@nkisahotels.com"">support@nkisahotels.com</a> or call us on +2348024532141 or visit our website <a href=""http://localhost/nkisahotels.com"">www.nkisahotels.com</a> for more information.
                                       <br /><br />
                                       Thank You. 
                                    </p>
	                            </div> 
                            </div>   
                        </body>
                     </html>";
            return strFooter;
        }
    }

    private string strUserName, strPassword, strSmtp,
             strDisplayName, strFrom, strSubject;
    private bool blnSsl, blnEncode;
    private int intPort;

    public CMail()
    {
        try
        {
            Payment = new CRemitaResponse();           

            this.Surname = this.FirstName = this.Email = this.BookingMessage = "";
            this.IsPayment = false;

            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            strUserName = smtpSection.Network.UserName;
            strPassword = smtpSection.Network.Password;
            intPort = smtpSection.Network.Port;
            strSmtp = smtpSection.Network.Host;
            blnSsl = smtpSection.Network.EnableSsl;
            strFrom = smtpSection.From;
            strSubject = "Nkisa Hotels Online Booking";
            blnEncode = true;
            strDisplayName = "no-reply@nkisahotels.com";
        }
        catch { }
    }

    public void Send()
    {
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(strFrom, strDisplayName);
                mail.To.Add(new MailAddress(this.Email));
                mail.Subject = strSubject;
                mail.Body = this.Message;
                mail.Priority = MailPriority.Normal;

                if (blnEncode)
                {
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                }

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = strSmtp;
                smtp.EnableSsl = blnSsl;
                NetworkCredential networkCredential = new NetworkCredential(strUserName, strPassword);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = intPort;
                smtp.Send(mail);
            }
        }
        catch { }
    }
}