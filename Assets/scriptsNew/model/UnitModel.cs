using System.Xml.Linq;
using System;

public class UnitModel
{
    //private int hp = 0, price = 0 , gold = 0, capacity = 0, attack = 0;
    //private bool movable = false;

    public int Hp { get; set; }
    public int Price { get; set; }
    public int Gold { get; set; }
    public int Capacity { get; set; }
    public int Attack { get; set; }

    public bool Movable { get; set; }

    public UnitModel appendix { get; set; } //10턴이 지나면 달라질 모습

    public UnitModel(XElement data)
    {
        this.Hp = Util.ParseInt(data.Element("Hp"));
        this.Price = Util.ParseInt(data.Element("Price"));
        this.Gold = Util.ParseInt(data.Element("Gold"));
        this.Capacity = Util.ParseInt(data.Element("Capacity"));
        this.Attack = Util.ParseInt(data.Element("Attack"));

        this.Movable = data.Element("Movable").Equals("true") ? true : false;

        XElement xeAppendix = data.Element("Appendix");

        //10턴이후 변경 사항 저장
        if(xeAppendix != null)
        {
            appendix.Hp = Math.Max(Util.ParseInt(xeAppendix.Element("Hp")), this.Hp);
            appendix.Price = Math.Max(Util.ParseInt(xeAppendix.Element("Price")), this.Price);
            appendix.Gold = Math.Max(Util.ParseInt(xeAppendix.Element("Gold")), this.Gold);
            appendix.Capacity = Math.Max(Util.ParseInt(xeAppendix.Element("Capacity")), this.Capacity);
            appendix.Attack = Math.Max(Util.ParseInt(xeAppendix.Element("Attack")), this.Attack);
        }
    }
}
