using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    private CPersonalDetails PersonalDetail;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                PersonalDetail = new CPersonalDetails();
                PersonalDetail.LoadPersonalDetails(this.Page.User.Identity.Name);

                txtSurname.Text = PersonalDetail.Surname;
                txtFirstName.Text = PersonalDetail.FirstName;
                txtEmailAddress.Text = PersonalDetail.Email;
                txtPhoneNumber.Text = PersonalDetail.PhoneNumber;
            }
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            PersonalDetail = new CPersonalDetails();

            PersonalDetail.UserName = this.Page.User.Identity.Name;
            if (PersonalDetail.UserName != "")
            {
                PersonalDetail.Surname = txtSurname.Text;
                PersonalDetail.FirstName = txtFirstName.Text;
                PersonalDetail.Email = txtEmailAddress.Text;
                PersonalDetail.PhoneNumber = txtPhoneNumber.Text;

                PersonalDetail.Update();
            }
            else { Message1.ShowError("You are a guest and should not be allowed to access this page","Update Cancelled"); }
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message);
        }

    }
}