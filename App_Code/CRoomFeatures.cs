using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CRoomFeatures
/// </summary>
public class CRoomFeatures
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    public long RoomFeatureID { get; set; }
    public int BranchID { get; set; }
    public int RoomTypeID { get; set; }
    public string RoomFeatureName { get; set; }

    public CRoomFeatures()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            this.RoomFeatureID = 0;
            this.BranchID = this.RoomTypeID = 0;
            this.RoomFeatureName = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Room Features
    /// </summary>
    private void AddRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [RoomFeatures] ([BranchID], [RoomTypeID], [RoomFeatureName]) " +
                                "VALUES (@BranchID, @RoomTypeID, @RoomFeatureName)", con);

            InsertCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;
            InsertCommand.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = this.RoomTypeID;
            InsertCommand.Parameters.Add("@RoomFeatureName", SqlDbType.VarChar).Value = this.RoomFeatureName;

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
    /// Insert new Features
    /// </summary>
    private void AddFeaturesRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [Features] ([FeatureName]) " +
                                "VALUES (@FeatureName)", con);

            InsertCommand.Parameters.Add("@FeatureName", SqlDbType.VarChar).Value = this.RoomFeatureName;

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
    /// Delete this  Room Features
    /// </summary>
    private void DeleteRecord(int RoomFeatureId)
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [RoomFeatures] 
                             WHERE (RoomFeatureID = @RoomFeatureID)", con);

            DeleteCommand.Parameters.Add("@RoomFeatureID", SqlDbType.Int).Value = RoomFeatureId;


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
    /// Delete All  Room Features
    /// </summary>
    private void DeleteAllRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [RoomFeatures]", con);

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
    /// Update Room Features
    /// </summary>
    private void UpdateRecord()
    {
        SqlConnection con = null;

        try
        {
            if (this.RecordExist)
            {
                con = new SqlConnection();
                con.ConnectionString = this.Connectivity.ConnectionString.ToString();

                string strSQL = @"UPDATE RoomFeatures SET                                                            
                                        RoomFeatureName = @RoomFeatureName
                                  WHERE (RoomFeatureID = @RoomFeatureID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@RoomFeatureID", SqlDbType.Int).Value = this.RoomFeatureID;
                cmd.Parameters.Add("@RoomFeatureName", SqlDbType.VarChar).Value = this.RoomFeatureName;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con = null;
            }
            else
            {
                throw new Exception("This booking no longer exist.");
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
        }
    }

    /// <summary>
    /// Update Features
    /// </summary>
    private void UpdateFeaturesRecord()
    {
        SqlConnection con = null;

        try
        {
                            con = new SqlConnection();
                con.ConnectionString = this.Connectivity.ConnectionString.ToString();

                string strSQL = @"UPDATE Features SET                                                            
                                        FeatureName = @FeatureName
                                  WHERE (FeatureID = @FeatureID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@FeatureID", SqlDbType.Int).Value = this.RoomFeatureID;
                cmd.Parameters.Add("@FeatureName", SqlDbType.VarChar).Value = this.RoomFeatureName;

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

                string strSQL = @"SELECT RoomFeatureID FROM RoomFeatures
                                 WHERE (RoomFeatureID = @RoomFeatureID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@RoomFeatureID", SqlDbType.Int).Value = this.RoomFeatureID;

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
    /// Returns Boolean YES or NO
    /// </summary>
    private bool FeaturesRecordExist
    {
        get
        {
            SqlConnection con = null;
            SqlDataReader dataReader = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = this.Connectivity.ConnectionString;

                string strSQL = @"SELECT FeatureID FROM Features
                                 WHERE (FeatureID = @FeatureID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@FeatureID", SqlDbType.Int).Value = this.RoomFeatureID;

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
    /// <returns>Returns Room Features DataTable</returns>
    public DataTable RoomFeaturesDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT rf.RoomFeatureID, rf.BranchID, rf.RoomTypeID, br.BranchName, rt.RoomTypeName, rf.RoomFeatureName
                                FROM RoomFeatures AS rf INNER JOIN
                                    Branch AS br ON rf.BranchID = br.BranchID INNER JOIN
                                    RoomTypes AS rt ON rf.RoomTypeID = rt.RoomTypeID
                                WHERE (rf.BranchID = @BranchID) 
                                  AND (rf.RoomTypeID = @RoomTypeID)
                                ORDER BY  rf.RoomFeatureName", con);

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
    /// <returns>Returns All Features DataTable</returns>
    public DataTable FeaturesDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT FeatureID, FeatureName
                                FROM Features
                                ORDER BY FeatureName", con);

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

    public void UpdateFeature()
    {
        try
        {
            if (this.FeaturesRecordExist)
            {
                this.UpdateFeaturesRecord();
            }
            else
            {
                this.AddFeaturesRecord();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void Delete(int RoomFeatureId)
    {
        try
        {
            this.DeleteRecord(RoomFeatureId);
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