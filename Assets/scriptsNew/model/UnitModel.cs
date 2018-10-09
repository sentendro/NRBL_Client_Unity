using System.Xml.Linq;
using System;
using UnityEngine;

public class UnitModel
{
    //private int hp = 0, price = 0 , gold = 0, capacity = 0, attack = 0;
    //private bool movable = false;

    public int X { get; set; }
    public int Y { get; set; }

    public int Hp { get; set; }
    public int Price { get; set; }
    public int Gold { get; set; }
    public int Capacity { get; set; }
    public int Attack { get; set; }

    public bool Movable { get; set; }
    public bool PlayerAttack { get; set; }

    public UnitModel GrowUp { get; set; } //10턴이 지나면 달라질 모습
    public UnitModel AddUnit { get; set; } //일정 조건에 의해 추가되는 유닛
    public RangeAttack RangeAttack { get; set; } //장거리 공격
    private UnitModel() { }

    public UnitModel(XElement data, int x, int y)
    {
        this.X = x;
        this.Y = y;

        this.Hp = Util.ParseInt(data.Element("Hp"));
        this.Price = Util.ParseInt(data.Element("Price"));
        this.Gold = Util.ParseInt(data.Element("Gold"));
        this.Capacity = Util.ParseInt(data.Element("Capacity"));
        this.Attack = Util.ParseInt(data.Element("Attack"));

        this.Movable = Util.ParseBool(data.Element("Movable"));
        this.PlayerAttack = Util.ParseBool(data.Element("PlayerAttack"));

        XElement xeGrowUp = data.Element("GrowUp");
        XElement xeAddUnit = data.Element("AddUnit");
        XElement xeRangeAttack = data.Element("RangeAttack");

        //10턴이후 변경 사항 저장
        if(xeGrowUp != null)
        {
            GrowUp = new UnitModel();

            GrowUp.Hp = Math.Max(Util.ParseInt(xeGrowUp.Element("Hp")), this.Hp);
            GrowUp.Price = Math.Max(Util.ParseInt(xeGrowUp.Element("Price")), this.Price);
            GrowUp.Gold = Math.Max(Util.ParseInt(xeGrowUp.Element("Gold")), this.Gold);
            GrowUp.Capacity = Math.Max(Util.ParseInt(xeGrowUp.Element("Capacity")), this.Capacity);
            GrowUp.Attack = Math.Max(Util.ParseInt(xeGrowUp.Element("Attack")), this.Attack);

            GrowUp.Movable = Util.ParseBool(xeGrowUp.Element("Movable")) || this.Movable;
        }

        //일정 조건에 의해 추가되는 유닛
        if (xeAddUnit != null)
        {
            AddUnit = new UnitModel();

            AddUnit.Hp = Math.Max(Util.ParseInt(xeAddUnit.Element("Hp")), this.Hp);
            AddUnit.Price = Math.Max(Util.ParseInt(xeAddUnit.Element("Price")), this.Price);
            AddUnit.Gold = Math.Max(Util.ParseInt(xeAddUnit.Element("Gold")), this.Gold);
            AddUnit.Capacity = Math.Max(Util.ParseInt(xeAddUnit.Element("Capacity")), this.Capacity);
            AddUnit.Attack = Math.Max(Util.ParseInt(xeAddUnit.Element("Attack")), this.Attack);

            AddUnit.Movable = Util.ParseBool(xeAddUnit.Element("Movable")) || this.Movable;
        }

        //장거리 공격
        if(xeRangeAttack != null)
        {
            RangeAttack = new RangeAttack();
            RangeAttack.Prefab = Resources.Load<GameObject>(xeRangeAttack.Element("FileName").Value);
            RangeAttack.Range = int.Parse(xeRangeAttack.Element("Range").Value);
        }
    }

    public UnitModel Clone()
    {
        UnitModel result = new UnitModel();

        result.X = this.X;
        result.Y = this.Y;

        result.Hp = this.Hp;
        result.Price = this.Price;
        result.Gold = this.Gold;
        result.Capacity = this.Capacity;
        result.Attack = this.Attack;
        result.Movable = this.Movable;

        if(GrowUp != null)
        {
            result.GrowUp = new UnitModel();

            result.GrowUp.Hp = this.GrowUp.Hp;
            result.GrowUp.Price = this.GrowUp.Price;
            result.GrowUp.Gold = this.GrowUp.Gold;
            result.GrowUp.Capacity = this.GrowUp.Capacity;
            result.GrowUp.Attack = this.GrowUp.Attack;
            result.GrowUp.Movable = this.GrowUp.Movable;
        }

        return result;
    }
}
