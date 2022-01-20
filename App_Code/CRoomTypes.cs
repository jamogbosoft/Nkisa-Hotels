using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CRoomTypes
/// </summary>
public class CRoomTypes
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    public int RoomTypeID { get; set; }
    public int BranchID { get; set; }
    public string RoomTypeName { get; set; }
    public float PricePerNight { get; set; }
    public string BedSize { get; set; }
    public int MaxOccupancy { get; set; }
    public string MaxOccupancyInWords { get { return new CNumberOfAdultsInWords(this.MaxOccupancy).InWords; } }

    public CRoomTypes()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            this.BranchID = this.RoomTypeID = this.MaxOccupancy = 0;
            this.RoomTypeName = this.BedSize = "";
            this.PricePerNight = 0f;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public CRoomTypes(int branchId )
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            this.BranchID = branchId;
            this.RoomTypeID = this.MaxOccupancy = 0;
            this.RoomTypeName = this.BedSize = "";
            this.PricePerNight = 0f;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Room Types
    /// </summary>
    private void AddRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [RoomTypes] ([BranchID], [RoomTypeName], [PricePerNight], [BedSize], [MaxOccupancy]) " +
                                "VALUES (@BranchID, @RoomTypeName, @PricePerNight, @BedSize, @MaxOccupancy)", con);

            InsertCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;
            InsertCommand.Parameters.Add("@RoomTypeName", SqlDbType.VarChar).Value = this.RoomTypeName;
            InsertCommand.Parameters.Add("@PricePerNight", SqlDbType.Float).Value = this.PricePerNight;
            InsertCommand.Parameters.Add("@BedSize", SqlDbType.VarChar).Value = this.BedSize;
            InsertCommand.Parameters.Add("@MaxOccupancy", SqlDbType.Int).Value = this.MaxOccupancy;

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
    /// Delete this  Room Types
    /// </summary>
    private void DeleteRecord(int RoomTypeId, int BranchId)
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [RoomTypes] 
                             WHERE (RoomTypeID = @RoomTypeID)
                                 AND (BranchID = @BranchID)", con);

            DeleteCommand.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = RoomTypeId;
            DeleteCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = BranchId;

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
    /// Delete All  Room Types
    /// </summary>
    private void DeleteAllRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [RoomTypes]", con);

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
    /// Update RoomType
    /// </summary>
    private void UpdateRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"UPDATE RoomTypes SET                                                            
                                RoomTypeName = @RoomTypeName,
                                PricePerNight = @PricePerNight,
                                BedSize = @BedSize,
                                MaxOccupancy = @MaxOccupancy
                             WHERE (RoomTypeID = @RoomTypeID)
                                AND (BranchID = @BranchID)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = this.RoomTypeID;
            cmd.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;
            cmd.Parameters.Add("@RoomTypeName", SqlDbType.VarChar).Value = this.RoomTypeName;
            cmd.Parameters.Add("@PricePerNight", SqlDbType.Float).Value = this.PricePerNight;
            cmd.Parameters.Add("@BedSize", SqlDbType.VarChar).Value = this.BedSize;
            cmd.Parameters.Add("@MaxOccupancy", SqlDbType.Int).Value = this.MaxOccupancy;

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

                string strSQL = @"SELECT RoomTypeID FROM RoomTypes
                                  WHERE (RoomTypeID = @RoomTypeID)
                                       AND (BranchID = @BranchID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = this.RoomTypeID;
                cmd.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;

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
    /// <returns>Returns Room Types DataTable</returns>
    public DataTable RoomTypesDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT rt.RoomTypeID, rt.BranchID, rt.RoomTypeName, br.BranchName, rt.PricePerNight, rt.BedSize, rt.MaxOccupancy
                                FROM RoomTypes AS rt INNER JOIN
                                     Branch AS br ON rt.BranchID = br.BranchID
                                WHERE (rt.BranchID = @BranchID)
                                ORDER BY rt.PricePerNight", con);

            SelectCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;

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
    /// <returns>Returns Room Types DataTable 4 Combo Box</returns>
    public DataTable RoomTypesDataTable4ComboBox()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT RoomTypeID, RoomTypeName
                                FROM RoomTypes
                                WHERE (BranchID = @BranchID)
                                ORDER BY RoomTypeName", con);

            SelectCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;

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

    public void LoadRoomType(int branchID, int roomTypeID)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT rt.RoomTypeID, rt.BranchID, rt.RoomTypeName, br.BranchName, rt.PricePerNight, rt.BedSize, rt.MaxOccupancy
                                FROM RoomTypes AS rt INNER JOIN
                                     Branch AS br ON rt.BranchID = br.BranchID
                                WHERE (rt.BranchID = @BranchID) 
                                  AND (rt.RoomTypeID = @RoomTypeID)
                                ORDER BY rt.PricePerNight", con);

            SelectCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = branchID;
            SelectCommand.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = roomTypeID;

            adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];

            if (dt.Rows.Count != 0)
            {
                this.BranchID = branchID;
                this.RoomTypeID = roomTypeID;
                this.BedSize = dt.Rows[0]["BedSize"].ToString();
                this.MaxOccupancy = int.Parse(dt.Rows[0]["MaxOccupancy"].ToString());
                this.PricePerNight = int.Parse(dt.Rows[0]["PricePerNight"].ToString());
                this.RoomTypeName = dt.Rows[0]["RoomTypeName"].ToString();
            }
            else
            {
                throw new Exception("The room type you specified does not exist.");
            }
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

    public void Delete(int RoomTypeId, int BranchId)
    {
        try
        {
            this.DeleteRecord(RoomTypeId, BranchId);
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
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}