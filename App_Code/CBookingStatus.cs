
/// <summary>
/// Summary description for CBookingStatus
/// </summary>
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System;
public class CBookingStatus
{
    private bool blnllocated, blnNon_Allocated, blnExpired;
    private bool blnPaymentCompleted, blnRoomAllocationCompleted, blnBookingCancelled;
    private string strCancellationDate, strCancellationTime;
    private int intNumberOfRooms;

    public CBookingStatus(DropDownList cboStatus)
    {
        blnllocated = blnNon_Allocated = blnExpired = false;
        blnPaymentCompleted = blnRoomAllocationCompleted = blnBookingCancelled = false;
        strCancellationDate = strCancellationTime = "";
        intNumberOfRooms = 0;

        string s = cboStatus.Text.ToString();
        if (s.ToUpper() == "NON-ALLOCATED BOOKINGS") { blnNon_Allocated = true; }
        else if (s.ToUpper() == "ALLOCATED BOOKINGS") { blnllocated = true; }
        else if (s.ToUpper() == "EXPIRED BOOKINGS") { blnExpired = true; }
    }

    public CBookingStatus(string bookingId)
    {
        try
        {
            blnllocated = blnNon_Allocated = blnExpired = false;

            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(new CConnectivity().ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT PaymentCompleted, AllocationCompleted, BookingCancelled, 
                                    CancellationDate, CancellationTime, NumberOfRooms 
                                FROM Bookings 
                                WHERE BookingID = @BookingID", con);

            SelectCommand.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = bookingId;

            SqlDataAdapter adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];

            if (dt.Rows.Count != 0)
            {
                blnPaymentCompleted = bool.Parse(dt.Rows[0]["PaymentCompleted"].ToString());
                blnRoomAllocationCompleted = bool.Parse(dt.Rows[0]["AllocationCompleted"].ToString());
                blnBookingCancelled = bool.Parse(dt.Rows[0]["BookingCancelled"].ToString());
                strCancellationDate = dt.Rows[0]["CancellationDate"].ToString();
                strCancellationTime = dt.Rows[0]["CancellationTime"].ToString();
                intNumberOfRooms = int.Parse(dt.Rows[0]["NumberOfRooms"].ToString());
            }
            else
            {
                blnPaymentCompleted = blnRoomAllocationCompleted = blnBookingCancelled = false;
                strCancellationDate = strCancellationTime = "";
                intNumberOfRooms = 0;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public bool Allocated { get { return blnllocated; } }
    public bool Non_Allocated { get { return blnNon_Allocated; } }
    public bool Expired { get { return blnExpired; } }

    public bool PaymentCompleted { get { return blnPaymentCompleted; } }
    public bool RoomAllocationCompleted { get { return blnRoomAllocationCompleted; } }
    public bool BookingCancelled { get { return blnBookingCancelled; } }
    public string CancellationDate { get { return strCancellationDate; } }
    public string CancellationTime { get { return strCancellationTime; } }

    public int NumberOfRooms { get { return intNumberOfRooms; } }
}