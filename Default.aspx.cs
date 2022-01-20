using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    static string strCheckInDate, strCheckOutDate;
    string[] d;
    DateTime TempDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                this.FillBranch();
                this.FillRoomsAndAdults();

                //DateTime d = DateTime.Parse("02/08/2009");
                string strDefaultCheckInDate = DateTime.Now.Date.ToShortDateString();
                string strDefaultCheckOutDate = DateTime.Now.Date.Add(new TimeSpan(1, 0, 0, 0)).ToShortDateString();

                customCalendarExtenderCheckIn.StartDate = DateTime.Parse(strDefaultCheckInDate);
                //customCalendarExtenderCheckIn.SelectedDate = DateTime.Parse(strDefaultCheckInDate);

                customCalendarExtenderCheckOut.StartDate = DateTime.Parse(strDefaultCheckOutDate);
                //customCalendarExtenderCheckOut.SelectedDate = DateTime.Parse(strDefaultCheckOutDate);
            }
            else
            {
                txtCheckIn.ReadOnly = false;
            }
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
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
    /// private void Fill Rooms And Adults
    /// </summary>
    private void FillRoomsAndAdults()
    {
        try
        {
            for (int i = 1; i <= 50; i++)
            {
                cboNumberOfRooms.Items.Add(i.ToString());
                cboNumberOfAdults.Items.Add(i.ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtCheckIn_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtCheckOut.Text = "";
            lblNumberOfNights.Text = "";

            strCheckInDate = txtCheckIn.Text.ToString();
            d = strCheckInDate.Split(' ');
            strCheckInDate = new CMonth(d[1].ToString()).Month + "/" + d[0].ToString() + "/" + d[2].ToString();
            if (DateTime.TryParse(strCheckInDate, out TempDate))
            {
                string strCheckOutDate = TempDate.AddDays(1).ToShortDateString();

                customCalendarExtenderCheckOut.StartDate = DateTime.Parse(strCheckOutDate);
                customCalendarExtenderCheckOut.SelectedDate = DateTime.Parse(strCheckOutDate);

                txtCheckOut.Focus();
            }
            else
            {
                Message1.ShowError("Check-In Date is not correct.");
                txtCheckIn.Focus();
            }
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }
    }
    protected void txtCheckOut_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtCheckOut.Text != "")
            {
                string strCheckOutDate = txtCheckOut.Text.ToString();
                d = strCheckOutDate.Split(' ');
                strCheckOutDate = new CMonth(d[1].ToString()).Month + "/" + d[0].ToString() + "/" + d[2].ToString();

                if (!DateTime.TryParse(strCheckOutDate, out TempDate))
                {
                    Message1.ShowError("Check-Out Date is not correct.");
                    txtCheckOut.Focus();
                    return;
                }
                else
                {
                    lblNumberOfNights.Text = (DateTime.Parse(strCheckOutDate) - DateTime.Parse(strCheckInDate)).Days.ToString();
                    customCalendarExtenderCheckOut.SelectedDate = DateTime.Parse(strCheckOutDate);

                    if (lblNumberOfNights.Text == "1") { txtCheckOut.Focus(); }
                }
            }
            else
            {
                lblNumberOfNights.Text = "";
            }
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            CQueryStringEncryption QueryString = new CQueryStringEncryption();

            if (lblNumberOfNights.Text != "")
            {
                string strUrl = "~/BookNow/BookingSearch.aspx?" +
                    "b1=" + HttpUtility.UrlEncode(QueryString.Encrypt(cboBranch.SelectedValue.ToString())) +
                    "&c1=" +  HttpUtility.UrlEncode(QueryString.Encrypt(txtCheckIn.Text.ToString())) +
                    "&c2=" +  HttpUtility.UrlEncode(QueryString.Encrypt(txtCheckOut.Text.ToString())) +
                    "&r1=" +  HttpUtility.UrlEncode(QueryString.Encrypt(cboNumberOfRooms.Text.ToString())) +
                    "&a1=" +  HttpUtility.UrlEncode(QueryString.Encrypt(cboNumberOfAdults.Text.ToString()));

                Response.Redirect(strUrl);
            }
            else
            {
                Message1.ShowError("Check-In date or Check-Out date is not in the correct format.");
            }
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
            cboNumberOfAdults.Text = cboNumberOfRooms.SelectedItem.Text;
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }
    }
    
}
