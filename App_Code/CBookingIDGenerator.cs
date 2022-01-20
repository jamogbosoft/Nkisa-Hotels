using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CBookingIDGenerator
/// </summary>
public class CBookingIDGenerator
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    public string BookingID { get; set; }

    public CBookingIDGenerator()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            BookingID = this.Generate();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string  Generate()
    {
        long milliseconds;

        do
        {
            milliseconds = DateTime.Now.Ticks;
            BookingID = DateTime.Now.Year.ToString() + milliseconds.ToString().Substring(6);

        } while (RecordExist);

        return BookingID;
    }

    /// <summary>
    /// Returns Boolean YES or NO
    /// </summary>
    private bool RecordExist
    {
        get
        {
            SqlConnection con = null;
            SqlDataReader dataReader = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = this.Connectivity.ConnectionString;

                string strSQL = @"SELECT BookingID FROM Bookings WHERE (BookingID = @BookingID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;

                con.Open();
                dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Close();
                    dataReader = null;
                    con.Close();
                    con = null;

                    return true;
                }
                else
                {
                    dataReader.Close();
                    dataReader = null;
                    con.Close();
                    con = null;

                    return false;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con = null;
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader = null;
                }
            }
        }
    }
}