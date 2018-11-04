using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class UnitGroupController{
    private const string UNIT_BALANCE_DIR = "data/units";
    private Dictionary<string, XElement> htBalance = new Dictionary<string, XElement>();
    private List<UnitController> units = new List<UnitController>();

    public UnitGroupController()
    {
        string data = Resources.Load<TextAsset>(UNIT_BALANCE_DIR).text;
        XElement xeData = XElement.Parse(data);
        foreach (XElement item in xeData.Elements())
        {
            htBalance.Add(item.Element("Name").Value, item);
        }
    }

    #region 유닛 추가, CAPACITY 구하기
    public void AddUnit(string name, int x, int y)
    {
        UnitModel model = new UnitModel(htBalance[name], x, y);
        AddUnit(model);
    }

    public void AddUnit(UnitModel model)
    {
        UnitController ctlr = new UnitController(model);
        units.Add(ctlr);
        //여기서 Instantiate도 하는게 좋을 것 같다
    }

    public int GetRemainCapacity(UnitModel addUnit)
    {
        int capacitySum = 0;

        foreach (UnitController unit in units)
        {
            capacitySum += unit.Capacity;
        }

        return capacitySum;
    }
    #endregion

    public IEnumerator<UnitController> GetEnumerator()
    {
        return units.GetEnumerator();
    }
}
