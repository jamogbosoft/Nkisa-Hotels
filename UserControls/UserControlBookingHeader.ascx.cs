using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class User_ControlBookingHeader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string BranchName { get { return lblBranchName.Text.ToString(); } set { lblBranchName.Text = value; } }
    public string BranchAddress { get { return lblBranchAddress.Text.ToString(); } set { lblBranchAddress.Text = value; } }
    public string CheckInDate { get { return lblCheckInDate.Text.ToString(); } set { lblCheckInDate.Text = DateTime.Parse(value).ToLongDateString(); } }
    public string CheckOutDate { get { return lblCheckOutDate.Text.ToString(); } set { lblCheckOutDate.Text = DateTime.Parse(value).ToLongDateString(); } }
    public string NumberOfNights { get { return lblNumberOfNights.Text.ToString(); } set { lblNumberOfNights.Text = value; } }
}