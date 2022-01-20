using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CEvents
/// </summary>
public class CEvents
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    private string strTransactionDate, strTransactionTime, strSurname, strFirstName, strEmail, strEventName, strDateOfTheEvent, strStartingTime, strComment;
    private int intTimeDuration;


    public CEvents()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();
            strTransactionDate = strTransactionTime = strSurname = strFirstName = strEmail = strEventName=strDateOfTheEvent = strStartingTime = strComment = "";
            intTimeDuration  = 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Event
    /// </summary>
    private void AddRecord()
    {
        try
        {

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [Events] ([TransactionDate], [TransactionTime], [Surname], [FirstName], [Email], [EventName], [DateOfTheEvent], [StartingTime], [TimeDuration], [Comment]) " +
                            "VALUES (@TransactionDate, @TransactionTime, @Surname, @FirstName, @Email, @EventName, @DateOfTheEvent, @StartingTime, @TimeDuration, @Comment)", con);

            InsertCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = this.TransactionDate;
            InsertCommand.Parameters.Add("@TransactionTime", SqlDbType.VarChar).Value = this.TransactionTime;
            InsertCommand.Parameters.Add("@Surname", SqlDbType.VarChar).Value = this.Surname;
            InsertCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = this.FirstName;
            InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = this.Email;
            InsertCommand.Parameters.Add("@EventName", SqlDbType.VarChar).Value = this.EventName;
            InsertCommand.Parameters.Add("@DateOfTheEvent", SqlDbType.VarChar).Value = this.DateOfTheEvent;
            InsertCommand.Parameters.Add("@StartingTime", SqlDbType.VarChar).Value = this.StartingTime;
            InsertCommand.Parameters.Add("@TimeDuration", SqlDbType.VarChar).Value = this.TimeDuration.ToString();
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
    /// Delete this event
    /// </summary>
    private void DeleteRecord(int EventID)
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [Events] 
                             WHERE (EventID = @EventID)", con);

            DeleteCommand.Parameters.Add("@EventID", SqlDbType.Int).Value = EventID;

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
    /// Delete All Events
    /// </summary>
    private void DeleteAllRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [Events]", con);

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
    /// <returns>Returns Events DataTable</returns>
    public DataTable EventsDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(new CConnectivity().ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT EventID, TransactionDate + ' ' + TransactionTime AS TDT, Surname + ' ' + FirstName AS Names, Email, EventName, DateOfTheEvent + ' ' + StartingTime AS SDT, TimeDuration + ' hrs' AS Duration, Comment
                                FROM Events 
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
    /// Insert new event
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
    /// Delete this event
    /// </summary>
    public void Delete(int EventID)
    {
        try
        {
            this.DeleteRecord(EventID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Delete All Events
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
    /// Get or Set string EventName
    /// </summary>
    public string EventName
    {
        get { return strEventName; }
        set { strEventName = value; }
    }
    /// <summary>
    /// Get or Set string DateOfTheEvent
    /// </summary>
    public string DateOfTheEvent
    {
        get { return strDateOfTheEvent; }
        set { strDateOfTheEvent = value; }
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
    /// Get or Set string Comment
    /// </summary>
    public string Comment
    {
        get { return strComment; }
        set { strComment = value; }
    }
}