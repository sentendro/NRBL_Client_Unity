using System.Xml.Linq;
using System;

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

    public UnitModel appendix { get; set; } //10턴이 지나면 달라질 모습

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

        XElement xeAppendix = data.Element("Appendix");

        //10턴이후 변경 사항 저장
        if(xeAppendix != null)
        {
            appendix = new UnitModel();

            appendix.Hp = Math.Max(Util.ParseInt(xeAppendix.Element("Hp")), this.Hp);
            appendix.Price = Math.Max(Util.ParseInt(xeAppendix.Element("Price")), this.Price);
            appendix.Gold = Math.Max(Util.ParseInt(xeAppendix.Element("Gold")), this.Gold);
            appendix.Capacity = Math.Max(Util.ParseInt(xeAppendix.Element("Capacity")), this.Capacity);
            appendix.Attack = Math.Max(Util.ParseInt(xeAppendix.Element("Attack")), this.Attack);

            appendix.Movable = Util.ParseBool(xeAppendix.Element("Movable")) || this.Movable;
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

        if(appendix != null)
        {
            result.appendix = new UnitModel();

            result.appendix.Hp = this.appendix.Hp;
            result.appendix.Price = this.appendix.Price;
            result.appendix.Gold = this.appendix.Gold;
            result.appendix.Capacity = this.appendix.Capacity;
            result.appendix.Attack = this.appendix.Attack;
            result.appendix.Movable = this.appendix.Movable;
        }

        return result;
    }
}
