using System;
using System.Web.UI;
using System.Data;
using System.Web;

public partial class UserControls_UserControlBooking : System.Web.UI.UserControl
{
    public CBookings Booking = new CBookings();

    public string BookNowPolicies { get; set; }
    public string CancellationPolicies { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
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

                /////////////////////////////////        

                for (int i = 1; i <= 50; i++)
                {
                    cboNumberOfRooms.Items.Add(i.ToString());
                }
                cboNumberOfRooms.Text = Booking.NumberOfRooms.ToString();

                this.FillComboNumberOfAdults();

                imgMan.ImageUrl = "~/Images/png/man" + Booking.RoomType.MaxOccupancy.ToString() + ".png";
                imgMan.AlternateText = "Maximum occupancy is " + Booking.RoomType.MaxOccupancyInWords.ToLower();
                imgMan.ToolTip = imgMan.AlternateText;

                lblBookNowPolicyText.Text = BookNowPolicies;
                lblCancellationPolicyText.Text = CancellationPolicies;

                imgLogo.ImageUrl = "~/Images/RoomTypes/" + Booking.RoomType.RoomTypeID.ToString() + ".jpg";
                imgProperties.ImageUrl = imgLogo.ImageUrl;

                lblRoomType.Text = Booking.RoomType.RoomTypeName;
                lblRoomType2.Text = Booking.RoomType.RoomTypeName;
                imgLogo.AlternateText = Booking.RoomType.RoomTypeName;

                lblBedSize.Text = Booking.RoomType.BedSize;
                lblMaximumOccupancy.Text = Booking.RoomType.MaxOccupancyInWords;

                lblPriceforOneNight.Text = Booking.RoomType.PricePerNight.ToString("N 0,000.00");

                lblPriceforTotalNightCaption.Text = "Total price for " + Booking.NumberOfNightsInWords.ToLower();

                lblPriceforTotalNights.Text = TotalAmount().ToString("N 0,000.00");

                CRoomFeatures RoomFeature = new CRoomFeatures();
                RoomFeature.BranchID = Booking.RoomType.BranchID;
                RoomFeature.RoomTypeID = Booking.RoomType.RoomTypeID;

                GridViewRoomFeatures.DataSource = RoomFeature.RoomFeaturesDataTable();
                GridViewRoomFeatures.DataBind();
            }
            else
            {
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
            }
        }
        catch (Exception ex)
        {
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

            Booking.TotalAmount = totalAmount;
            return totalAmount;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillComboNumberOfAdults()
    {
        try
        {
            int j = Booking.NumberOfRooms;
            int k = j * Booking.RoomType.MaxOccupancy;
            cboNumberOfAdults.Items.Clear();
            for (int i = 1; i <= k; i++)
            {
                cboNumberOfAdults.Items.Add(i.ToString());
            }
            if (cboNumberOfAdults.Items.Count >= Booking.NumberOfAdults)
            {
                cboNumberOfAdults.Text = Booking.NumberOfAdults.ToString();
            }
            else
            {
                cboNumberOfAdults.Text = k.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            Booking.NumberOfRooms = int.Parse(cboNumberOfRooms.Text.ToString());
            Booking.NumberOfAdults = int.Parse(cboNumberOfAdults.Text.ToString());

            CQueryStringEncryption QueryString = new CQueryStringEncryption();

            string strUrl = "~/BookNow/BookingReview.aspx?" +
                    "b1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.Branch.BranchID.ToString())) +
                    "&r2=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.RoomType.RoomTypeID.ToString())) +
                    "&c1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.CheckInDate)) +
                    "&c2=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.CheckOutDate)) +
                    "&r1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.NumberOfRooms.ToString())) +
                    "&a1=" + HttpUtility.UrlEncode(QueryString.Encrypt(Booking.NumberOfAdults.ToString()));

            Response.Redirect(strUrl);
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }
    }
    protected void cboNumberOfRooms_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Booking.NumberOfRooms = int.Parse(cboNumberOfRooms.Text.ToString());
            lblPriceforTotalNights.Text = this.TotalAmount().ToString("N 0,000.00");
            this.FillComboNumberOfAdults();
            cboNumberOfAdults.Text = cboNumberOfRooms.SelectedItem.Text;
        }
        catch (Exception ex)
        {
            Message1.ShowMessage(ex.Message);
        }
    }
}