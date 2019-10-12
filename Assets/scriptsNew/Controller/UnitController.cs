using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;

public class UnitController
{
    private UnitModel model;

    #region 생성자
    public UnitController(UnitModel model)
    {
        this.model = model;
    }
    #endregion

    #region 간단한 Getter
    public int Food { get { return model.Food; } }
    public int Capacity { get { return model.Capacity; } }
    public bool IsAlive { get { return this.model.Hp > 0; } }

    public bool CanPurchase(int playerMoney)
    {
        return playerMoney >= this.model.Price;
    }

    public bool IsSamePosition(UnitModel unit)
    {
        return model.X == unit.X && model.Y == unit.Y;
    }
    #endregion

    #region 기본 턴처리
    public void Update(UserModel user)
    {
        if(this.model.Gold > 0)
        {
            user.Gold += this.model.Gold;
        }
    }
    #endregion

    #region 정면 이동
    /// <summary>
    /// 정면 충돌시 데미지
    /// </summary>
    /// <param name="enemyCtlr"></param>
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

    /// <summary>
    /// 이동이 끝에 다다를 경우
    /// </summary>
    public void UpdatePlayerAttack(UserModel enemy, int playerDir)
    {
        if(this.model.Move > 0 && this.model.Attack > 0)
        {
            bool caseTop = playerDir < 0 && this.model.X == 0;
            bool caseBottom = playerDir > 0 && this.model.X == 7;

            if(caseTop || caseBottom)
            {
                enemy.Hp -= this.model.Attack;
            }
        }
    }
    #endregion

    #region 턴관련 처리 (10턴 이후 진화, 유닛 생성)
    public void UpdateTurn(UnitGroupController myUnitList, int playerDir)
    {
        this.model.Turn++;

        if(this.model.GrowUpTurn > 0 && this.model.Turn == this.model.GrowUpTurn)
        {
            this.model.BeGrowUp();
        }

        if(this.model.AddUnitTurn > 0 && this.model.Turn % this.model.AddUnitTurn == 0)
        {
            //AddUnit은 여러번 발생
            int addUnitY = this.model.Y + playerDir * 1; //플레이어 방향을 고려

            //Name으로 처리
            myUnitList.AddUnit(this.model.AddUnit.Clone(this.model.X, addUnitY));
        }
    }
    #endregion

    #region 장거리공격 처리
    /// <summary>
    /// 장거리공격 처리
    /// </summary>
    /// <param name="enemyList"></param>
    /// <param name="playerDIr"></param>
    public void UpdateRangeAttack(UnitGroupController enemyList, int playerDIr)
    {
        if(this.model.RangeAttack != null)
        {
            UnitController enemy = null;
            //장거리 미사일 발사 공격
            for (int range = 1; range <= this.model.RangeAttack.Range; range++)
            {
                int rangeY = this.model.Y + playerDIr * range;
                enemy = GetFrontUnit(enemyList, rangeY);

                if(enemy != null) //범위내에서 제일 가까운 유닛 발견
                {
                    break;
                }
            }

            if(enemy != null)
            {
                enemy.Damage(this);
            }
        }
    }
    #endregion

}
