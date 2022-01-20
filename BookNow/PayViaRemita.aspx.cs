using System;
using System.Web.UI.WebControls;
using System.Web;

public partial class PayViaRemita : System.Web.UI.Page
{
    public string strMerchantID = CRemitaConfigParams.MERCHANTID;
    public string strApiKey = CRemitaConfigParams.APIKEY;
    public string strHashed;
    public string strResponseURL = CRemitaConfigParams.RESPONSEURL;
        
    void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CQueryStringEncryption QueryString = new CQueryStringEncryption();
                CPaymentHistory PaymentHistory = new CPaymentHistory();

                string strRRR = QueryString.Decrypt(HttpUtility.UrlDecode(Request.QueryString["i"]));
                
                PaymentHistory.LoadPaymentRRR(strRRR);

                if (PaymentHistory.Payment.RRR != "")
                {
                    string strHashString = strMerchantID + strRRR + strApiKey;
                    System.Security.Cryptography.SHA512Managed sha512 = new System.Security.Cryptography.SHA512Managed();
                    Byte[] EncryptedSHA512 = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strHashString));
                    sha512.Clear();
                    strHashed = BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
                }
                merchantId.Value = strMerchantID;
                hash.Value = strHashed;
                rrr.Value = strRRR;
                responseurl.Value = strResponseURL;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}