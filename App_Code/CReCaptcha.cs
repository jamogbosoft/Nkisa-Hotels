using System.Net;
using Newtonsoft.Json;

public class CReCaptcha
{
    private string strResponse;
    private string strChallenge;
    private string strURL = "https://www.google.com/recaptcha/api/verify";
    private string strSecretkey = "6LeCxAgUAAAAAJwbfntC_rWnAr40Iv9ranjMJc1R";
    private string strRemoteIP;

    public CReCaptcha(string response, string challenge, string remoteIp)
    {
        strResponse = response;
        strChallenge = challenge;
        strRemoteIP = remoteIp;
    }

    public bool IsValid
    {
        get
        {
            try
            {
                strURL += "?privatekey=" + strSecretkey + "&response=" + strResponse + "&challenge=" + strChallenge + "&remoteip=" + strRemoteIP;

                string jsondata = new WebClient().DownloadString(strURL);
                //CReCaptchaResponse ReCaptchaResponse = JsonConvert.DeserializeObject<CReCaptchaResponse>(jsondata);
                string[] ReResponse = jsondata.Split('\n');
                if (ReResponse[0].ToString().ToLower() == "true") { return true; }
                else { return false; }
                //return ReCaptchaResponse.success;
            }
            catch { return false; }
        }
    }
}