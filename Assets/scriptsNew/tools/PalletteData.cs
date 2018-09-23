using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

class PalletteData
{
    public const string UNITDATA_DIR = "data/units";
    public LinkedList<GameObject> list = new LinkedList<GameObject>();
    private int length;

    public int Length
    {
        get { return length; }
    }

    public IEnumerable<GameObject> GetPalletteUnit()
    {
        length = 0;

        string strUnitArray = Resources.Load<TextAsset>(UNITDATA_DIR).text;
        XElement xeUnitArray = XElement.Parse(strUnitArray);

        IEnumerable<XElement> iterator = xeUnitArray.Elements();

        foreach(XElement child in iterator)
        {
            GameObject obj = Resources.Load<GameObject>("unit/blue/" + child.Element("FileName").Value);
            length++;
            yield return obj;
        }
    }
}
