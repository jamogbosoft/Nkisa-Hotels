using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Wedding : System.Web.UI.Page
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

                customCalendarExtenderDateOfTheWedding.StartDate = DateTime.Parse(strStartDate);

                customCalendarExtenderDateOfTheWedding.SelectedDate = DateTime.Parse(strStartDate);

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
                cboWeddingHallCapacity.Items.Add((50 * i).ToString());
                cboReceptionHallCapacity.Items.Add((50 * i).ToString());
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

            txtSurname.Text = txtFirstName.Text = txtEmailAddress.Text = txtDateOfTheWedding.Text = txtComment.Text = "";
            cboStartingTime.SelectedIndex = 0;
            cboTimeDuration.SelectedIndex = 0;
            chkWeddingHall.Checked = false;
            chkReception.Checked = false;
            cboWeddingHallCapacity.SelectedIndex = 0;
            cboReceptionHallCapacity.SelectedIndex = 0;
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

            CWedding Wedding = new CWedding();

            Wedding.TransactionDate = DateTime.Now.Date.ToShortDateString();
            Wedding.TransactionTime = DateTime.Now.ToLongTimeString();
            Wedding.Surname = txtSurname.Text.ToString();
            Wedding.FirstName = txtFirstName.Text.ToString();
            Wedding.Email = txtEmailAddress.Text.ToString();
            Wedding.DateOfTheWedding = txtDateOfTheWedding.Text.ToString();
            Wedding.StartingTime = cboStartingTime.Text.ToString();
            Wedding.TimeDuration = int.Parse(cboTimeDuration.Text.ToString());
           
            if (chkWeddingHall.Checked)
            {
                Wedding.WeddingHall = true;
            }
            else { Wedding.WeddingHall = false; }
            
            if (chkReception.Checked)
            {
                Wedding.ReceptionHall = true;
            }
            else { Wedding.ReceptionHall = false; }

            if (Wedding.WeddingHall == true)
            {
                Wedding.WeddingHallCapacity = int.Parse(cboWeddingHallCapacity.Text.ToString());
            }
            else { Wedding.WeddingHallCapacity = 0; }
            
            if (Wedding.ReceptionHall == true)
            {
                Wedding.ReceptionHallCapacity = int.Parse(cboReceptionHallCapacity.Text.ToString());
            }
            else { Wedding.ReceptionHallCapacity = 0; }

            Wedding.Comment = txtComment.Text.ToString();


            Wedding.Add();


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
    protected void chkWeddingHall_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            if (chkWeddingHall.Checked)
            {
                lblWeddingHallCapacity.Visible = true;
                cboWeddingHallCapacity.Visible = true;
                cboWeddingHallCapacity.SelectedIndex = 0;
            }
            else
            {
                lblWeddingHallCapacity.Visible = false;
                cboWeddingHallCapacity.Visible = false;
            }

            customCalendarExtenderDateOfTheWedding.SelectedDate = DateTime.Parse(txtDateOfTheWedding.Text);
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message.ToString(), "Error");
            Message2.ShowError(ex.Message.ToString(), "Error");
        }
    }
    protected void chkReception_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkReception.Checked)
            {
                lblReceptionHallCapacity.Visible = true;
                cboReceptionHallCapacity.Visible = true;
                cboReceptionHallCapacity.SelectedIndex = 0;

            }
            else
            {
                lblReceptionHallCapacity.Visible = false;
                cboReceptionHallCapacity.Visible = false;
            }

            customCalendarExtenderDateOfTheWedding.SelectedDate = DateTime.Parse(txtDateOfTheWedding.Text);
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message.ToString(), "Error");
            Message2.ShowError(ex.Message.ToString(), "Error");
        }
    }
}