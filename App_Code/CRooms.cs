using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CRooms
/// </summary>
public class CRooms
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    public int BranchID { get; set; }
    public int RoomTypeID { get; set; }
    public string RoomNumber { get; set; }

    public CRooms()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            this.BranchID = this.RoomTypeID = 0;
            this.RoomNumber = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Room 
    /// </summary>
    private void AddRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [Rooms] ([BranchID], [RoomTypeID], [RoomNumber]) " +
                                "VALUES (@BranchID, @RoomTypeID, @RoomNumber)", con);

            InsertCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;
            InsertCommand.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = this.RoomTypeID;
            InsertCommand.Parameters.Add("@RoomNumber", SqlDbType.VarChar).Value = this.RoomNumber;

            adp = new SqlDataAdapter();
            adp.InsertCommand = InsertCommand;

            con.Open();

            adp.InsertCommand.ExecuteNonQuery();

            con.Close();
            con = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// Delete this  Room from this RoomType
    /// </summary>
    private void DeleteRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [Rooms] 
                             WHERE (BranchID = @BranchID)
                                AND (RoomTypeID = @RoomTypeID)
                                AND (RoomNumber = @RoomNumber)", con);

            DeleteCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;
            DeleteCommand.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = this.RoomTypeID;
            DeleteCommand.Parameters.Add("@RoomNumber", SqlDbType.VarChar).Value = this.RoomNumber;
            
            adp = new SqlDataAdapter();
            adp.DeleteCommand = DeleteCommand;

            con.Open();

            adp.DeleteCommand.ExecuteNonQuery();

            con.Close();
            con = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns>Returns Rooms DataTable</returns>
    public DataTable RoomsDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT  rs.BranchID, rs.RoomTypeID, br.BranchName, rt.RoomTypeName, rs.RoomNumber
                                FROM Rooms AS rs INNER JOIN
                                    Branch AS br ON rs.BranchID = br.BranchID INNER JOIN
                                    RoomTypes AS rt ON rs.RoomTypeID = rt.RoomTypeID
                                WHERE (rs.BranchID = @BranchID) 
                                  AND (rs.RoomTypeID = @RoomTypeID)
                                ORDER BY  rs.RoomNumber", con);

            SelectCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;
            SelectCommand.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = this.RoomTypeID;

            adp = new SqlDataAdapter(SelectCommand);

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


    /// <summary>
    /// 
    /// </summary>
    /// <returns>Returns Available Rooms DataTable</returns>
    public DataTable AvailableRoomsDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT RoomNumber
                                FROM Rooms AS rs
                                WHERE (BranchID = @BranchID) 
                                    AND (RoomTypeID = @RoomTypeID) 
                                    AND (RoomNumber NOT IN (
                                            SELECT ra.RoomNumber
                                            FROM RoomAllocation AS ra INNER JOIN
                                                 Bookings AS b ON ra.BookingID = b.BookingID
                                            WHERE (b.BranchID = @BranchID) 
                                                AND (b.RoomTypeID = @RoomTypeID)  
                                                AND (b.CheckOutDate > @TodaysDate)
                                                AND (ra.CheckedOut = @CheckedOutFalse)))", con);

            SelectCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;
            SelectCommand.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = this.RoomTypeID;
            SelectCommand.Parameters.Add("@TodaysDate", SqlDbType.Date).Value = DateTime.Now.Date;
            SelectCommand.Parameters.Add("@CheckedOutFalse", SqlDbType.Bit).Value = false;

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

                string strSQL = @"SELECT RoomNumber FROM Rooms
                                 WHERE (BranchID = @BranchID) 
                                    AND (RoomNumber = @RoomNumber)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = this.BranchID;
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

    public void Add()
    {
        try
        {
            if (!RecordExist)
            {
                this.AddRecord();
            }
            else
            {
                string s = @"This room number already has been added to another room type. 
                        Delete it from the room type where it was added first, before adding it here.";

                throw new Exception(s);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void Delete()
    {
        try
        {
            this.DeleteRecord();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}