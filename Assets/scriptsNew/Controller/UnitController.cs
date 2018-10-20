using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;

public class UnitController
{
    private UnitModel model;

    public UnitController(XElement xeUnit, int x, int y)
    {
        this.model = new UnitModel(xeUnit, x, y);
    }

    public void UpdateNextTurn()
    {

    }

    public bool IsAlive { get { return this.model.Hp > 0; } }

    public bool CanPurchase(int playerMoney)
    {
        return playerMoney >= this.model.Price;
    }

    public void Damage(UnitController enemyCtlr)
    {
        this.model.Hp -= enemyCtlr.model.Attack;
    }

    public void Move(IEnumerator<UnitController> enemies)
    {
        if(this.model.Movable)
        {

        }
    }




}
