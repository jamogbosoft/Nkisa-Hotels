using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CRoomNumbers
/// </summary>
public class CRoomNumbers
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    public long RoomID { get; set; }
    public string RoomNumber { get; set; }

    public CRoomNumbers()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            this.RoomID = 0;
            this.RoomNumber = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// Insert new Room Number
    /// </summary>
    private void AddRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [RoomNumbers] ([RoomNumber]) " +
                                "VALUES (@RoomNumber)", con);

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
    /// Update Room Numbers
    /// </summary>
    private void UpdateRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"UPDATE RoomNumbers SET                                                            
                                     RoomNumber = @RoomNumber
                                  WHERE (RoomID = @RoomID)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = this.RoomID;
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

                string strSQL = @"SELECT RoomNumber FROM RoomNumbers
                                 WHERE (RoomID = @RoomID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = this.RoomID;

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


    /// <summary>
    /// 
    /// </summary>
    /// <returns>Returns All Room Numbers DataTable</returns>
    public DataTable RoomNumbersDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT RoomID, RoomNumber
                                FROM RoomNumbers
                                ORDER BY RoomNumber", con);

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
    /// <returns>Returns The Available Room Numbers that has never been assigned to any Room Type</returns>
    public DataTable AvailableRoomNumbersDataTable(int intBranchId)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT RoomID, RoomNumber
                                FROM RoomNumbers
                                WHERE (RoomNumber NOT IN (
                                            SELECT RoomNumber
                                            FROM Rooms
                                            WHERE (BranchID = @BranchID)))
                                ORDER BY RoomNumber", con);

            SelectCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = intBranchId;

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

    public void Add()
    {
        try
        {
            this.AddRecord();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
      

    public void Update()
    {
        try
        {
            if (this.RecordExist)
            {
                this.UpdateRecord();
            }
            else
            {
                this.AddRecord();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}