using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RoomAllocations : System.Web.UI.Page
{
    private bool blnEnableDropDownList = false;

    private CConnectivity Connectivity = new CConnectivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillBranch();
                FillRoomTypes();
                FillRooms();

                this.RefreshControls();
            }
            catch (Exception ex)
            {
                this.Message1.ShowError(ex.Message.ToString(), "Error Initializing");
            }
        }
    }

    private void RefreshControls()
    {
        try
        {
            LoadDataGridViewBookings();
            txtBookingID.Text = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadDataGridViewBookings()
    {
        try
        {
            CBookingStatus BookingStatus = new CBookingStatus(cboNewBookings);

            GridViewBookings.DataSource = new CBookings().BookingsDataTable(BookingStatus);
            GridViewBookings.SelectedIndex = -1;
            GridViewBookings.Columns[1].Visible = true;
            GridViewBookings.DataBind();
            GridViewBookings.Columns[1].Visible = false;

            ClearDataDridViewAllocations();
            EnableAllocationButton();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private DataTable LoadDataGridViewBookingsSearch(string bookingId)
    {
        try
        {
            CBookings Booking = new CBookings();
            DataTable dt = Booking.BookingsDataTable(bookingId);
            GridViewBookings.DataSource = dt;
            GridViewBookings.SelectedIndex = -1;
            GridViewBookings.Columns[1].Visible = true;
            GridViewBookings.DataBind();

            GridViewBookings.Columns[1].Visible = false;

            ClearDataDridViewAllocations();

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadDataGridViewAllocations()
    {
        try
        {
            GridViewBookings.Columns[1].Visible = true;
            string strBookingID = GridViewBookings.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", "");
            GridViewBookings.Columns[1].Visible = false;

            GridViewRoomAllocations.DataSource = new CRoomAllocations(strBookingID).RoomAllocationsDataTable();
            GridViewRoomAllocations.SelectedIndex = -1;
            //GridViewRoomAllocations.Columns[1].Visible = true;
            GridViewRoomAllocations.DataBind();
            //GridViewRoomAllocations.Columns[1].Visible = false;

            CBookings Booking = new CBookings();
            Booking.LoadBooking(strBookingID);

            lblCustomerName.Text = Booking.CustomersName;
            lblEmailAddress.Text = Booking.Email;
            lblPhoneNumber.Text = Booking.PhoneNumber;
            lblBookingID.Text = Booking.BookingID;
            lblBranch.Text = Booking.Branch.BranchName;
            lblRoomType.Text = Booking.RoomType.RoomTypeName;
            lblPricePerNight.Text = Booking.RoomType.PricePerNight.ToString("N 0,000.00");
            lblBookingDateAndTime.Text = Booking.BookingDateAndTime;
            lblCheckInDate.Text = Booking.CheckInDate;
            lblCheckOutDate.Text = Booking.CheckOutDate;
            lblNumberOfNights.Text = Booking.NumberOfNightsInWords;
            lblNumberOfRooms.Text = Booking.NumberOfRoomsInWords;
            lblNumberOfAdults.Text = Booking.NumberOfAdultsInWords;
            lblTotalAmount.Text = Booking.TotalAmount.ToString("N 0,000.00");
            lblModeOfPayment.Text = Booking.ModeOfPayment.ModeOfPaymentName;

            if (Booking.PaymentCompleted)
            {
                lblPaymentCompleted.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblPaymentCompleted.ForeColor = System.Drawing.Color.Red;
            }

            lblPaymentCompleted.Text = Booking.PaymentCompleted.ToString();


            if (Booking.RoomAllocationCompleted)
            {
                lblRoomAllocationCompleted.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblRoomAllocationCompleted.ForeColor = System.Drawing.Color.Red;
            }

            lblRoomAllocationCompleted.Text = Booking.RoomAllocationCompleted.ToString();

            if (Booking.BookingCancelled)
            {
                lblBookingCancelled.ForeColor = System.Drawing.Color.Red;
                lblCancellationDate.ForeColor = System.Drawing.Color.Red;

                lblCancellationDateCaption.Visible = true;
                lblCancellationDate.Visible = true;

                lblCancellationDate.Text = Booking.CancellationDate;
            }
            else
            {
                lblBookingCancelled.ForeColor = System.Drawing.Color.Green;
                lblCancellationDate.ForeColor = System.Drawing.Color.Green;

                lblCancellationDateCaption.Visible = false;
                lblCancellationDate.Visible = false; ;

                lblCancellationDate.Text = "";
            }

            lblBookingCancelled.Text = Booking.BookingCancelled.ToString();


            cboBranch.SelectedIndex = cboBranch.Items.IndexOf(cboBranch.Items.FindByValue(Booking.Branch.BranchID.ToString()));
            FillRoomTypes();

            cboRoomType.SelectedIndex = cboRoomType.Items.IndexOf(cboRoomType.Items.FindByValue(Booking.RoomType.RoomTypeID.ToString()));
            FillRooms();

            EnableAllocationButton();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// private void Fill Branch
    /// </summary>
    private void FillBranch()
    {
        try
        {
            cboBranch.DataSource = new CBranch().BranchDataTable();
            cboBranch.DataTextField = "BranchName";
            cboBranch.DataValueField = "BranchID";
            cboBranch.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// private void Fill Room Types
    /// </summary>
    private void FillRoomTypes()
    {
        try
        {
            CRoomTypes RoomType = new CRoomTypes();
            RoomType.BranchID = int.Parse(cboBranch.SelectedValue.ToString());

            cboRoomType.DataSource = RoomType.RoomTypesDataTable4ComboBox();
            cboRoomType.DataTextField = "RoomTypeName";
            cboRoomType.DataValueField = "RoomTypeID";
            cboRoomType.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// private void Fill Rooms
    /// </summary>
    private void FillRooms()
    {
        try
        {
            CRooms Room = new CRooms();
            Room.BranchID = int.Parse(cboBranch.SelectedValue.ToString());
            Room.RoomTypeID = int.Parse(cboRoomType.SelectedValue.ToString());

            cboRoomNumber.DataSource = Room.AvailableRoomsDataTable();
            cboRoomNumber.DataTextField = "RoomNumber";
            cboRoomNumber.DataValueField = "RoomNumber";
            cboRoomNumber.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private bool EnableDropDownList
    {
        get { return blnEnableDropDownList; }
        set
        {
            cboNewBookings.Enabled = value;

            blnEnableDropDownList = value;
        }
    }


    protected void GridViewBookings_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewBookings.SelectedRow != null)
            {
                LoadDataGridViewAllocations();
            }
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
    protected void GridViewBookings_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            CBookingStatus BookingStatus = new CBookingStatus(cboNewBookings);

            GridViewBookings.DataSource = new CBookings().BookingsDataTable(BookingStatus);
            GridViewBookings.SelectedIndex = -1;
            GridViewBookings.Columns[1].Visible = true;
            GridViewBookings.PageIndex = e.NewPageIndex;
            GridViewBookings.DataBind();
            GridViewBookings.Columns[1].Visible = false;

            ClearDataDridViewAllocations();
            EnableAllocationButton();
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }

    }

    private void ClearDataDridViewAllocations()
    {
        try
        {
            GridViewRoomAllocations.DataSource = new DataTable();
            GridViewRoomAllocations.SelectedIndex = -1;
            GridViewRoomAllocations.DataBind();

            ClearControls();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ClearControls()
    {
        try
        {
            lblCustomerName.Text = "";
            lblEmailAddress.Text = "";
            lblPhoneNumber.Text = "";
            lblBookingID.Text = "";
            lblBranch.Text = "";
            lblRoomType.Text = "";
            lblPricePerNight.Text = "";
            lblBookingDateAndTime.Text = "";
            lblCheckInDate.Text = "";
            lblCheckOutDate.Text = "";
            lblNumberOfNights.Text = "";
            lblNumberOfRooms.Text = "";
            lblNumberOfAdults.Text = "";
            lblTotalAmount.Text = ""; ;
            lblModeOfPayment.Text = "";
            lblPaymentCompleted.Text = "";
            lblRoomAllocationCompleted.Text = "";
            lblBookingCancelled.Text = "";
            lblCancellationDate.Text = "";
            lblCancellationDateCaption.Visible = false;
            lblCancellationDate.Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnAllocate_Click(object sender, EventArgs e)
    {

        try
        {
            if (GridViewBookings.SelectedRow != null)
            {
                if (cboRoomNumber.SelectedIndex != -1)
                {
                    string strBookingID = GridViewBookings.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", "");
                    CBookingStatus BookingStatus = new CBookingStatus(strBookingID);

                    if (BookingStatus.PaymentCompleted && !BookingStatus.RoomAllocationCompleted && !BookingStatus.BookingCancelled)
                    {
                        string strRoomNumber = cboRoomNumber.SelectedItem.Text;

                        CRoomAllocations RoomAllocation = new CRoomAllocations();
                        RoomAllocation.BookingID = strBookingID;
                        RoomAllocation.RoomNumber = strRoomNumber;
                        RoomAllocation.MaxNumberOfRooms = BookingStatus.NumberOfRooms;
                        if (RoomAllocation.MaxNumberOfRooms > RoomAllocation.NumberOfAllocatedRooms)
                        {
                            RoomAllocation.Add();
                        }
                        else
                        {
                            RoomAllocation.UpdateRoomAllocationStatus();
                            this.Message1.ShowError("You've already completed this booking's room allocation","Room Allocation Not Successful");
                        }
                    }
                    else if (!BookingStatus.PaymentCompleted)
                    {
                        this.Message1.ShowError("This booking’s payment is not completed", "Room Allocation Not Successful");
                    }
                    else if (BookingStatus.RoomAllocationCompleted)
                    {
                        this.Message1.ShowError("This booking’s room allocation is already completed", "Room Allocation Not Successful");
                    }
                    else if (BookingStatus.BookingCancelled)
                    {
                        this.Message1.ShowError("This booking’s has been cancelled", "Room Allocation Not Successful");
                    }

                    LoadDataGridViewAllocations();
                }
                else { this.Message1.ShowError("Select the room number first.", "Room Number Not Successful"); }
            }
            else { this.Message1.ShowError("Select a booking first.", "Room Allocation Not Successful"); }
            EnableAllocationButton();
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }


    protected void ImageBtnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void cboNewBookings_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.RefreshControls();
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.LoadDataGridViewBookingsSearch(txtBookingID.Text).Rows.Count != 0)
            {
                txtBookingID.Text = "";
            }
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    private bool IsEnableAllocationButton
    {
        get
        {
            try
            {
                if (IsPostBack && GridViewBookings.SelectedIndex != -1)                     //GridViewBookings.SelectedRow.RowIndex != -1)
                {
                    string strBookingID = GridViewBookings.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", "");
                    CBookingStatus BookingStatus = new CBookingStatus(strBookingID);

                    if (BookingStatus.PaymentCompleted && !BookingStatus.RoomAllocationCompleted && !BookingStatus.BookingCancelled)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    private void EnableAllocationButton()
    {
        try
        {
            if (IsEnableAllocationButton)
            {
                btnAllocate.CssClass = "okbuttonlarge";
                btnAllocate.Enabled = true;
            }
            else
            {
                btnAllocate.CssClass = "okbuttonlargedark";
                btnAllocate.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridViewAllocations_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Create the code to delete this allocation



            EnableAllocationButton();
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }

    protected void GridViewAllocations_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillRoomTypes();
            FillRooms();
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
    protected void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillRooms();
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
}
