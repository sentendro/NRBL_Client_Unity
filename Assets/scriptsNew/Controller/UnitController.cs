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

    public int Food { get { return model.Food; } }

    public bool IsAlive { get { return this.model.Hp > 0; } }

    public bool CanPurchase(int playerMoney)
    {
        return playerMoney >= this.model.Price;
    }

    public void Damage(UnitController enemyCtlr)
    {
        this.model.Hp -= enemyCtlr.model.Attack;
    }

    /// <summary>
    /// 이동시 정면에 유닛이 있는지 확인
    /// </summary>
    /// <param name="unitList">모든 유닛 배열</param>
    /// <param name="changeY">이동 후 유닛의 Y좌표</param>
    public UnitController GetFrontUnit(UnitGroupController unitList, int changeY)
    {
        foreach (UnitController unit in unitList)
        {
            if (this.model.X == unit.model.X && changeY == unit.model.Y) //이동 후 위치가 해당 유닛과 같을 경우
            {
                return unit;
            }
        }

        return null;
    }

    /// <summary>
    /// 자동 이동 처리(충돌 판정 포함)
    /// </summary>
    /// <param name="enemyList">모든 에너미 배열</param>
    /// <param name="myUnitList">모든 플레이어 유닛 배열</param>
    /// <param name="playerDir">유닛 이동 방향(위:-1, 아래:1)</param>
    public void UpdateMove(UnitGroupController enemyList, UnitGroupController myUnitList, int playerDir)
    {
        if (this.model.Move > 0)
        {
            int changeY = this.model.Y + playerDir * this.model.Move; //플레이어 방향을 고려

            UnitController enemy = GetFrontUnit(enemyList, changeY);
            UnitController myUnit = GetFrontUnit(myUnitList, changeY);

            if (enemy != null) //바로 앞에 적이 있음. 이동 아닌 공격
            {
                enemy.Damage(this);
            }
            else if (myUnit != null) //바로 앞에 우리 유닛
            {

            }
            else //이동
            {
                this.model.Y = changeY;
            }
        }
    }




}
