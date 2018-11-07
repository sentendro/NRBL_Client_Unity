using System.Xml.Linq;
using System;
using UnityEngine;

public class UnitModel
{
    //private int hp = 0, price = 0 , gold = 0, capacity = 0, attack = 0;
    //private bool movable = false;
    #region 속성, getter, setter
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Turn { get; set; }
    public int GrowUpTurn { get; set; }
    public int AddUnitTurn { get; set; }

    public int Hp { get; set; }
    public int Price { get; set; }
    public int Gold { get; set; }
    public int Capacity { get; set; }
    public int Attack { get; set; }
    public int Move { get; set; }
    public int Food { get; set; }

    public bool PlayerAttack { get; set; }

    public string FileName { get; set; }

    public UnitModel GrowUp { get; set; } //10턴이 지나면 달라질 모습
    public UnitModel AddUnit { get; set; } //일정 조건에 의해 추가되는 유닛
    public RangeAttackModel RangeAttack { get; set; } //장거리 공격
    public GameObject Prefab { get; set; }

    #endregion

    #region 생성자
    private UnitModel() { }

    public UnitModel(XElement data, int x, int y)
    {
        this.X = x;
        this.Y = y;

        #region 기본 생성 - 속성
        this.Hp = Util.ParseInt(data.Element("Hp"), 0);
        this.Price = Util.ParseInt(data.Element("Price"), 0);
        this.Gold = Util.ParseInt(data.Element("Gold"), 0);
        this.Capacity = Util.ParseInt(data.Element("Capacity"), 0);
        this.Attack = Util.ParseInt(data.Element("Attack"), 0);
        this.Turn = 0;
        this.Food = Util.ParseInt(data.Element("Food"), 0);
        this.GrowUpTurn = Util.ParseInt(data.Element("GrowUpTurn"), -1);
        this.AddUnitTurn = Util.ParseInt(data.Element("AddUnitTurn"), -1);

        this.Move = Util.ParseInt(data.Element("Move"), 0);
        this.PlayerAttack = Util.ParseBool(data.Element("PlayerAttack"), false);

        this.Prefab = Resources.Load<GameObject>(data.Element("FileName").Value);
        this.FileName = data.Element("FileName").Value;

        XElement xeGrowUp = data.Element("GrowUp");
        XElement xeAddUnit = data.Element("AddUnit");
        XElement xeRangeAttack = data.Element("RangeAttack");
        #endregion

        //10턴이후 변경 사항 저장
        if (xeGrowUp != null)
        {
            #region 10턴후 변화
            GrowUp = new UnitModel();

            GrowUp.Hp = Math.Max(Util.ParseInt(xeGrowUp.Element("Hp")), this.Hp);
            GrowUp.Price = Math.Max(Util.ParseInt(xeGrowUp.Element("Price")), this.Price);
            GrowUp.Gold = Math.Max(Util.ParseInt(xeGrowUp.Element("Gold")), this.Gold);
            GrowUp.Capacity = Math.Max(Util.ParseInt(xeGrowUp.Element("Capacity")), this.Capacity);
            GrowUp.Attack = Math.Max(Util.ParseInt(xeGrowUp.Element("Attack")), this.Attack);
            GrowUp.Food = Util.ParseInt(xeGrowUp.Element("Food"), this.Food);

            GrowUp.FileName = xeGrowUp.Element("FileName").Value;
            GrowUp.Move = Util.ParseInt(xeGrowUp.Element("Move"), this.Move);
            GrowUp.Prefab = this.Prefab;
            #endregion
        }

        //일정 조건에 의해 추가되는 유닛
        if (xeAddUnit != null)
        {
            #region 추가 유닛
            AddUnit = new UnitModel();

            AddUnit.Hp = Math.Max(Util.ParseInt(xeAddUnit.Element("Hp")), 0);
            AddUnit.Price = Math.Max(Util.ParseInt(xeAddUnit.Element("Price")), 0);
            AddUnit.Gold = Math.Max(Util.ParseInt(xeAddUnit.Element("Gold")), 0);
            AddUnit.Capacity = Math.Max(Util.ParseInt(xeAddUnit.Element("Capacity")), 0);
            AddUnit.Attack = Math.Max(Util.ParseInt(xeAddUnit.Element("Attack")), 0);
            AddUnit.Food = Util.ParseInt(xeAddUnit.Element("Food"), 0);

            AddUnit.FileName = xeAddUnit.Element("FileName").Value;
            AddUnit.Move = Util.ParseInt(xeAddUnit.Element("Move"), 0);
            AddUnit.Prefab = Resources.Load<GameObject>(xeAddUnit.Element("FileName").Value);
            #endregion
        }

        //장거리 공격
        if (xeRangeAttack != null)
        {
            RangeAttack = new RangeAttackModel();
            RangeAttack.Prefab = Resources.Load<GameObject>(xeRangeAttack.Element("FileName").Value);
            RangeAttack.Range = Util.ParseInt(xeRangeAttack.Element("Range"), 0);
            RangeAttack.Attack = Util.ParseInt(xeRangeAttack.Element("Attack"), 0);
        }
    }
    #endregion

    #region 10턴 이후 진화
    public void BeGrowUp()
    {
        this.Hp = this.GrowUp.Hp;
        this.Gold = this.GrowUp.Gold;
        this.Capacity = this.GrowUp.Capacity;
        this.Attack = this.GrowUp.Attack;
        this.Move = this.GrowUp.Move;
        this.Food = this.GrowUp.Food;
        this.Prefab = this.GrowUp.Prefab;
    }
    #endregion

    #region 유닛 복사 Clone(), Clone(x,y)
    public UnitModel Clone()
    {
        return Clone(this.X, this.Y);
    }

    public UnitModel Clone(int x, int y)
    {
        UnitModel result = new UnitModel();

        result.X = x;
        result.Y = y;

        result.Hp = this.Hp;
        result.Price = this.Price;
        result.Gold = this.Gold;
        result.Capacity = this.Capacity;
        result.Attack = this.Attack;
        result.Move = this.Move;
        result.Food = this.Food;
        result.Prefab = this.Prefab;

        if(GrowUp != null)
        {
            result.GrowUp = new UnitModel();

            result.GrowUp.Hp = this.GrowUp.Hp;
            result.GrowUp.Price = this.GrowUp.Price;
            result.GrowUp.Gold = this.GrowUp.Gold;
            result.GrowUp.Capacity = this.GrowUp.Capacity;
            result.GrowUp.Attack = this.GrowUp.Attack;
            result.GrowUp.Move = this.GrowUp.Move;
            result.GrowUp.Food = this.GrowUp.Food;
            result.GrowUp.Prefab = this.GrowUp.Prefab;
        }

        if(AddUnit != null)
        {
            result.AddUnit = new UnitModel();

            result.AddUnit.Hp = this.AddUnit.Hp;
            result.AddUnit.Price = this.AddUnit.Price;
            result.AddUnit.Gold = this.AddUnit.Gold;
            result.AddUnit.Capacity = this.AddUnit.Capacity;
            result.AddUnit.Attack = this.AddUnit.Attack;
            result.AddUnit.Move = this.AddUnit.Move;
            result.AddUnit.Food = this.AddUnit.Food;
            result.AddUnit.Prefab = this.AddUnit.Prefab;
        }

        //장거리 공격
        if (RangeAttack != null)
        {
            result.RangeAttack = new RangeAttackModel();
            result.RangeAttack.Prefab = this.RangeAttack.Prefab;
            result.RangeAttack.Range = this.RangeAttack.Range;
        }

        return result;
    }
    #endregion
}
