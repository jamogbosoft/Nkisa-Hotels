using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class CReCaptchaResponse
{

    public string success { get; set; }
    public string challenge_ts { get; set; }
    public string hostname { get; set; }


    /*
    private bool strSuccess;
    [JsonProperty("success")]
    public bool Success
    {
        get { return strSuccess; }
        set { strSuccess = bool.Parse( value.ToString()); }
    }

    private string strchallenge_ts;
    [JsonProperty("challenge_ts")]
    public string Challenge
    {
        get { return strchallenge_ts; }
        set { strchallenge_ts = value; }
    }

    private string strhostname;
    [JsonProperty("hostname")]
    public string Hostname
    {
        get { return strhostname; }
        set { strhostname = value; }
    }

    private List<string> strErrorCodes;
    [JsonProperty("error-codes")]
    public List<string> ErrorCodes
    {
        get { return strErrorCodes; }
        set { strErrorCodes = value; }
    }
     */
}