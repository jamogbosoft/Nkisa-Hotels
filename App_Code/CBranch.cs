using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CBranch
/// </summary>
public class CBranch
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    public int BranchID { get; set; }
    public string BranchName { get; set; }
    public string Address { get; set; }

    public CBranch()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            this.BranchID = 0;
            this.BranchName = this.Address = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Branch
    /// </summary>
    private void AddRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [Branch] ([BranchName], [Address]) " +
                                "VALUES (@BranchName, @Address)", con);

            InsertCommand.Parameters.Add("@BranchName", SqlDbType.VarChar).Value = this.BranchName;
            InsertCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = this.Address;

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
    /// Delete this  Branch
    /// </summary>
    private void DeleteRecord(int BranchId)
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [Branch] 
                             WHERE (BranchID = @BranchID)", con);

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
    /// Delete All  Branch
    /// </summary>
    private void DeleteAllRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [Branch]", con);

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
    /// Update Branch
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

                string strSQL = @"UPDATE Branch SET                                                            
                                BranchName = @BranchName,
                                Address = @Address                               
                             WHERE (BranchID = @BranchID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.BranchID;
                cmd.Parameters.Add("@BranchName", SqlDbType.VarChar).Value = this.BranchName;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = this.Address;
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con = null;
            }
            else
            {
                throw new Exception("This branch no longer exist.");
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

                string strSQL = @"SELECT BranchID FROM Branch
                                  WHERE (BranchID = @BranchID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

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

    
    /// <returns>Returns Branch DataTable</returns>
    public DataTable BranchDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT BranchID, BranchName, Address
                                FROM Branch
                                ORDER BY BranchID", con);

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
    
    public void LoadBranch(int branchId)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT BranchID,  BranchName, Address
                                FROM Branch
                                WHERE BranchID = @BranchID", con);

            SelectCommand.Parameters.Add("@BranchID", SqlDbType.Int).Value = branchId;

            adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];

            if (dt.Rows.Count != 0)
            {

                this.BranchID = int.Parse(dt.Rows[0]["BranchID"].ToString());
                this.BranchName = dt.Rows[0]["BranchName"].ToString();
                this.Address = dt.Rows[0]["Address"].ToString();
            }
            else
            {
                throw new Exception("The branch you specified does not exist.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*
    public void LoadBranch(string  branchName)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT BranchID,  BranchName, Address
                                FROM Branch
                                WHERE BranchName = @BranchName", con);

            SelectCommand.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchName;

            adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];

            if (dt.Rows.Count != 0)
            {

                this.BranchID = int.Parse(dt.Rows[0]["BranchID"].ToString());
                this.BranchName = dt.Rows[0]["BranchName"].ToString();
                this.Address = dt.Rows[0]["Address"].ToString();
            }
            else
            {
                throw new Exception("The branch you specified does not exist.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    */
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
                throw new Exception("This branch type no longer exist.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Delete(int BranchId)
    {
        try
        {
            this.DeleteRecord(BranchId);
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