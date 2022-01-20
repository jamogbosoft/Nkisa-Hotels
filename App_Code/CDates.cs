
/// <summary>
/// Summary description for CDates
/// </summary>
public class CDate
{
	public CDate()
	{
		
	}

}

public class CMonth
{
    string strMonth;
    public CMonth(string month)
    {
        switch (month)
        {
            case "Jan.": strMonth = "01"; break;
            case "Feb.": strMonth = "02"; break;
            case "Mar.": strMonth = "03"; break;
            case "Apr.": strMonth = "04"; break;
            case "May.": strMonth = "05"; break;
            case "Jun.": strMonth = "06"; break;
            case "Jul.": strMonth = "07"; break;
            case "Aug.": strMonth = "08"; break;
            case "Sep.": strMonth = "09"; break;
            case "Oct.": strMonth = "10"; break;
            case "Nov.": strMonth = "11"; break;
            case "Dec.": strMonth = "12"; break;
            default : strMonth = "00"; break;
        }
    }

    public string Month
    {
        get { return strMonth; }
    }
}


public class CNumberOfAdultsInWords
{
    private string strInWords;
    public CNumberOfAdultsInWords(int inWords)
    {
        if (inWords == 0 || inWords == 1)
        {
            strInWords = inWords.ToString() + " Adult.";
        }
        else
        {
            strInWords = inWords.ToString() + " Adults.";
        }
    }

    public string InWords
    {
        get { return strInWords; }
    }
}


public class CNumberOfNightsInWords
{
    private string strInWords;
    public CNumberOfNightsInWords(int inWords)
    {
        if (inWords == 0 || inWords == 1)
        {
            strInWords = inWords.ToString() + " Night.";
        }
        else
        {
            strInWords = inWords.ToString() + " Nights.";
        }
    }

    public string InWords
    {
        get { return strInWords; }
    }
}


public class CNumberOfRoomsInWords
{
    private string strInWords;
    public CNumberOfRoomsInWords(int inWords)
    {
        if (inWords == 0 || inWords == 1)
        {
            strInWords = inWords.ToString() + " Room.";
        }
        else
        {
            strInWords = inWords.ToString() + " Rooms.";
        }
    }

    public string InWords
    {
        get { return strInWords; }
    }
}