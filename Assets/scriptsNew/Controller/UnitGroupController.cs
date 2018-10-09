using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class UnitGroupController{
    private const string UNIT_BALANCE_DIR = "data/units";
    private Dictionary<string, XElement> htBalance = new Dictionary<string, XElement>();
    private List<UnitModel> units = new List<UnitModel>();

    public UnitGroupController()
    {
        string data = Resources.Load<TextAsset>(UNIT_BALANCE_DIR).text;
        XElement xeData = XElement.Parse(data);
        foreach (XElement item in xeData.Elements())
        {
            htBalance.Add(item.Element("Name").Value, item);
        }
    }

    public void AddUnit(string name, int x, int y)
    {
        UnitModel model = new UnitModel(htBalance[name], x, y);
        units.Add(model);
    }
}
