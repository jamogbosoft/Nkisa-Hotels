using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CContactUs
/// </summary>
public class CContactUs
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    private string strTransactionDate, strTransactionTime, strSurname, strFirstName, strEmail, strMessage;


    public CContactUs()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            strTransactionDate = strTransactionTime = strSurname = strFirstName = strEmail = strMessage = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Contac tUs
    /// </summary>
    private void AddRecord()
    {
        try
        {

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [ContactUs] ([TransactionDate], [TransactionTime], [Surname], [FirstName], [Email], [Message]) " +
                            "VALUES (@TransactionDate, @TransactionTime, @Surname, @FirstName, @Email, @Message)", con);

            InsertCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = this.TransactionDate;
            InsertCommand.Parameters.Add("@TransactionTime", SqlDbType.VarChar).Value = this.TransactionTime;
            InsertCommand.Parameters.Add("@Surname", SqlDbType.VarChar).Value = this.Surname;
            InsertCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = this.FirstName;
            InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = this.Email;
            InsertCommand.Parameters.Add("@Message", SqlDbType.VarChar).Value = this.Message;

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
    /// Delete this message
    /// </summary>
    private void DeleteRecord(int ContactID)
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [ContactUs] 
                             WHERE (ContactID = @ContactID)", con);

            DeleteCommand.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID;

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
    /// Delete All messages
    /// </summary>
    private void DeleteAllRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [ContactUs]", con);
                       
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
    /// <returns>Returns ContactUs DataTable</returns>
    public DataTable ContactUsDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(new CConnectivity().ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT ContactID, TransactionDate + ' ' + TransactionTime AS TDT, Surname + ' ' + FirstName AS Names, Email, Message
                                FROM ContactUs 
                                ORDER BY TransactionDate ASC, TransactionTime DESC", con);

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
    /// Insert new  message
    /// </summary>
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
    /// <summary>
    /// Delete this message
    /// </summary>
    public void Delete(int ContactID)
    {
        try
        {
            this.DeleteRecord(ContactID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Delete All messages
    /// </summary>
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
    /// Get or Set string TransactionDate
    /// </summary>
    public string TransactionDate
    {
        get { return strTransactionDate; }
        set { strTransactionDate = value; }
    }
    /// <summary>
    /// Get or Set string TransactionTime
    /// </summary>
    public string TransactionTime
    {
        get { return strTransactionTime; }
        set { strTransactionTime = value; }
    }

    /// <summary>
    /// Get or Set string Surname
    /// </summary>
    public string Surname
    {
        get { return strSurname; }
        set { strSurname = value; }
    }

    /// <summary>
    /// Get or Set string FirstName
    /// </summary>
    public string FirstName
    {
        get { return strFirstName; }
        set { strFirstName = value; }
    }

    /// <summary>
    /// Get or Set string Email
    /// </summary>
    public string Email
    {
        get { return strEmail; }
        set { strEmail = value; }
    }


    /// <summary>
    /// Get or Set string Message
    /// </summary>
    public string Message
    {
        get { return strMessage; }
        set { strMessage = value; }
    }
}