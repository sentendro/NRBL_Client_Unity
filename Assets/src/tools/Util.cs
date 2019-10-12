using System.Xml.Linq;

public class Util
{
    public static int ParseInt(XElement xe, int defaultValue = 0)
    {
        if(xe == null)
        {
            return defaultValue;
        }
        else
        {
            return int.Parse(xe.Value);
        }
    }

    public static bool ParseBool(XElement xe, bool defaultValue = false)
    {
        if(xe == null)
        {
            return defaultValue;
        }
        else
        {
            return xe.Value.Equals("true") ? true : false;
        }
    }

    public static string GetValueString(XElement xe, string defaultValue = "")
    {
        if (xe == null)
        {
            return defaultValue;
        }
        else
        {
            return xe.Value;
        }
    }

    public static void CheckNoAssignException<T>(object obj, T variable)
    {
        if(variable == null)
        {
            throw new NoAssignedException(obj, typeof(T).Name);
        }
    }
}
