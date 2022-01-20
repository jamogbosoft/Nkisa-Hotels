using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Meeting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                FillStartingTime();
                FillTimeDuration();
                FillCapacity();

                //DateTime d = DateTime.Parse("02/08/2009");
                string strStartDate = DateTime.Now.Date.ToShortDateString();

                customCalendarExtenderDateOfTheMeeting.StartDate = DateTime.Parse(strStartDate);

                customCalendarExtenderDateOfTheMeeting.SelectedDate = DateTime.Parse(strStartDate);

                // RegularExpressionValidatorDateOfTheMeeting.ValidationExpression = @"((([0]([1,2,3,4,5,6,7,8,9]))|([1]\d)|([2]\d)|([3]([0,1])))/(([0]([1,2,3,4,5,6,7,8,9]))|([1]([0]|[1]|[2])))/(" + DateTime.Parse(strStartDate).Year.ToString() +"))";

            }
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message.ToString(), "Error");
            Message2.ShowError(ex.Message.ToString(), "Error");
        }
    }

    private void FillStartingTime()
    {
        try
        {
            string[] s = { "12:00 AM", "12:30 AM", "1:00 AM", "1:30 AM", "2:00 AM", "2:30 AM", "3:00 AM", "3:30 AM", "4:00 AM", "4:30 AM", "5:00 AM", "5:30 AM", "6:00 AM", "6:30 AM", "7:00 AM", "7:30 AM", "8:00 AM", "8:30 AM", "9:00 AM", "9:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM",
                           "12:00 PM", "12:30 PM", "1:00 PM", "1:30 PM", "2:00 PM", "2:30 PM", "3:00 PM", "3:30 PM", "4:00 PM", "4:30 PM", "5:00 PM", "5:30 PM", "6:00 PM", "6:30 PM", "7:00 PM", "7:30 PM", "8:00 PM", "8:30 PM", "9:00 PM", "9:30 PM", "10:00 PM", "10:30 PM", "11:00 PM", "11:30 PM" };

            for (int i = 0; i < s.Count(); i++)
            {
                cboStartingTime.Items.Add(s[i].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillTimeDuration()
    {
        try
        {
            for (int i = 1; i <= 300; i++)
            {
                cboTimeDuration.Items.Add(i.ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillCapacity()
    {
        try
        {
            for (int i = 1; i <= 200; i++)
            {
                cboCapacity.Items.Add((50 * i).ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtSurname.Text = txtFirstName.Text = txtEmailAddress.Text = txtDateOfTheMeeting.Text = txtComment.Text = "";
            cboStartingTime.SelectedIndex = 0;
            cboTimeDuration.SelectedIndex = 0;
            cboCapacity.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message.ToString(), "Error");
            Message2.ShowError(ex.Message.ToString(), "Error");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            CMeeting Meeting = new CMeeting();

            Meeting.TransactionDate = DateTime.Now.Date.ToShortDateString();
            Meeting.TransactionTime = DateTime.Now.ToLongTimeString();
            Meeting.Surname = txtSurname.Text.ToString();
            Meeting.FirstName = txtFirstName.Text.ToString();
            Meeting.Email = txtEmailAddress.Text.ToString();
            Meeting.DateOfTheMeeting = txtDateOfTheMeeting.Text.ToString();
            Meeting.StartingTime = cboStartingTime.Text.ToString();
            Meeting.TimeDuration = int.Parse (cboTimeDuration.Text.ToString());
            Meeting.Capacity = int.Parse(cboCapacity.Text.ToString());
            Meeting.Comment = txtComment.Text.ToString();

            Meeting.Add();
          
            this.btnCancel_Click(sender, e);

            Message1.ShowMessage("Message Sent!");
            Message2.ShowMessage("Message Sent!");
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message.ToString(), "Error");
            Message2.ShowError(ex.Message.ToString(), "Error");
        }
    }
}