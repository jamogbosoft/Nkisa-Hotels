using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact_Us_ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtSurname.Text = txtFirstName.Text = txtEmailAddress.Text = txtMessage.Text = "";
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
            CContactUs ContactUs = new CContactUs();

            ContactUs.TransactionDate = DateTime.Now.Date.ToShortDateString();
            ContactUs.TransactionTime = DateTime.Now.ToLongTimeString();
            ContactUs.Surname = txtSurname.Text.ToString();
            ContactUs.FirstName = txtFirstName.Text.ToString();
            ContactUs.Email = txtEmailAddress.Text.ToString();
            ContactUs.Message = txtMessage.Text.ToString();

            ContactUs.Add();
                        
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