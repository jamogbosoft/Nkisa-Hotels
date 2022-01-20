using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CWedding
/// </summary>
public class CWedding
{
    private SqlDataAdapter adp;
    private CConnectivity Connectivity;

    private string strTransactionDate, strTransactionTime, strSurname, strFirstName, strEmail, strDateOfTheWedding, strStartingTime, strComment;
    private bool blnWeddingHall, blnReceptionHall;
    private int intTimeDuration, intWeddingHallCapacity, intReceptionHallCapacity;



    public CWedding()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();
            strTransactionDate = strTransactionTime = strSurname = strFirstName = strEmail = strDateOfTheWedding = strStartingTime = strComment = "";
            blnWeddingHall = blnReceptionHall = false;
            intTimeDuration = intWeddingHallCapacity = intReceptionHallCapacity = 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new wedding
    /// </summary>
    private void AddRecord()
    {
        try
        {

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand InsertCommand =
                new SqlCommand("INSERT INTO [Wedding] ([TransactionDate], [TransactionTime], [Surname], [FirstName], [Email], [DateOfTheWedding], [StartingTime], [TimeDuration], [WeddingHall], [ReceptionHall], [WeddingHallCapacity], [ReceptionHallCapacity], [Comment]) " +
                                "VALUES (@TransactionDate, @TransactionTime, @Surname, @FirstName, @Email, @DateOfTheWedding, @StartingTime, @TimeDuration, @WeddingHall, @ReceptionHall, @WeddingHallCapacity, @ReceptionHallCapacity, @Comment)", con);

            InsertCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = this.TransactionDate;
            InsertCommand.Parameters.Add("@TransactionTime", SqlDbType.VarChar).Value = this.TransactionTime;
            InsertCommand.Parameters.Add("@Surname", SqlDbType.VarChar).Value = this.Surname;
            InsertCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = this.FirstName;
            InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = this.Email;
            InsertCommand.Parameters.Add("@DateOfTheWedding", SqlDbType.VarChar).Value = this.DateOfTheWedding;
            InsertCommand.Parameters.Add("@StartingTime", SqlDbType.VarChar).Value = this.StartingTime;
            InsertCommand.Parameters.Add("@TimeDuration", SqlDbType.VarChar).Value = this.TimeDuration.ToString();
            InsertCommand.Parameters.Add("@WeddingHall", SqlDbType.VarChar).Value = this.WeddingHall;
            InsertCommand.Parameters.Add("@ReceptionHall", SqlDbType.VarChar).Value = this.ReceptionHall;
            InsertCommand.Parameters.Add("@WeddingHallCapacity", SqlDbType.Int).Value = this.WeddingHallCapacity;
            InsertCommand.Parameters.Add("@ReceptionHallCapacity", SqlDbType.Int).Value = this.ReceptionHallCapacity;
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
    /// Delete this wedding
    /// </summary>
    private void DeleteRecord(int WeddingID)
    {
        try
        {
            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand DeleteCommand =
            new SqlCommand(@"DELETE FROM [Wedding] 
                             WHERE (WeddingID = @WeddingID)", con);

            DeleteCommand.Parameters.Add("@WeddingID", SqlDbType.Int).Value = WeddingID;

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
            new SqlCommand(@"DELETE FROM [Wedding]", con);

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
    /// <returns>Returns Wedding DataTable</returns>
    public DataTable WeddingDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(new CConnectivity().ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT WeddingID, TransactionDate + ' ' + TransactionTime AS TDT, Surname + ' ' + FirstName AS Names, Email, DateOfTheWedding + ' ' + StartingTime AS SDT, TimeDuration + ' hrs' AS Duration, WeddingHall, WeddingHallCapacity, ReceptionHall, ReceptionHallCapacity, Comment
                                FROM Wedding 
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
    /// Insert new wedding
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
    /// Delete this wedding
    /// </summary>
    public void Delete(int WeddingID)
    {
        try
        {
            this.DeleteRecord(WeddingID);
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
    /// Get or Set string DateOfTheWedding
    /// </summary>
    public string DateOfTheWedding
    {
        get { return strDateOfTheWedding; }
        set { strDateOfTheWedding = value; }
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
    /// Get or Set bool WeddingHall
    /// </summary>
    public bool WeddingHall
    {
        get { return blnWeddingHall; }
        set { blnWeddingHall = value; }
    }
    /// <summary>
    /// Get or Set bool ReceptionHall
    /// </summary>
    public bool ReceptionHall
    {
        get { return blnReceptionHall; }
        set { blnReceptionHall = value; }
    }

    /// <summary>
    /// Get or Set string WeddingHallCapacity
    /// </summary>
    public int WeddingHallCapacity
    {
        get { return intWeddingHallCapacity; }
        set { intWeddingHallCapacity = value; }
    }
    /// <summary>
    /// Get or Set string ReceptionHallCapacity
    /// </summary>
    public int ReceptionHallCapacity
    {
        get { return intReceptionHallCapacity; }
        set { intReceptionHallCapacity = value; }
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