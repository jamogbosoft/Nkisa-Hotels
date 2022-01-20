using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class BookNow_BookingSearch : System.Web.UI.Page
{
    public CBookings Booking;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {               
                CBookNowPolicy BookNowPolicy = new CBookNowPolicy();
                CCancellationPolicy CancellationPolicy = new CCancellationPolicy();

                CQueryStringEncryption QueryString = new CQueryStringEncryption();

                Booking = new CBookings();

                Booking.Branch.BranchID = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["b1"].ToString())));
                Booking.Branch.LoadBranch(Booking.Branch.BranchID);
                Booking.CheckInDate = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["c1"].ToString()));
                Booking.CheckOutDate = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["c2"].ToString()));
                Booking.NumberOfRooms = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["r1"].ToString())));
                Booking.NumberOfAdults = int.Parse(QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["a1"].ToString())));
                
                DataTable dtRoomTypes;
                int intNumberOfNights = (DateTime.Parse(Booking.CheckOutDate) - DateTime.Parse(Booking.CheckInDate)).Days;
                if (intNumberOfNights < 1)
                {                 
                    Response.Redirect("~");
                }
                else
                {
                    Booking.NumberOfNights = intNumberOfNights;
                }
                
                dtRoomTypes = new CRoomTypes(Booking.Branch.BranchID).RoomTypesDataTable();

                ControlBookingHeader1.BranchName = Booking.Branch.BranchName.ToUpper();
                ControlBookingHeader1.BranchAddress = Booking.Branch.Address;
                ControlBookingHeader1.CheckInDate = Booking.CheckInDate;
                ControlBookingHeader1.CheckOutDate = Booking.CheckOutDate;
                ControlBookingHeader1.NumberOfNights = Booking.NumberOfNights.ToString();

                int intCount = dtRoomTypes.Rows.Count;
                int i = 0;

                foreach (ASP.MyUserControlBooking MCBooking in this.phControlBooking.Controls)
                {
                    MCBooking.Booking  = new CBookings();
                    MCBooking.Booking.Branch.BranchID = Booking.Branch.BranchID;
                    MCBooking.Booking.Branch.BranchName = Booking.Branch.BranchName;
                    MCBooking.Booking.Branch.Address = Booking.Branch.Address;
                    MCBooking.Booking.CheckInDate = Booking.CheckInDate;
                    MCBooking.Booking.CheckOutDate = Booking.CheckOutDate;
                    MCBooking.Booking.NumberOfRooms = Booking.NumberOfRooms;
                    MCBooking.Booking.NumberOfAdults = Booking.NumberOfAdults;
                    MCBooking.Booking.NumberOfNights = Booking.NumberOfNights;                    

                    if (i < intCount)
                    {
                        MCBooking.Booking.RoomType.RoomTypeID = int.Parse(dtRoomTypes.Rows[i]["RoomTypeID"].ToString());
                        MCBooking.Booking.RoomType.BranchID = int.Parse(dtRoomTypes.Rows[i]["BranchID"].ToString());
                        MCBooking.Booking.RoomType.RoomTypeName = dtRoomTypes.Rows[i]["RoomTypeName"].ToString();
                        MCBooking.Booking.RoomType.PricePerNight = float.Parse(dtRoomTypes.Rows[i]["PricePerNight"].ToString());
                        MCBooking.Booking.RoomType.BedSize = dtRoomTypes.Rows[i]["BedSize"].ToString();
                        MCBooking.Booking.RoomType.MaxOccupancy = int.Parse(dtRoomTypes.Rows[i]["MaxOccupancy"].ToString());

                        MCBooking.Visible = true;
                        
                        MCBooking.BookNowPolicies = BookNowPolicy.Policies;
                        MCBooking.CancellationPolicies = CancellationPolicy.Policies;
                    }
                    else
                    {
                        MCBooking.Visible = false;
                    }
                    i++;
                }
            }
        }
        catch (Exception ex)
        {
            //Response.Redirect("~");
            Message1.ShowError(ex.Message);
        }
    }
}