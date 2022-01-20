using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CPaymentHistory
/// </summary>
public class CPaymentHistory
{
    private CConnectivity Connectivity;
    private bool blnPaymentCompleted;

    public CRemitaResponse Payment;
    public DateTime PaymentDate { get { return DateTime.Parse(this.Payment.transactiontime).Date; } }
    public TimeSpan PaymentTime { get { return DateTime.Parse(this.Payment.transactiontime).TimeOfDay; } }
    public bool PaymentCompleted { get { return blnPaymentCompleted; } }

    public CPaymentHistory()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();
            Payment = new CRemitaResponse();
            blnPaymentCompleted = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Payment History
    /// </summary>
    private void AddRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString;

            string strSQL = @"INSERT INTO [PaymentHistory] ([BookingID], [TransactionTime], [PaymentDate], [PaymentTime], [RRR], [StatusCode], [Message], [Amount]) " +
                            "VALUES (@BookingID, @TransactionTime, @PaymentDate, @PaymentTime, @RRR, @StatusCode, @Message, @Amount)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.Payment.orderId;
            cmd.Parameters.Add("@TransactionTime", SqlDbType.VarChar).Value = this.Payment.transactiontime;
            cmd.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = PaymentDate;
            cmd.Parameters.Add("@PaymentTime", SqlDbType.Time).Value = PaymentTime;
            cmd.Parameters.Add("@RRR", SqlDbType.VarChar).Value = this.Payment.RRR;
            cmd.Parameters.Add("@StatusCode", SqlDbType.VarChar).Value = this.Payment.status;
            cmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = this.Payment.message;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = this.Payment.amount;

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
    /// Update an existing Payment History
    /// </summary>
    private void UpdateRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"UPDATE PaymentHistory SET
                                RRR = @RRR,                       
                                StatusCode = @StatusCode,
                                Message = @Message,
                                Amount = @Amount                                             
                             WHERE (BookingID = @BookingID) 
                                AND (TransactionTime = @TransactionTime)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.Payment.orderId;
            cmd.Parameters.Add("@TransactionTime", SqlDbType.VarChar).Value = this.Payment.transactiontime;
            cmd.Parameters.Add("@RRR", SqlDbType.VarChar).Value = this.Payment.RRR;
            cmd.Parameters.Add("@StatusCode", SqlDbType.VarChar).Value = this.Payment.status;
            cmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = this.Payment.message;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = this.Payment.amount;

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

                string strSQL = @"SELECT BookingID FROM PaymentHistory
                                 WHERE (BookingID = @BookingID) 
                                    AND (TransactionTime = @TransactionTime)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.Payment.orderId;
                cmd.Parameters.Add("@TransactionTime", SqlDbType.VarChar).Value = this.Payment.transactiontime;

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
    /// Delete this Payment History
    /// </summary>
    private void DeleteRecord(string bookingId, string transactionTime)
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString;

            string strSQL = @"DELETE FROM [PaymentHistory] 
                             WHERE (BookingID = @BookingID)
                               AND (TransactionTime = @TransactionTime)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = bookingId;
            cmd.Parameters.Add("@TransactionTime", SqlDbType.VarChar).Value = transactionTime;

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
    /// Delete All Payment History
    /// </summary>
    private void DeleteAllRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString;

            string strSQL = @"DELETE FROM [PaymentHistory])";

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
    /// <returns>Returns Payment History DataTable</returns>
    public DataTable PaymentHistoryDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString);

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT BookingID, TransactionTime,
                                    CONVERT(VARCHAR, PaymentDate, 106) AS PaymentDate,
                                    CONVERT(VARCHAR, PaymentTime, 109) AS PaymentTime,
                                    RRR, StatusCode, Message, Amount
                                FROM PaymentHistory 
                                ORDER BY StatusCode, PaymentDate DESC, PaymentTime DESC", con);

            SqlDataAdapter adp = new SqlDataAdapter(SelectCommand);

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
    /// Returns Payment History DataTable</returns>
    public DataTable PaymentHistoryDataTable(string bookingId)
    {
        try
        {
            DataSet ds = new DataSet();

            string strSQL = @"SELECT BookingID, TransactionTime,
                                    CONVERT(VARCHAR, PaymentDate, 106) AS PaymentDate,   
                                    CONVERT(VARCHAR, PaymentTime, 109) AS PaymentTime, 
                                    RRR, StatusCode, Message, Amount
                                FROM PaymentHistory                                 
                                WHERE BookingID = @BookingID
                                ORDER BY StatusCode, PaymentDate DESC, PaymentTime DESC";

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString);

            SqlCommand SelectCommand =
                new SqlCommand(strSQL, con);

            SelectCommand.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = bookingId;

            SqlDataAdapter adp = new SqlDataAdapter(SelectCommand);

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

    public void LoadPaymentHistory(string bookingId, string transactionTime)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT p.BookingID, p.TransactionTime, p.RRR, 
                                        p.StatusCode, p.Message, p.Amount, b.PaymentCompleted
                                FROM PaymentHistory AS p INNER JOIN
                                Bookings AS b ON p.BookingID = b.BookingID                                 
                                WHERE (p.BookingID = @BookingID)
                                  AND (p.TransactionTime = @TransactionTime)", con);

            SelectCommand.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = bookingId;
            SelectCommand.Parameters.Add("@TransactionTime", SqlDbType.VarChar).Value = transactionTime;

            SqlDataAdapter adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];

            if (dt.Rows.Count != 0)
            {               
                this.Payment.orderId  = dt.Rows[0]["BookingID"].ToString();
                this.Payment.transactiontime  = dt.Rows[0]["TransactionTime"].ToString();
                this.Payment.RRR  = dt.Rows[0]["RRR"].ToString();
                this.Payment.status  = dt.Rows[0]["StatusCode"].ToString();
                this.Payment.message  = dt.Rows[0]["Message"].ToString();
                this.Payment.amount  = double.Parse(dt.Rows[0]["Amount"].ToString());
                this.blnPaymentCompleted = bool.Parse(dt.Rows[0]["PaymentCompleted"].ToString());
            }           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void LoadPaymentHistory(string bookingId)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT p.BookingID, p.TransactionTime, p.RRR,
                                        p.StatusCode, p.Message, p.Amount, b.PaymentCompleted
                                FROM PaymentHistory AS p INNER JOIN
                                Bookings AS b ON p.BookingID = b.BookingID                                 
                                WHERE p.BookingID = @BookingID
                                ORDER BY p.StatusCode, p.PaymentDate DESC, p.PaymentTime DESC", con);

            SelectCommand.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = bookingId;

            SqlDataAdapter adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];

            if (dt.Rows.Count != 0)
            {
                this.Payment.orderId = dt.Rows[0]["BookingID"].ToString();
                this.Payment.transactiontime = dt.Rows[0]["TransactionTime"].ToString();
                this.Payment.RRR = dt.Rows[0]["RRR"].ToString();
                this.Payment.status = dt.Rows[0]["StatusCode"].ToString();
                this.Payment.message = dt.Rows[0]["Message"].ToString();
                this.Payment.amount = double.Parse(dt.Rows[0]["Amount"].ToString());
                this.blnPaymentCompleted = bool.Parse(dt.Rows[0]["PaymentCompleted"].ToString());
            }
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LoadPaymentRRR(string rrr)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT p.BookingID, p.TransactionTime, p.RRR, 
                                        p.StatusCode, p.Message, p.Amount, b.PaymentCompleted
                                FROM PaymentHistory AS p INNER JOIN
                                Bookings AS b ON p.BookingID = b.BookingID                               
                                WHERE p.RRR = @RRR
                                ORDER BY p.StatusCode, p.PaymentDate DESC, p.PaymentTime DESC", con);

            SelectCommand.Parameters.Add("@RRR", SqlDbType.VarChar).Value = rrr;

            SqlDataAdapter adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];

            if (dt.Rows.Count != 0)
            {
                this.Payment.orderId = dt.Rows[0]["BookingID"].ToString();
                this.Payment.transactiontime = dt.Rows[0]["TransactionTime"].ToString();
                this.Payment.RRR = dt.Rows[0]["RRR"].ToString();
                this.Payment.status = dt.Rows[0]["StatusCode"].ToString();
                this.Payment.message = dt.Rows[0]["Message"].ToString();
                this.Payment.amount = double.Parse(dt.Rows[0]["Amount"].ToString());
                this.blnPaymentCompleted = bool.Parse(dt.Rows[0]["PaymentCompleted"].ToString());
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
            if (!this.PaymentCompleted)
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
        }
        catch{ }
    }

    public void Delete(string bookingId, string transactionTime)
    {
        try
        {
            this.DeleteRecord(bookingId, transactionTime);
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

    public void CompleteBookingPayment(bool completed, string modeOfPaymentValue)
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"UPDATE Bookings SET 
                                ModeOfPaymentID = @ModeOfPaymentID,                                                           
                                PaymentCompleted = @PaymentCompleted,
                                PaymentTransactionTime = @PaymentTransactionTime                              
                             WHERE (BookingID = @BookingID)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.Payment.orderId;
            cmd.Parameters.Add("@ModeOfPaymentID", SqlDbType.Int).Value = new CModeOfPayment(modeOfPaymentValue).ModeOfPaymentID;
            cmd.Parameters.Add("@PaymentCompleted", SqlDbType.Bit).Value = completed;            
            cmd.Parameters.Add("@PaymentTransactionTime", SqlDbType.VarChar).Value = this.Payment.transactiontime;
            
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
}