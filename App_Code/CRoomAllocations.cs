using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CAllocations
/// </summary>
public class CRoomAllocations
{   
    private CConnectivity Connectivity;

    public string BookingID { get; set; }
    public string RoomNumber { get; set; } 
    public bool  CheckedOut { get; set; }
    public string CheckedOutDate { get; set; }
    public string CheckedOutTime { get; set; }
    public int MaxNumberOfRooms { get; set; }

    public CRoomAllocations()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            MaxNumberOfRooms = 0;
            this.BookingID = this.RoomNumber = this.CheckedOutDate = this.CheckedOutTime = "";
            this.CheckedOut = false;            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public CRoomAllocations(string bookingID)
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            this.BookingID = bookingID;
            MaxNumberOfRooms = 0;
            this.RoomNumber = this.CheckedOutDate = this.CheckedOutTime = "";
            this.CheckedOut = false;           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public CRoomAllocations(string bookingID, int maxNumberOfRooms)
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            this.BookingID = bookingID;
            MaxNumberOfRooms = maxNumberOfRooms;
            this.RoomNumber =this.CheckedOutDate = this.CheckedOutTime = "";
            this.CheckedOut = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Insert new Allocation
    /// </summary>
    private void AddRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"INSERT INTO [RoomAllocation] ([BookingID], [RoomNumber]) " +
                            "VALUES (@BookingID, @RoomNumber)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;
            cmd.Parameters.Add("@RoomNumber", SqlDbType.VarChar).Value = this.RoomNumber;         
                       
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con = null;
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
        }
    }

    public int NumberOfAllocatedRooms
    {
        get
        {
            SqlConnection con = null;

            try
            {
                int intNumberOfAllocatedRooms;
                con = new SqlConnection();
                          
                DataSet ds = new DataSet();

                con.ConnectionString = this.Connectivity.ConnectionString.ToString();

                SqlCommand SelectCommand =
                    new SqlCommand(@"SELECT COUNT(BookingID) AS NumberOfAllocatedRooms
                                 FROM RoomAllocation
                                 WHERE (BookingID = @BookingID)", con);

                SelectCommand.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;

                SqlDataAdapter adp = new SqlDataAdapter(SelectCommand);

                con.Open();

                adp.Fill(ds, "DataTable");

                con.Close();
                con = null;

                intNumberOfAllocatedRooms = int.Parse(ds.Tables["DataTable"].Rows[0]["NumberOfAllocatedRooms"].ToString());

                return intNumberOfAllocatedRooms;
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
            }

        }
    }

    public  void UpdateRoomAllocationStatus()
    {
        SqlConnection con = null;
        try{
            bool blnAllocationCompleted;

            if (this.NumberOfAllocatedRooms < this.MaxNumberOfRooms) { blnAllocationCompleted = false; }
            else { blnAllocationCompleted = true; }

            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"UPDATE Bookings SET  
                                AllocationCompleted = @AllocationCompleted                                                   
                             WHERE (BookingID = @BookingID)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;
            cmd.Parameters.Add("@AllocationCompleted", SqlDbType.Bit).Value = blnAllocationCompleted;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con = null;

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
        }
    }

    /// <summary>
    /// Delete all the allocated rooms for this booking
    /// </summary>
    private void DeleteRecord(int bookingId)
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"DELETE FROM [RoomAllocation] 
                             WHERE (BookingID = @BookingID)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = bookingId;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con = null;
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
        }
    }

    /// <summary>
    /// Delete only this room number from the booking with booking id = bookingId
    /// </summary>
    private void DeleteRecord(int bookingId, int roomNumber)
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"DELETE FROM [RoomAllocation] 
                             WHERE (BookingID = @BookingID) 
                                AND (RoomNumber = @RoomNumber)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = bookingId;
            cmd.Parameters.Add("@RoomNumber", SqlDbType.VarChar).Value = roomNumber;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con = null;
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
        }
    }

    /// <summary>
    /// Delete All Allocations
    /// </summary>
    private void DeleteAllRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"DELETE FROM [RoomAllocation])";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con = null;
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
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Returns Room Allocations DataTable</returns>
    public DataTable RoomAllocationsDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT BookingID, RoomNumber, CheckedOut
                                 FROM RoomAllocation
                                 WHERE (BookingID = @BookingID)", con);

            SelectCommand.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;

            SqlDataAdapter adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            return ds.Tables["DataTable"];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public void Add()
    {
        try
        {
            if (!this.RecordExist)
            {
                this.AddRecord();
                this.UpdateRoomAllocationStatus();
            }
            else
            {
                throw new Exception("You've already allocated this room to this booking");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Delete(int bookingId, int roomNumber)
    {
        try
        {
            this.DeleteRecord(bookingId, roomNumber);
            this.UpdateRoomAllocationStatus();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void DeleteAll()
    {
        try
        {
            this.DeleteAllRecord();
            this.UpdateRoomAllocationStatus();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void CheckOut()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"UPDATE RoomAllocation SET                                                            
                                CheckedOut = @CheckedOut,
                                CheckedOutDate = @CheckedOutDate,
                                CheckedOutTime = @CheckedOutTime                                
                             WHERE (BookingID = @BookingID) 
                                AND (RoomNumber = @RoomNumber)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;
            cmd.Parameters.Add("@RoomNumber", SqlDbType.VarChar).Value = this.RoomNumber;
            cmd.Parameters.Add("@CheckedOut", SqlDbType.Bit).Value = this.CheckedOut;
            cmd.Parameters.Add("@CheckedOutDate", SqlDbType.Date).Value = DateTime.Parse(this.CheckedOutDate).Date;
            cmd.Parameters.Add("@CheckedOutTime", SqlDbType.Time).Value = DateTime.Parse(this.CheckedOutTime).TimeOfDay;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con = null;

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
        }
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

                string strSQL = @"SELECT BookingID FROM RoomAllocation
                                 WHERE (BookingID = @BookingID) 
                                    AND (RoomNumber = @RoomNumber)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;
                cmd.Parameters.Add("@RoomNumber", SqlDbType.VarChar).Value = this.RoomNumber;

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
