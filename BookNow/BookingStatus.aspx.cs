using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaymentReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CBookings Booking = new CBookings();
                CPaymentHistory PaymentHistory = new CPaymentHistory();
                CQueryStringEncryption QueryString = new CQueryStringEncryption();

                string strBookingId = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["i"]));

                //string strBookingId = Request.QueryString["BookingID"].ToString();

                Booking.LoadBooking(strBookingId);
                PaymentHistory.LoadPaymentHistory(strBookingId);

                ////////////////////////////////
                imgLogo.ImageUrl = "~/Images/RoomTypes/" + Booking.RoomType.RoomTypeID.ToString() + ".jpg";
                lblRoomType.Text = Booking.RoomType.RoomTypeName;
                lblBranchAddress.Text = Booking.Branch.Address;

                //Your Booking Details
                lblRoomType2.Text = Booking.RoomType.RoomTypeName;
                lblMaximumOccupancy.Text = Booking.RoomType.MaxOccupancyInWords;
                lblNumberOfRooms.Text = Booking.NumberOfRoomsInWords;
                lblNumberOfAdults.Text = Booking.NumberOfAdultsInWords;
                lblCheckInDate.Text = DateTime.Parse(Booking.CheckInDate).ToLongDateString();
                lblCheckOutDate.Text = DateTime.Parse(Booking.CheckOutDate).ToLongDateString();
                lblNumberOfNights.Text = Booking.NumberOfNightsInWords;

                //Your Payment Details
                lblPriceForOneNight.Text = Booking.RoomType.PricePerNight.ToString("N 0,000.00");
                lblRoomsTimesNightsCaption.Text = Booking.NumberOfRoomsInWords.Trim('.') + " X " + Booking.NumberOfNightsInWords.Trim('.') + ":";
                lblRoomsTimesNightsAmount.Text = Booking.TotalAmount.ToString("N 0,000.00");
                lblTotalAmount.Text = Booking.TotalAmount.ToString("N 0,000.00");

                //Payment Review
                lblSurname.Text = Booking.Surname;
                lblFirstName.Text = Booking.FirstName;
                lblEmailAddress.Text = Booking.Email;
                lblPhoneNumber.Text = Booking.PhoneNumber;
                lblModeOfPayment.Text = Booking.ModeOfPayment.ModeOfPaymentName;
                lblBookingID.Text = Booking.BookingID;

                if (Booking.ModeOfPayment.ModeOfPaymentValue.ToUpper() == "CASH") // Pay Cash
                {
                    panelDetails1.Visible = false;
                    panelDetails2.Visible = true;

                    lblBookingMessage.Text = "Thanks, your booking has been pre-registered. Please note that no availability is guaranteed until we receive the payment.";
                    if (Booking.Email != "")
                    {
                        lblConfirmMailMessage.Text = "Please a confirmation message has been sent to your email " + Booking.Email;
                    }
                    else
                    {
                        lblConfirmMailMessage.Text = "";
                        lblConfirmMailMessage.Visible = false;
                    }

                    lblCancellationMessage.Text = new CCancellationPolicy().Policies;
                }
                else if (Booking.ModeOfPayment.ModeOfPaymentValue.ToUpper() == "POS") // Pay at Bank Branch
                {
                    panelDetails1.Visible = true;
                    panelDetails2.Visible = false;
                    panelPaymentStatement.Visible = true;

                    lblConfirmMailMessage.Text = "";
                    lblBookingMessage.Text = "Thanks, your booking has been pre-registered and requires a payment within 12 hours. Please note that no availability is guaranteed until we receive the payment.";

                    lblCancellationMessage.Text = "";
                    lblCancellationMessage.Visible = false;

                }
                else //MASTERCARD, VERVE, VISA, UNIONPAY, WEBMONEY, WALLET, REMITA TRANSFER etc
                {
                    panelDetails1.Visible = false;
                    panelDetails2.Visible = true;
                    panelPaymentStatement.Visible = true;

                    lblBookingMessage.Text = "Thanks, your booking has been pre-registered. Please note that no availability is guaranteed until we receive the payment.";

                    if (Booking.Email != "")
                    {
                        lblConfirmMailMessage.Text = "Plesae, your booking and your payment details have been sent to your email " + Booking.Email;
                    }
                    else
                    {
                        lblConfirmMailMessage.Text = "";
                        lblConfirmMailMessage.Visible = false;
                    }

                    lblCancellationMessage.Text = new CCancellationPolicy().Policies;
                }

                ///////////////////////////////////////////////////////////////////////////////////////                
                if (PaymentHistory.Payment.status == "01" || PaymentHistory.Payment.status == "00")
                {
                    lblTransactionStatement.Text = "Payment completed successfully";
                    lblRRRCaption.Text = "Your Remita Retrieval Reference (RRR) is: ";
                    lblRRR.Text = PaymentHistory.Payment.RRR;

                    HyperLinkRetryPayment.Visible = false;
                }
                else if (PaymentHistory.Payment.status == "021")
                {
                    lblTransactionStatement.Text = "RRR was generated successfully";
                    lblRRRCaption.Text = "Your Remita Retrieval Reference (RRR) is: ";
                    lblRRR.Text = PaymentHistory.Payment.RRR;

                    string strUrl = @"~/BookNow/PayViaRemita.aspx?i=" + HttpUtility.UrlEncode(QueryString.Encrypt(PaymentHistory.Payment.RRR));
                    HyperLinkRetryPayment.NavigateUrl = strUrl;
                    HyperLinkRetryPayment.Text = "Click Here To Pay Via Remita";
                }
                else if (PaymentHistory.Payment.status != "")
                {
                    lblTransactionStatement.Text = "Your payment was not successful";

                    if (PaymentHistory.Payment.RRR != null)
                    {
                        lblRRRCaption.Text = "Your Remita Retrieval Reference (RRR) is: ";
                        lblRRR.Text = PaymentHistory.Payment.RRR;
                        lblReasonCaption.Text = "Reason: ";
                        lblReason.Text = PaymentHistory.Payment.message;

                        string strUrl = @"~/BookNow/PayViaRemita.aspx?i=" + HttpUtility.UrlEncode(QueryString.Encrypt(PaymentHistory.Payment.RRR));
                        HyperLinkRetryPayment.NavigateUrl = strUrl;
                        HyperLinkRetryPayment.Text = "Click Here To Retry Your Payment";
                    }
                    else
                    {
                        lblTransactionStatement.Text = "";
                        lblRRRCaption.Text = lblRRR.Text = lblReasonCaption.Text = lblReason.Text = "";

                        string strUrl = "~/BookNow/PaymentReview.aspx?" +
                          "b1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.Branch.BranchID.ToString())) +
                          "&r2=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.RoomType.RoomTypeID.ToString())) +
                          "&m1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.ModeOfPayment.ModeOfPaymentID.ToString())) +
                          "&b2=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.BookingID.ToString())) +
                          "&c1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.CheckInDate)) +
                          "&c2=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.CheckOutDate)) +
                          "&r1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.NumberOfRooms.ToString())) +
                          "&a1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.NumberOfAdults.ToString())) +
                          "&n1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.Surname)) +
                          "&n2=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.FirstName)) +
                          "&e1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.Email)) +
                          "&p1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.PhoneNumber));

                        HyperLinkRetryPayment.NavigateUrl = strUrl;
                        HyperLinkRetryPayment.Text = "Click Here If You Wish To Pay Online";

                    }                    
                }
                //////////////////////////////////////////////////////////////////////////////////////
            }

        }
        catch (Exception ex)
        {
            foreach (Control c in this.panelPaymentReview.Controls)
            {
                try
                {
                    c.Visible = false;
                }
                catch { }
            }

            foreach (Control c in this.panelBookingSummary.Controls)
            {
                try
                {
                    c.Visible = false;
                }
                catch { }
            }

            Message1.ShowError(ex.Message);
        }
    }

}