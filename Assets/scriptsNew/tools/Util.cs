using System.Xml.Linq;

public class Util
{
    public static int ParseInt(XElement xe)
    {
        if(xe == null)
        {
            return 0;
        }
        else
        {
            return int.Parse(xe.Value);
        }
    }

    public static bool ParseBool(XElement xe)
    {
        if(xe == null)
        {
            return false;
        }
        else
        {
            return xe.Value.Equals("true") ? true : false;
        }
    }
}
