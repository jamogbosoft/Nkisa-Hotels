using System;
using System.Web.UI.WebControls;

public partial class ProcessPayment : System.Web.UI.Page
{
    public string strMerchantID = CRemitaConfigParams.MERCHANTID;
    public string strServiceTypeID = CRemitaConfigParams.SERVICETYPEID;
    public string strApiKey = CRemitaConfigParams.APIKEY;
    public string strHashed;
    public string strResponseURL = CRemitaConfigParams.RESPONSEURL;

    public string strSurname;
    public string strFirstName;
    public string strEmail;
    public string strPhoneNumber;
    public string strModeOfPaymentValue;
    public string strOrderID;
    public string strAmount;

    public Label lblSurname;
    public Label lblFirstName;
    public Label lblEmail;
    public Label lblPhoneNumber;
    public Label lblModeOfPaymentValue;
    public Label lblBookingID; //order_Id
    public Label lblAmount;

    void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (PreviousPage != null)
            {
                lblSurname = (Label)PreviousPage.FindControl("lblSurname");
                lblFirstName = (Label)PreviousPage.FindControl("lblFirstName");
                lblEmail = (Label)PreviousPage.FindControl("lblEmailAddress");
                lblPhoneNumber = (Label)PreviousPage.FindControl("lblPhoneNumber");                
                lblModeOfPaymentValue = (Label)PreviousPage.FindControl("LModeOfPaymentValue");
                lblBookingID = (Label)PreviousPage.FindControl("lblBookingID");
                lblAmount = (Label)PreviousPage.FindControl("LTotalAmount");

                strSurname = lblSurname.Text;
                strFirstName = lblFirstName.Text;
                strEmail = lblEmail.Text;
                strPhoneNumber = lblPhoneNumber.Text;
                //Let's generate rrr first. This will improve the performance
                strModeOfPaymentValue = "POS"; //lblModeOfPaymentValue.Text;
                strOrderID = lblBookingID.Text;
                strAmount = lblAmount.Text;

                string strHashString = strMerchantID + strServiceTypeID + strOrderID + strAmount + strResponseURL + strApiKey;
                System.Security.Cryptography.SHA512Managed sha512 = new System.Security.Cryptography.SHA512Managed();
                Byte[] EncryptedSHA512 = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strHashString));
                sha512.Clear();
                strHashed = BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
            }

            payerName.Value = strSurname + ", " + strFirstName;
            amt.Value = strAmount;
            payerPhone.Value = strPhoneNumber;
            payerEmail.Value = strEmail;
            merchantId.Value = strMerchantID;
            serviceTypeId.Value = strServiceTypeID;
            orderId.Value = strOrderID;
            responseurl.Value = strResponseURL;
            paymenttype.Value = strModeOfPaymentValue;
            hash.Value = strHashed;
        }

        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}