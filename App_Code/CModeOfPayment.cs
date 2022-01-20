using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CModeOfPayment
/// </summary>
public class CModeOfPayment
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    public int ModeOfPaymentID { get; set; }
    public string ModeOfPaymentValue { get; set; }
    public string ModeOfPaymentName { get; set; }

    public CModeOfPayment()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            this.ModeOfPaymentID = 0;
            this.ModeOfPaymentValue = this.ModeOfPaymentName = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public CModeOfPayment(int paymentId)
        : this()
    {
        try
        {
            this.LoadModeOfPayment(paymentId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public CModeOfPayment( string paymentValue)
        : this()
    {
        try
        {
            this.LoadModeOfPayment(paymentValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new ModeOfPayment
    /// </summary>
    private void AddRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [ModeOfPayment] ([ModeOfPaymentValue], [ModeOfPaymentName]) " +
                                "VALUES (@ModeOfPaymentID, @ModeOfPaymentValue, @ModeOfPaymentName)", con);

            InsertCommand.Parameters.Add("@ModeOfPaymentValue", SqlDbType.VarChar).Value = this.ModeOfPaymentValue;
            InsertCommand.Parameters.Add("@ModeOfPaymentName", SqlDbType.VarChar).Value = this.ModeOfPaymentName;

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
    /// Delete this  ModeOfPayment
    /// </summary>
    private void DeleteRecord(string paymentValue)
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [ModeOfPayment] 
                             WHERE (ModeOfPaymentValue = @ModeOfPaymentValue)", con);

            DeleteCommand.Parameters.Add("@ModeOfPaymentValue", SqlDbType.VarChar).Value = paymentValue;

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
    /// Delete this  ModeOfPayment
    /// </summary>
    private void DeleteRecord(int paymentId)
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [ModeOfPayment] 
                             WHERE (ModeOfPaymentID = @ModeOfPaymentID)", con);

            DeleteCommand.Parameters.Add("@ModeOfPaymentID", SqlDbType.Int).Value = paymentId;

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
    /// Delete All  ModeOfPayment
    /// </summary>
    private void DeleteAllRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [ModeOfPayment]", con);

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
    /// Update ModeOfPayment
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

                string strSQL = @"UPDATE ModeOfPayment SET
                                ModeOfPaymentName = @ModeOfPaymentName
                             WHERE (ModeOfPaymentValue = @ModeOfPaymentValue)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@ModeOfPaymentValue", SqlDbType.VarChar).Value = this.ModeOfPaymentValue;
                cmd.Parameters.Add("@ModeOfPaymentName", SqlDbType.VarChar).Value = this.ModeOfPaymentName;
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con = null;
            }
            else
            {
                throw new Exception("This payment option no longer exist.");
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

                string strSQL = @"SELECT ModeOfPaymentValue FROM ModeOfPayment
                                  WHERE (ModeOfPaymentValue = @ModeOfPaymentValue)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@ModeOfPaymentValue", SqlDbType.VarChar).Value = this.ModeOfPaymentValue;

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


    /// <returns>Returns Mode of Payment DataTable</returns>
    public DataTable ModeOfPaymentDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT ModeOfPaymentID, ModeOfPaymentValue,  ModeOfPaymentName
                                FROM ModeOfPayment
                                ORDER BY ModeOfPaymentID", con);

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


    public void LoadModeOfPayment(string paymentValue)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT ModeOfPaymentID, ModeOfPaymentValue,  ModeOfPaymentName
                                FROM ModeOfPayment
                                WHERE ModeOfPaymentValue = @ModeOfPaymentValue", con);

            SelectCommand.Parameters.Add("@ModeOfPaymentValue", SqlDbType.VarChar).Value = paymentValue;

            adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];
            if (dt.Rows.Count != 0)
            {
                this.ModeOfPaymentID = int.Parse(dt.Rows[0]["ModeOfPaymentID"].ToString());
                this.ModeOfPaymentValue = dt.Rows[0]["ModeOfPaymentValue"].ToString();
                this.ModeOfPaymentName = dt.Rows[0]["ModeOfPaymentName"].ToString();
            }
            else
            {
                throw new Exception("Invalid Mode of Payment.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void LoadModeOfPayment(int paymentId)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT ModeOfPaymentID, ModeOfPaymentValue,  ModeOfPaymentName
                                FROM ModeOfPayment
                                WHERE ModeOfPaymentID = @ModeOfPaymentID", con);

            SelectCommand.Parameters.Add("@ModeOfPaymentID", SqlDbType.Int).Value = paymentId;

            adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];
            if (dt.Rows.Count != 0)
            {
                this.ModeOfPaymentID = int.Parse(dt.Rows[0]["ModeOfPaymentID"].ToString());
                this.ModeOfPaymentValue = dt.Rows[0]["ModeOfPaymentValue"].ToString();
                this.ModeOfPaymentName = dt.Rows[0]["ModeOfPaymentName"].ToString();
            }
            else
            {
                throw new Exception("Invalid Mode of Payment.");
            }
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
                throw new Exception("This payment option no longer exist.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Delete( string paymentValue )
    {
        try
        {
            this.DeleteRecord(paymentValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Delete(int paymentId)
    {
        try
        {
            this.DeleteRecord(paymentId);
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