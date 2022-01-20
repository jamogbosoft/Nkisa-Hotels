using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.Security;

public partial class BookingReview : System.Web.UI.Page
{
    public CBookings Booking = new CBookings();

    private CQueryStringEncryption QueryString = new CQueryStringEncryption();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CPersonalDetails PersonalDetail = new CPersonalDetails();
                string strUserName = this.Page.User.Identity.Name;
                PersonalDetail.LoadPersonalDetails(strUserName);

                txtSurname.Text = PersonalDetail.Surname;
                txtFirstName.Text = PersonalDetail.FirstName;
                txtEmailAddress.Text = PersonalDetail.Email;
                txtPhoneNumber.Text = PersonalDetail.PhoneNumber;

                Booking = new CBookings();

                Booking.Branch.BranchID = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["b1"].ToString())));
                Booking.Branch.LoadBranch(Booking.Branch.BranchID);
                Booking.RoomType.RoomTypeID = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["r2"].ToString())));
                Booking.RoomType.LoadRoomType(Booking.Branch.BranchID, Booking.RoomType.RoomTypeID);
                Booking.CheckInDate = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["c1"].ToString()));
                Booking.CheckOutDate = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["c2"].ToString()));
                Booking.NumberOfRooms = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["r1"].ToString())));
                Booking.NumberOfAdults = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["a1"].ToString())));

                int MaxNumberOfAdults = Booking.NumberOfRooms * Booking.RoomType.MaxOccupancy;
                if (Booking.NumberOfAdults > MaxNumberOfAdults) { Booking.NumberOfAdults = MaxNumberOfAdults; }

                int intNumberOfNights = (DateTime.Parse(Booking.CheckOutDate) - DateTime.Parse(Booking.CheckInDate)).Days;
                if (intNumberOfNights < 1)
                {
                    throw new Exception("Invalid Check-In or Check-Out date.");
                }
                else
                {
                    Booking.NumberOfNights = intNumberOfNights;
                }

                Booking.TotalAmount = this.TotalAmount();


                ////////////////////////////////

                lblYouWillPay.Text = "You will pay " + Booking.TotalAmount.ToString("N0,000.00");

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

                FillPaymentOptions();

                //////////////////////////////////////////////////////////////////////////
                ////////////////////CAPTURE DATA ON THE FORM//////////////////////////////
                LBranchID.Text = Booking.Branch.BranchID.ToString();
                LBranchName.Text = Booking.Branch.BranchName;
                LBranchAddress.Text = Booking.Branch.Address;
                LCheckInDate.Text = Booking.CheckInDate;
                LCheckOutDate.Text = Booking.CheckOutDate;
                LNumberOfRooms.Text = Booking.NumberOfRooms.ToString();
                LNumberOfAdults.Text = Booking.NumberOfAdults.ToString();
                LNumberOfNights.Text = Booking.NumberOfNights.ToString();

                LRoomTypeID.Text = Booking.RoomType.RoomTypeID.ToString();
                LRoomTypeBranchID.Text = Booking.RoomType.BranchID.ToString();
                LRoomTypeName.Text = Booking.RoomType.RoomTypeName.ToString();
                LPricePerNight.Text = Booking.RoomType.PricePerNight.ToString();
                LBedSize.Text = Booking.RoomType.BedSize.ToString();
                LMaxOccupancy.Text = Booking.RoomType.MaxOccupancy.ToString();

                LTotalAmount.Text = Booking.TotalAmount.ToString();
                //////////////////////////////////////////////////////////////////////////      

            }
            else
            {
                //////////////////////////////////////////////////////////////////////////
                ////////////////////RETREIVE DATA FROM THE FORM//////////////////////////////
                Booking.Branch.BranchID = int.Parse(LBranchID.Text.ToString());
                Booking.Branch.BranchName = LBranchName.Text.ToString();
                Booking.Branch.Address = LBranchAddress.Text.ToString();
                Booking.CheckInDate = LCheckInDate.Text.ToString();
                Booking.CheckOutDate = LCheckOutDate.Text.ToString();
                Booking.NumberOfRooms = int.Parse(LNumberOfRooms.Text.ToString());
                Booking.NumberOfAdults = int.Parse(LNumberOfAdults.Text.ToString());
                Booking.NumberOfNights = int.Parse(LNumberOfNights.Text.ToString());

                Booking.RoomType.RoomTypeID = int.Parse(LRoomTypeID.Text.ToString());
                Booking.RoomType.BranchID = int.Parse(LRoomTypeBranchID.Text.ToString());
                Booking.RoomType.RoomTypeName = LRoomTypeName.Text.ToString();
                Booking.RoomType.PricePerNight = float.Parse(LPricePerNight.Text.ToString());
                Booking.RoomType.BedSize = LBedSize.Text.ToString();
                Booking.RoomType.MaxOccupancy = int.Parse(LMaxOccupancy.Text.ToString());

                Booking.TotalAmount = double.Parse(LTotalAmount.Text.ToString());
                //////////////////////////////////////////////////////////////////////////
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

    private double TotalAmount()
    {
        try
        {
            double totalAmount = double.Parse(Booking.NumberOfNights.ToString()) *
                double.Parse(Booking.RoomType.PricePerNight.ToString()) *
                double.Parse(Booking.NumberOfRooms.ToString());
            return totalAmount;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// private void Fill Payment Options
    /// </summary>
    private void FillPaymentOptions()
    {
        try
        {
            cboPaymentOptions.DataSource = new CModeOfPayment().ModeOfPaymentDataTable();
            cboPaymentOptions.DataTextField = "ModeOfPaymentName";
            cboPaymentOptions.DataValueField = "ModeOfPaymentID";
            cboPaymentOptions.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    protected void btnBookNow_Click(object sender, EventArgs e)
    {
        try
        {
            /*
            string RecaptchaResponse = Request.Form["recaptcha_response_field"];
            string RecaptchaChallenge = Request.Form["recaptcha_challenge_field"];
            string RemoteIP = Request.ServerVariables["REMOTE_ADDR"];

            if (Page.IsValid && new CReCaptcha(RecaptchaResponse, RecaptchaChallenge, RemoteIP).IsValid)
            { */
                Booking.BookingID = new CBookingIDGenerator().BookingID;

                Booking.Surname = txtSurname.Text;
                Booking.FirstName = txtFirstName.Text;
                Booking.Email = txtEmailAddress.Text;
                Booking.PhoneNumber = txtPhoneNumber.Text;
                Booking.ModeOfPayment.ModeOfPaymentID = int.Parse(cboPaymentOptions.SelectedValue);
                Booking.PaymentCompleted = false;

                Booking.ModeOfPayment.LoadModeOfPayment(Booking.ModeOfPayment.ModeOfPaymentID);

                //Testing
                Booking.Add(); //It's allright! 
                Booking.Mail.BookingMessage = "Thanks, your booking has been pre-registered. Please note that no availability is guaranteed until we receive the payment.";
                Booking.Mail.IsPayment = false;
                Booking.Mail.Send();
                //

                string strUrl;

                if (Booking.ModeOfPayment.ModeOfPaymentValue.ToUpper() == "CASH")
                {
                    strUrl = "~/BookNow/BookingStatus.aspx?" +
                           "i=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.BookingID));
                }
                else
                {
                    strUrl = "~/BookNow/PaymentReview.aspx?" +
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
                }

                Response.Redirect(strUrl);
           /* }
            else
            {
                lblVerificationMessage.Text = "The verification code is incorrect.";
                lblVerificationMessage.ForeColor = Color.Red;
            }
            */
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            string strUrl = "~/BookNow/BookingSearch.aspx?" +
                "b1=" + HttpUtility.UrlEncode(QueryString.Encrypt(LBranchID.Text.ToString())) +
                "&c1=" + HttpUtility.UrlEncode(QueryString.Encrypt(LCheckInDate.Text.ToString())) +
                "&c2=" + HttpUtility.UrlEncode(QueryString.Encrypt(LCheckOutDate.Text.ToString())) +
                "&r1=" + HttpUtility.UrlEncode(QueryString.Encrypt(LNumberOfRooms.Text.ToString())) +
                "&a1=" + HttpUtility.UrlEncode(QueryString.Encrypt(LNumberOfAdults.Text.ToString()));
            Response.Redirect(strUrl);
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }
    }
}