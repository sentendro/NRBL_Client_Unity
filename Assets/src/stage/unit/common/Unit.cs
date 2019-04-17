using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 구매 기능
// 데미지 받는 기능
public class Unit : MonoBehaviour
{
    public int price;
    public int food;
    public int hp;
    public TurnChecker inTurnChecker;

    public int PlayerPrice
    {
        get
        {
            return price;
        }
    }

    public int PlayerFood
    {
        get
        {
            return food;
        }
    }

    public int EnemyPrice
    {
        get
        {
            return price;
        }
    }

    public int EnemyFood
    {
        get
        {
            return food;
        }
    }

    public virtual void OnCreate()
    {
        inTurnChecker = GetComponent<TurnChecker>();

        if(inTurnChecker != null)
        {
            inTurnChecker.OnUnitCreate();
        }
    }

    public virtual void TurnUpdate()
    {
        if(inTurnChecker != null)
        {
            inTurnChecker.TurnUpdate();
        }
    }

    public virtual void OnDie()
    {
        if (inTurnChecker != null)
        {
            Destroy(inTurnChecker.gameObject);
        }
    }
}
