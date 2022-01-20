using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CPersonalDetails
/// </summary>
public class CPersonalDetails
{
    private CConnectivity Connectivity;
   
    public string UserName { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public CPersonalDetails()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

           this.Surname = this.FirstName = this.Email = this.PhoneNumber = "";           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Personal Details
    /// </summary>
    private void AddRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"INSERT INTO [PersonalDetails] ([UserName], [Surname], [FirstName], [Email], [PhoneNumber]) " +
                            "VALUES (@UserName, @Surname, @FirstName, @Email, @PhoneNumber)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = this.UserName;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = this.Surname;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = this.FirstName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = this.Email;
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = this.PhoneNumber;

                        
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
    /// Update new Personal Details
    /// </summary>
    private void UpdateRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"UPDATE [PersonalDetails]  SET
                                [Surname] = @Surname,
                                [FirstName] = @FirstName,
                                [Email] = @Email,
                                [PhoneNumber] = @PhoneNumber
                            WHERE (UserName =  @UserName)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = this.UserName;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = this.Surname;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = this.FirstName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = this.Email;
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = this.PhoneNumber;
            
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
    /// Delete this Personal Details
    /// </summary>
    private void DeleteRecord(string strUserName)
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"DELETE FROM [PersonalDetails] 
                             WHERE (UserName = @UserName)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = strUserName;

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
    /// Delete All PersonalDetails
    /// </summary>
    private void DeleteAllRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"DELETE FROM [PersonalDetails])";

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
    /// <returns>Returns PersonalDetails DataTable</returns>
    public DataTable PersonalDetailsDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand cmd =
                new SqlCommand(@"SELECT UserName, Surname, FirstName, Email, PhoneNumber
                                FROM PersonalDetails
                                ORDER BY Surname, FirstName", con);                      

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

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
    /// <returns>Returns PersonalDetails DataTable</returns>
    public DataTable PersonalDetailsDataTable(string strUserName)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand cmd =
                new SqlCommand(@"SELECT UserName, Surname, FirstName, Email, PhoneNumber
                                FROM PersonalDetails
                                WHERE UserName = @UserName
                                ORDER BY Surname, FirstName", con);

            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = strUserName;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

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

    public void LoadPersonalDetails(string strUserName)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand cmd =
                new SqlCommand(@"SELECT UserName, Surname, FirstName, Email, PhoneNumber
                                FROM PersonalDetails
                                WHERE UserName = @UserName
                                ORDER BY Surname, FirstName", con);

            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = strUserName;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];

            if (dt.Rows.Count != 0)
            {
                this.UserName = dt.Rows[0]["UserName"].ToString();
                this.Surname = dt.Rows[0]["Surname"].ToString();
                this.FirstName = dt.Rows[0]["FirstName"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();   
                this.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();                
            }
            else
            {
                this.UserName = "";
                this.Surname = "";
                this.FirstName = "";
                this.Email = "";
                this.PhoneNumber = "";  
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
            if (this.RecordExist) { this.UpdateRecord(); }
            else { this.AddRecord(); }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Delete(string userName)
    {
        try
        {
            this.DeleteRecord(userName);
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

                string strSQL = @"SELECT UserName FROM PersonalDetails
                                  WHERE (UserName = @UserName)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = this.UserName;

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