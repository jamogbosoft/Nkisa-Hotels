using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// class CBookings
/// </summary>
public class CBookings
{
    private CConnectivity Connectivity;

    public CMail Mail { get; set; }

    public string BookingID { get { return Mail.Payment.orderId; } set { Mail.Payment.orderId = value; } }
    public string BookingDate { get; set; }
    public string BookingTime { get; set; }
    public string BookingDateAndTime { get { return BookingDate + " " + BookingTime; } }
    public string CheckInDate { get; set; }
    public string CheckOutDate { get; set; }
    public int NumberOfNights { get; set; }
    public int NumberOfRooms { get; set; }
    public int NumberOfAdults { get; set; }
    public string Surname { get { return Mail.Surname; } set { Mail.Surname  = value; } }
    public string FirstName { get { return Mail.FirstName; } set { Mail.FirstName = value; } }
    public string CustomersName { get { return Surname + " " + FirstName; } }
    public string Email { get { return Mail.Email; } set { Mail.Email = value; } }
    public string PhoneNumber { get; set; }
    public double TotalAmount { get; set; }
    public bool PaymentCompleted { get; set; }
    public bool RoomAllocationCompleted { get; set; }
    public bool BookingCancelled { get; set; }
    public string CancellationDate { get; set; }
    public string CancellationTime { get; set; }
    public CModeOfPayment ModeOfPayment { get; set; }

    public string NumberOfNightsInWords { get { return new CNumberOfNightsInWords(this.NumberOfNights).InWords; } }
    public string NumberOfRoomsInWords { get { return new CNumberOfRoomsInWords(this.NumberOfRooms).InWords; } }
    public string NumberOfAdultsInWords { get { return new CNumberOfAdultsInWords(this.NumberOfAdults).InWords; } }

    public CBranch Branch { get; set; }
    public CRoomTypes RoomType { get; set; }

    public CBookings()
    {
        try
        {
            //Initialization
            Connectivity = new CConnectivity();

            Mail = new CMail();
            Branch = new CBranch();
            RoomType = new CRoomTypes();
            ModeOfPayment = new CModeOfPayment();

            this.BookingID = this.Surname = this.FirstName = this.Email = this.PhoneNumber = "";
            this.NumberOfNights = this.NumberOfRooms = this.NumberOfAdults;
            this.CheckInDate = this.CheckOutDate = "";
            this.PaymentCompleted = RoomAllocationCompleted=this.BookingCancelled = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Insert new Booking
    /// </summary>
    private void AddRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"INSERT INTO [Bookings] ([BookingID], [BranchID], [RoomTypeID], [BookingDate], [BookingTime], [CheckInDate], [CheckOutDate], [NumberOfNights], " +
                                "[NumberOfRooms], [NumberOfAdults], [Surname], [FirstName], [Email], [PhoneNumber], [TotalAmount], [ModeOfPaymentID], [PaymentCompleted]) " +
                            "VALUES (@BookingID, @BranchID, @RoomTypeID, @BookingDate, @BookingTime, @CheckInDate, @CheckOutDate, @NumberOfNights, @NumberOfRooms, " +
                                "@NumberOfAdults, @Surname, @FirstName, @Email, @PhoneNumber, @TotalAmount, @ModeOfPaymentID, @PaymentCompleted)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;
            cmd.Parameters.Add("@BranchID", SqlDbType.Int).Value = this.Branch.BranchID;
            cmd.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = this.RoomType.RoomTypeID;

            cmd.Parameters.Add("@BookingDate", SqlDbType.Date).Value = DateTime.Now.Date;
            cmd.Parameters.Add("@BookingTime", SqlDbType.Time).Value = DateTime.Now.TimeOfDay;

            cmd.Parameters.Add("@CheckInDate", SqlDbType.Date).Value = DateTime.Parse(this.CheckInDate).Date;
            cmd.Parameters.Add("@CheckOutDate", SqlDbType.Date).Value = DateTime.Parse(this.CheckOutDate).Date;
            cmd.Parameters.Add("@NumberOfNights", SqlDbType.Int).Value = this.NumberOfNights;
            cmd.Parameters.Add("@NumberOfRooms", SqlDbType.Int).Value = this.NumberOfRooms;
            cmd.Parameters.Add("@NumberOfAdults", SqlDbType.Int).Value = this.NumberOfAdults;

            cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = this.Surname;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = this.FirstName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = this.Email;
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = this.PhoneNumber;

            cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = this.TotalAmount;
            cmd.Parameters.Add("@ModeOfPaymentID", SqlDbType.Int).Value = this.ModeOfPayment.ModeOfPaymentID;
            cmd.Parameters.Add("@PaymentCompleted", SqlDbType.Bit).Value = this.PaymentCompleted;

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
    /// Delete this Booking
    /// </summary>
    private void DeleteRecord(int bookingId)
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"DELETE FROM [Bookings] 
                             WHERE (BookingID = @BookingID)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = bookingId;

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
    /// Delete All Bookings
    /// </summary>
    private void DeleteAllRecord()
    {
        SqlConnection con = null;

        try
        {
            con = new SqlConnection();
            con.ConnectionString = this.Connectivity.ConnectionString.ToString();

            string strSQL = @"DELETE FROM [Bookings])";

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
    /// <returns>Returns Bookings DataTable</returns>
    public DataTable BookingsDataTable()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT bk.BookingID, br.BranchName, rt.RoomTypeName, rt.PricePerNight, 
                                    CAST(bk.BookingDate AS VARCHAR) AS BookingDate, CAST(bk.BookingTime AS VARCHAR) AS BookingTime, 
                                    bk.CheckInDate, bk.CheckOutDate, bk.NumberOfNights, bk.NumberOfRooms, bk.NumberOfAdults,
                                    bk.Surname, bk.FirstName, bk.Email, bk.PhoneNumber, bk.TotalAmount, mp.ModeOfPaymentName, 
                                    bk.PaymentCompleted, bk.AllocationCompleted, bk.BookingCancelled, bk.CancellationDate, bk.CancellationTime
                                FROM Bookings AS bk INNER JOIN
                                    Branch AS br ON bk.BranchID = br.BranchID INNER JOIN
                                    RoomTypes AS rt ON bk.RoomTypeID = rt.RoomTypeID AND  bk.BranchID = rt.BranchID INNER JOIN
                                    ModeOfPayment AS mp ON bk.ModeOfPaymentID = mp.ModeOfPaymentID
                                ORDER BY bk.BookingDate DESC, bk.BookingTime DESC", con);

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
    /// <returns>Returns Bookings DataTable</returns>
    public DataTable BookingsDataTable(CBookingStatus Status)
    {
        try
        {
            DataSet ds = new DataSet();
            string strSQL;

            if (Status.Non_Allocated)
            {
                strSQL = @"SELECT bk.BookingID,  bk.Surname + ' ' + bk.FirstName AS CustomersName,                                    
                                     CAST(bk.CheckInDate AS VARCHAR) AS CheckInDate,  
                                    CAST(bk.CheckOutDate AS VARCHAR) AS CheckOutDate
                                FROM Bookings AS bk INNER JOIN
                                    Branch AS br ON bk.BranchID = br.BranchID INNER JOIN
                                    RoomTypes AS rt ON bk.RoomTypeID = rt.RoomTypeID AND  bk.BranchID = rt.BranchID INNER JOIN
                                    ModeOfPayment AS mp ON bk.ModeOfPaymentID = mp.ModeOfPaymentID
                                WHERE  bk.AllocationCompleted = @AllocationCompleted
                                    AND bk.CheckOutDate >= @TodaysDate
                                ORDER BY bk.BookingDate DESC, bk.BookingTime DESC";

            }
            else if (Status.Allocated)
            {
                strSQL = @"SELECT bk.BookingID,  bk.Surname + ' ' + bk.FirstName AS CustomersName,                                    
                                     CAST(bk.CheckInDate AS VARCHAR) AS CheckInDate,  
                                    CAST(bk.CheckOutDate AS VARCHAR) AS CheckOutDate
                                FROM Bookings AS bk INNER JOIN
                                    Branch AS br ON bk.BranchID = br.BranchID INNER JOIN
                                    RoomTypes AS rt ON bk.RoomTypeID = rt.RoomTypeID AND  bk.BranchID = rt.BranchID INNER JOIN
                                    ModeOfPayment AS mp ON bk.ModeOfPaymentID = mp.ModeOfPaymentID
                                WHERE  bk.AllocationCompleted = @AllocationCompleted
                                ORDER BY bk.BookingDate DESC, bk.BookingTime DESC";
            }
            else if (Status.Expired)
            {
                strSQL = @"SELECT bk.BookingID,  bk.Surname + ' ' + bk.FirstName AS CustomersName,                                    
                                     CAST(bk.CheckInDate AS VARCHAR) AS CheckInDate,  
                                    CAST(bk.CheckOutDate AS VARCHAR) AS CheckOutDate
                                FROM Bookings AS bk INNER JOIN
                                    Branch AS br ON bk.BranchID = br.BranchID INNER JOIN
                                    RoomTypes AS rt ON bk.RoomTypeID = rt.RoomTypeID AND  bk.BranchID = rt.BranchID INNER JOIN
                                    ModeOfPayment AS mp ON bk.ModeOfPaymentID = mp.ModeOfPaymentID
                                WHERE  bk.AllocationCompleted = @AllocationCompleted
                                    AND bk.CheckOutDate < @TodaysDate
                                ORDER BY bk.BookingDate DESC, bk.BookingTime DESC";
            }
            else
            {
                strSQL = @"SELECT bk.BookingID,  bk.Surname + ' ' + bk.FirstName AS CustomersName,                                    
                                    CAST(bk.CheckInDate AS VARCHAR) AS CheckInDate,  
                                    CAST(bk.CheckOutDate AS VARCHAR) AS CheckOutDate
                                FROM Bookings AS bk INNER JOIN
                                    Branch AS br ON bk.BranchID = br.BranchID INNER JOIN
                                    RoomTypes AS rt ON bk.RoomTypeID = rt.RoomTypeID AND  bk.BranchID = rt.BranchID INNER JOIN
                                    ModeOfPayment AS mp ON bk.ModeOfPaymentID = mp.ModeOfPaymentID
                                ORDER BY bk.BookingDate DESC, bk.BookingTime DESC";
            }

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(strSQL, con);

            SelectCommand.Parameters.Add("@AllocationCompleted", SqlDbType.Bit).Value = Status.Allocated;
            SelectCommand.Parameters.Add("@TodaysDate", SqlDbType.Date).Value = DateTime.Now.Date;

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
    /// <returns>Returns Bookings DataTable</returns>
    public DataTable BookingsDataTable(string bookingId)
    {
        try
        {
            DataSet ds = new DataSet();

            string strSQL = @"SELECT bk.BookingID,  bk.Surname + ' ' + bk.FirstName AS CustomersName,                                    
                                     CAST(bk.CheckInDate AS VARCHAR) AS CheckInDate,  
                                    CAST(bk.CheckOutDate AS VARCHAR) AS CheckOutDate
                                FROM Bookings AS bk INNER JOIN
                                    Branch AS br ON bk.BranchID = br.BranchID INNER JOIN
                                    RoomTypes AS rt ON bk.RoomTypeID = rt.RoomTypeID AND  bk.BranchID = rt.BranchID INNER JOIN
                                    ModeOfPayment AS mp ON bk.ModeOfPaymentID = mp.ModeOfPaymentID
                                WHERE  bk.BookingID = @BookingID";


            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

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

    public void LoadBooking(string bookingId)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(this.Connectivity.ConnectionString.ToString());

            SqlCommand SelectCommand =
                new SqlCommand(@"SELECT bk.BookingID, br.BranchID, br.BranchName, br.Address, rt.RoomTypeID, 
                                    rt.RoomTypeName, rt.PricePerNight, rt.BedSize, rt.MaxOccupancy,
                                    CONVERT(VARCHAR, bk.BookingDate, 106) AS BookingDate, 
                                    CONVERT(VARCHAR, bk.BookingTime, 109) AS BookingTime, 
                                    CONVERT(VARCHAR, bk.CheckInDate, 106) AS CheckInDate,  
                                    CONVERT(VARCHAR, bk.CheckOutDate, 106) AS CheckOutDate, 
                                    bk.NumberOfNights, bk.NumberOfRooms, bk.NumberOfAdults,  
                                    bk.Surname, bk.FirstName, bk.Email, bk.PhoneNumber, 
                                    bk.TotalAmount, mp.ModeOfPaymentID, mp.ModeOfPaymentValue, 
                                    mp.ModeOfPaymentName, bk.PaymentCompleted, bk.AllocationCompleted,
                                    bk.BookingCancelled, bk.CancellationDate, bk.CancellationTime 
                                FROM Bookings AS bk INNER JOIN
                                    Branch AS br ON bk.BranchID = br.BranchID INNER JOIN
                                    RoomTypes AS rt ON bk.RoomTypeID = rt.RoomTypeID AND  bk.BranchID = rt.BranchID INNER JOIN
                                    ModeOfPayment AS mp ON bk.ModeOfPaymentID = mp.ModeOfPaymentID
                                WHERE bk.BookingID = @BookingID", con);

            SelectCommand.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = bookingId;

            SqlDataAdapter adp = new SqlDataAdapter(SelectCommand);

            con.Open();

            adp.Fill(ds, "DataTable");

            con.Close();
            con = null;

            DataTable dt = ds.Tables["DataTable"];

            if (dt.Rows.Count != 0)
            {
                this.BookingID = bookingId;

                this.Branch.BranchID = int.Parse(dt.Rows[0]["BranchID"].ToString());
                this.Branch.BranchName = dt.Rows[0]["BranchName"].ToString();
                this.Branch.Address = dt.Rows[0]["Address"].ToString();

                this.RoomType.RoomTypeID = int.Parse(dt.Rows[0]["RoomTypeID"].ToString());
                this.RoomType.BranchID = this.Branch.BranchID;
                this.RoomType.RoomTypeName = dt.Rows[0]["RoomTypeName"].ToString();
                this.RoomType.PricePerNight = float.Parse(dt.Rows[0]["PricePerNight"].ToString());
                this.RoomType.BedSize = dt.Rows[0]["BedSize"].ToString();
                this.RoomType.MaxOccupancy = int.Parse(dt.Rows[0]["MaxOccupancy"].ToString());

                this.BookingDate = dt.Rows[0]["BookingDate"].ToString();
                this.BookingTime = dt.Rows[0]["BookingTime"].ToString();
                this.CheckInDate = dt.Rows[0]["CheckInDate"].ToString();
                this.CheckOutDate = dt.Rows[0]["CheckOutDate"].ToString();
                this.NumberOfNights = int.Parse(dt.Rows[0]["NumberOfNights"].ToString());
                this.NumberOfRooms = int.Parse(dt.Rows[0]["NumberOfRooms"].ToString());
                this.NumberOfAdults = int.Parse(dt.Rows[0]["NumberOfAdults"].ToString());
                this.Surname = dt.Rows[0]["Surname"].ToString();
                this.FirstName = dt.Rows[0]["FirstName"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
                this.TotalAmount = double.Parse(dt.Rows[0]["TotalAmount"].ToString());

                this.ModeOfPayment.ModeOfPaymentID = int.Parse(dt.Rows[0]["ModeOfPaymentID"].ToString());
                this.ModeOfPayment.ModeOfPaymentValue = dt.Rows[0]["ModeOfPaymentValue"].ToString();
                this.ModeOfPayment.ModeOfPaymentName = dt.Rows[0]["ModeOfPaymentName"].ToString();

                this.PaymentCompleted = bool.Parse(dt.Rows[0]["PaymentCompleted"].ToString());
                this.RoomAllocationCompleted = bool.Parse(dt.Rows[0]["AllocationCompleted"].ToString());
                this.BookingCancelled = bool.Parse(dt.Rows[0]["BookingCancelled"].ToString());
                this.CancellationDate = dt.Rows[0]["CancellationDate"].ToString();
                this.CancellationTime = dt.Rows[0]["CancellationTime"].ToString();
            }
            else
            {
                throw new Exception("This booking does not exists.");
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

    public void Delete(int BookingId)
    {
        try
        {
            this.DeleteRecord(BookingId);
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

    public void CompleteBookingPayment()
    {
        SqlConnection con = null;

        try
        {
            if (this.RecordExist)
            {
                con = new SqlConnection();
                con.ConnectionString = this.Connectivity.ConnectionString.ToString();

                string strSQL = @"UPDATE Bookings SET                                                            
                                PaymentCompleted = @PaymentCompleted,
                                ModeOfPaymentID = @ModeOfPaymentID                                
                             WHERE (BookingID = @BookingID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;
                cmd.Parameters.Add("@PaymentCompleted", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@ModeOfPaymentID", SqlDbType.Int).Value = this.ModeOfPayment.ModeOfPaymentID;

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

    public void CancelBooking()
    {
        SqlConnection con = null;

        try
        {
            if (this.RecordExist)
            {
                con = new SqlConnection();
                con.ConnectionString = this.Connectivity.ConnectionString.ToString();

                string strSQL = @"UPDATE Bookings SET                                                            
                                BookingCancelled = @BookingCancelled,
                                CancellationDate = @CancellationDate,
                                CancellationTime = @CancellationTime
                             WHERE (BookingID = @BookingID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;
                cmd.Parameters.Add("@BookingCancelled", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@CancellationDate", SqlDbType.Date).Value = DateTime.Now.Date;
                cmd.Parameters.Add("@CancellationTime", SqlDbType.Time).Value = DateTime.Now.TimeOfDay;

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

                string strSQL = @"SELECT BookingID FROM Bookings
                                  WHERE (BookingID = @BookingID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = strSQL;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@BookingID", SqlDbType.VarChar).Value = this.BookingID;

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