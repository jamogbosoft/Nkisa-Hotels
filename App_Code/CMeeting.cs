using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CMeeting
/// </summary>
public class CMeeting
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    private string strTransactionDate, strTransactionTime, strSurname, strFirstName, strEmail, strDateOfTheMeeting, strStartingTime, strComment;
    private int intTimeDuration, intCapacity;


    public CMeeting()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();
            strTransactionDate=strTransactionTime= strSurname=strFirstName= strEmail= strDateOfTheMeeting= strStartingTime= strComment="";
            intTimeDuration = intCapacity = 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Meeting
    /// </summary>
    private void AddRecord()
    {
        try
        {

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [Meeting] ([TransactionDate], [TransactionTime], [Surname], [FirstName], [Email], [DateOfTheMeeting], [StartingTime], [TimeDuration], [Capacity], [Comment]) " +
                            "VALUES (@TransactionDate, @TransactionTime, @Surname, @FirstName, @Email, @DateOfTheMeeting, @StartingTime, @TimeDuration, @Capacity, @Comment)", con);

            InsertCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = this.TransactionDate;
            InsertCommand.Parameters.Add("@TransactionTime", SqlDbType.VarChar).Value = this.TransactionTime;
            InsertCommand.Parameters.Add("@Surname", SqlDbType.VarChar).Value = this.Surname;
            InsertCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = this.FirstName;
            InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = this.Email;
            InsertCommand.Parameters.Add("@DateOfTheMeeting", SqlDbType.VarChar).Value = this.DateOfTheMeeting;
            InsertCommand.Parameters.Add("@StartingTime", SqlDbType.VarChar).Value = this.StartingTime;
            InsertCommand.Parameters.Add("@TimeDuration", SqlDbType.VarChar).Value = this.TimeDuration.ToString();
            InsertCommand.Parameters.Add("@Capacity", SqlDbType.Int ).Value = this.Capacity;
            InsertCommand.Parameters.Add("@Comment", SqlDbType.VarChar).Value = this.Comment;

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
    /// Delete this meeting
    /// </summary>
    private void DeleteRecord(int MeetingID)
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [Meeting] 
                             WHERE (MeetingID = @MeetingID)", con);

            DeleteCommand.Parameters.Add("@MeetingID", SqlDbType.Int).Value = MeetingID;

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
            new SqlCommand(@"DELETE FROM [Meeting]", con);

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
    /// <returns>Returns Meeting DataTable</returns>
    public DataTable MeetingDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(new CConnectivity().ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT MeetingID, TransactionDate + ' ' + TransactionTime AS TDT, Surname + ' ' + FirstName AS Names, Email, DateOfTheMeeting + ' ' + StartingTime AS SDT, TimeDuration + ' hrs' AS Duration, Capacity, Comment
                                FROM Meeting 
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
    /// Insert new meeting
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
    /// Delete this meeting
    /// </summary>
    public void Delete(int MeetingID)
    {
        try
        {
            this.DeleteRecord(MeetingID);
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
    /// Get or Set string DateOfTheMeeting
    /// </summary>
    public string DateOfTheMeeting
    {
        get { return strDateOfTheMeeting; }
        set { strDateOfTheMeeting = value; }
    }

    /// <summary>
    /// Get or Set string StartingTime
    /// </summary>
    public string StartingTime
    {
        get { return strStartingTime; }
        set { strStartingTime = value; }
    }

    /// <summary>
    /// Get or Set string TimeDuration
    /// </summary>
    public int TimeDuration
    {
        get { return intTimeDuration; }
        set { intTimeDuration = value; }
    }


    /// <summary>
    /// Get or Set string Capacity
    /// </summary>
    public int Capacity
    {
        get { return intCapacity; }
        set { intCapacity = value; }
    }

    /// <summary>
    /// Get or Set string Comment
    /// </summary>
    public string Comment
    {
        get { return strComment; }
        set { strComment = value; }
    }
}