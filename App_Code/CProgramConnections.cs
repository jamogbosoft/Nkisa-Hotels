using System;
using System.Configuration;

/// <summary>
/// class CConnectivity
/// </summary>
public class CConnectivity
{
    private ConnectionStringSettings css;

    public CConnectivity()
    {
        try
        {
            css = ConfigurationManager.ConnectionStrings["ApplicationServices"];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Returns string Connection String
    /// </summary>
    public string ConnectionString
    {
        get
        {
            try
            {
                return css.ConnectionString.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
    