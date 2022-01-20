using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CCancellationPolicy
/// </summary>
public class CCancellationPolicy
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    public int PolicyID { get; set; }
    public string PolicyName { get; set; }
    public string Policies { get; set; }

    public CCancellationPolicy()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            this.PolicyID = 0;
            this.PolicyName = "";
            this.Policies = "";

            this.LoadData();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void LoadData()
    {
        try
        {
            int intCount = this.CancellationPolicyDataTable().Rows.Count;

            if (intCount >= 1)
            {
                this.Policies = @"<ul style=""list-style-type:square;"">";            

                for (int i = 0; i < intCount; i++)
                {
                    this.Policies += "<li>" + this.CancellationPolicyDataTable().Rows[i]["PolicyName"].ToString() + "</li>";
                }
                this.Policies += "</ul>";
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Cancellation Policy
    /// </summary>
    private void AddRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [CancellationPolicy] ([PolicyName]) VALUES (@PolicyName)", con);

            InsertCommand.Parameters.Add("@PolicyName", SqlDbType.VarChar).Value = this.PolicyName;

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
    /// Delete this Cancellation Policy
    /// </summary>
    private void DeleteRecord(int PolicyId)
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [CancellationPolicy] 
                             WHERE (PolicyID = @PolicyID)", con);

            DeleteCommand.Parameters.Add("@PolicyID", SqlDbType.Int).Value = PolicyId;

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
    /// Delete All Cancellation Policies
    /// </summary>
    private void DeleteAllRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [CancellationPolicy]", con);

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
    /// <returns>Returns Cancellation Policy DataTable</returns>
    public DataTable CancellationPolicyDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT bp.PolicyID, bp.PolicyName
                                FROM CancellationPolicy AS bp
                                ORDER BY bp.PolicyID", con);

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

    public void Delete(int PolicyId)
    {
        try
        {
            this.DeleteRecord(PolicyId);
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