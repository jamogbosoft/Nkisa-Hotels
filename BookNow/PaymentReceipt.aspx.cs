using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;

public partial class PaymentReceipt : System.Web.UI.Page
{
    public string merchant_id = CRemitaConfigParams.MERCHANTID;
    public string apiKey = CRemitaConfigParams.APIKEY;
    public string hashed;
    public string order_Id;
    public string checkstatusurl = CRemitaConfigParams.CHECKSTATUSURL;
    public string url;
    public CPaymentHistory PaymentHistory;

    private CQueryStringEncryption QueryString = new CQueryStringEncryption();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            try { order_Id = Request.QueryString["orderID"].ToString(); }
            catch(Exception ex)
            {
                string s1,s2;
                s1 = Request.QueryString["statuscode"].Trim();
                s2 = "028";

                if (s1 == s2)
                {
                    throw new Exception("RRR has already been generated. " + Request.QueryString["status"].ToString());
                }
                else { throw ex; }
            }
            if (!IsPostBack)
            {
                string hash_string = order_Id + apiKey + merchant_id;
                System.Security.Cryptography.SHA512Managed sha512 = new System.Security.Cryptography.SHA512Managed();
                Byte[] EncryptedSHA512 = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hash_string));
                sha512.Clear();
                hashed = BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
                url = checkstatusurl + "/" + merchant_id + "/" + order_Id + "/" + hashed + "/" + "orderstatus.reg";
                string jsondata = new WebClient().DownloadString(url);
                CRemitaResponse payment = JsonConvert.DeserializeObject<CRemitaResponse>(jsondata);

                PaymentHistory = new CPaymentHistory();
                PaymentHistory.Payment = payment;
                PaymentHistory.Update();

                CBookings Booking = new CBookings();
                Booking.LoadBooking(order_Id);
                Booking.Mail.Payment = payment;
                Booking.Mail.IsPayment = true;

                if (PaymentHistory.Payment.status == "01" || PaymentHistory.Payment.status == "00")
                {
                    lblTransactionStatement.Text = "Payment completed successfully";
                    lblRRRCaption.Text = "Your Remita Retrieval Reference (RRR) is: ";
                    lblRRR.Text = PaymentHistory.Payment.RRR;

                    PaymentHistory.CompleteBookingPayment(true, "UNION_PAY");
                    btnPayViaRemita.Visible = false;

                    lblReasonCaption.Text = "";
                    try { lblReason.Text = Request.QueryString["status"].ToString(); Booking.Mail.Payment.message = lblReason.Text; }
                    catch { }

                    Booking.Mail.BookingMessage = "Thanks, your booking registration is successfully completed.";
                    Booking.Mail.PaymentMessage = "Payment completed successfully";
                }
                else if (PaymentHistory.Payment.status == "021")
                {
                    lblTransactionStatement.Text = "RRR was generated successfully";
                    lblRRRCaption.Text = "Your Remita Retrieval Reference (RRR) is: ";
                    lblRRR.Text = PaymentHistory.Payment.RRR;

                    if (Booking.ModeOfPayment.ModeOfPaymentValue.ToUpper() == "CASH")
                    {
                        PaymentHistory.CompleteBookingPayment(false, "UNION_PAY");
                    }

                    Booking.Mail.BookingMessage = "Thanks, your booking has been pre-registered and requires a payment within 12 hours. Please note that no availability is guaranteed until we receive the payment.";
                    Booking.Mail.PaymentMessage = "RRR was generated successfully";
                }
                else
                {
                    lblTransactionStatement.Text = "Your payment was not successful";
                    if (PaymentHistory.Payment.RRR != null)
                    {
                        lblRRRCaption.Text = "Your Remita Retrieval Reference (RRR) is: ";
                        lblRRR.Text = PaymentHistory.Payment.RRR;
                    }
                    lblReasonCaption.Text = "Reason: ";
                    lblReason.Text = PaymentHistory.Payment.message;

                    Booking.Mail.BookingMessage = "Thanks, your booking has been pre-registered.";
                    Booking.Mail.PaymentMessage = "Your payment was not successful";
                }

                panelPaymentStatement.Visible = true;

                Booking.Mail.Send();
            }
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }
    }
    
    protected void btnPrintYourReceipt_Click(object sender, EventArgs e)
    {
        try
        {          
            string strUrl = "~/BookNow/BookingStatus.aspx?" +
                   "i=" + HttpUtility.UrlEncode(QueryString.Encrypt(order_Id));
            Response.Redirect(strUrl);
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }
    }
    protected void btnPayViaRemita_Click(object sender, EventArgs e)
    {
        try
        {         
            string strUrl = @"~/BookNow/PayViaRemita.aspx?" +
                "i=" + HttpUtility.UrlEncode(QueryString.Encrypt(lblRRR.Text.Trim()));
            Response.Redirect(strUrl);
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }
    }
}