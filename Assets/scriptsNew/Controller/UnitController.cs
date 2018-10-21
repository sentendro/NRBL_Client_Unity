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

    public void Move(UnitGroupController enemies, int playerDir)
    {
        if(this.model.Move > 0)
        {
            bool canMove = true;

            int changeY = this.model.Y + playerDir * this.model.Move; //플레이어 방향을 고려

            foreach (UnitController enemy in enemies)
            {
                if(this.model.X == enemy.model.X && changeY == enemy.model.Y) //이동 후 위치가 해당 적과 같을 경우
                {
                    canMove = false;

                }
            }
        }
    }




}
