using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class UnitGroupController {
    private const string UNIT_BALANCE_DIR = "data/units";
    private Dictionary<string, XElement> htBalance = new Dictionary<string, XElement>();
    private List<UnitController> units = new List<UnitController>();
    private StageController stage;
    public UserModel User { get; set; }

    public UnitGroupController(StageController stage)
    {
        //!!WARNING 로드는 여기서 안됨. 무조건 Start, Awake로 빼야함
        string data = Resources.Load<TextAsset>(UNIT_BALANCE_DIR).text;
        XElement xeData = XElement.Parse(data);
        foreach (XElement item in xeData.Elements()) 
        {
            htBalance.Add(item.Element("Name").Value, item);
        }

        this.stage = stage;
        this.User = new UserModel();
    }

    #region 유닛 추가, CAPACITY 구하기
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void AddUnit(string name, int x, int y)
    {
        UnitModel model = new UnitModel(htBalance[name], x, y);
        AddUnit(model);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    public void AddUnit(UnitModel model)
    {
        UnitController ctlr = new UnitController(model);
        units.Add(ctlr);
        Logger.Log(Logger.KEY_UNIT_MAKE, string.Format("unit created x:{0} y:{1} name:{2}", model.X, model.Y, model.FileName));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetRemainCapacity()
    {
        int capacitySum = 0;

        foreach (UnitController unit in units)
        {
            capacitySum += unit.Capacity;
            capacitySum -= unit.Food;
        }

        return capacitySum;
    }

    /// <summary>
    /// 유닛을 유저가 추가 가능한 상태인지 확인
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public int CanAddUnit(UnitModel model)
    {
        if (model.Price > 0 && model.Price > User.Gold) //가격
        {
            return Reason.ADD_UNIT_PRICE;
        }

        if(model.Food > 0 && model.Food > GetRemainCapacity()) //식사량
        {
            return Reason.ADD_UNIT_FOOD;
        }

        return Reason.ADD_UNIT_SUCCESS;
    }
    #endregion

    public IEnumerator<UnitController> GetEnumerator()
    {
        return units.GetEnumerator();
    }
}
