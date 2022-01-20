using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaymentReview : System.Web.UI.Page
{
    public CBookings Booking;

  
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CQueryStringEncryption QueryString = new CQueryStringEncryption();

                Booking = new CBookings();

                Booking.Branch.BranchID = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["b1"].ToString())));
                Booking.Branch.LoadBranch(Booking.Branch.BranchID);
                Booking.RoomType.RoomTypeID = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["r2"].ToString())));
                Booking.RoomType.LoadRoomType(Booking.Branch.BranchID, Booking.RoomType.RoomTypeID);
                Booking.ModeOfPayment.ModeOfPaymentID = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["m1"].ToString())));
                Booking.ModeOfPayment.LoadModeOfPayment(Booking.ModeOfPayment.ModeOfPaymentID);
                Booking.BookingID = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["b2"].ToString()));
                Booking.CheckInDate = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["c1"].ToString()));
                Booking.CheckOutDate = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["c2"].ToString()));
                Booking.NumberOfRooms = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["r1"].ToString())));
                Booking.NumberOfAdults = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["a1"].ToString())));
                Booking.Surname = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["n1"].ToString()));
                Booking.FirstName = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["n2"].ToString()));
                Booking.Email =QueryString.Decrypt(HttpUtility.UrlDecode( Request.QueryString["e1"].ToString()));
                Booking.PhoneNumber = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["p1"].ToString()));


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
                lblYouWillPay.Text = "You will pay " + Booking.TotalAmount.ToString("N0,000.00");

                LModeOfPaymentValue.Text = Booking.ModeOfPayment.ModeOfPaymentValue;
                LTotalAmount.Text = Booking.TotalAmount.ToString();
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

            //Response.Write(ex.Message);
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
}