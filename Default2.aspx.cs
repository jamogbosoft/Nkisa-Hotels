using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long milliseconds = DateTime.Now.Ticks;
        string s = milliseconds.ToString();

        long millisecondss = DateTime.Now.Ticks;
        string ss = DateTime.Now.Year.ToString() + millisecondss.ToString().Substring(6);

        CBookingIDGenerator Generator = new CBookingIDGenerator();

        Message1.ShowMessage(s + ", " + ss + " , " + Generator.BookingID);
    }
}