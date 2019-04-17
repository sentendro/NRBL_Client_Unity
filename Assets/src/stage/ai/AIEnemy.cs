using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public Transform outTfEnemyPallette;
    public Transform outTfUnitLayer;
    private List<Unit> unitList = new List<Unit>();
    public int gold, hp, capacity;

    public int Gold
    {
        get { return gold; }
    }

    public int Hp
    {
        get { return hp; }
    }

    public int Capacity
    {
        get { return capacity; }
    }

    public Unit GetUnit(string key)
    {
        return outTfEnemyPallette.Find(key).GetComponent<Unit>();
    }

    public void TurnUpdate()
    {
        for (int i = 0; i < unitList.Count; i++)
        {
            unitList[i].TurnUpdate();
        }
    }

    public bool CheckUnit(Unit unit)
    {
        //Debug.Log(gold + "/" + unit.EnemyPrice);
        if(gold < unit.EnemyPrice)
        {
            Debug.Log("Push Unit Fail Gold" + gold + "/" + unit.EnemyPrice);
            return false;
        }
        else if(capacity < unit.EnemyFood)
        {
            Debug.Log("Push Unit Fail Capacity" + capacity + "/" + unit.EnemyFood);
            return false;
        }
        return true;
    }

    public void UpdateGoldStoreGold(int value)
    {
        gold += value;
    }

    public void UpdateHouseCapacity(int value)
    {
        capacity += value;
    }

    public void Buy(Unit unit)
    {
        gold -= unit.EnemyPrice;
        capacity -= unit.EnemyFood;
    }

    public void UpdateMovableDamage(int damage)
    {
        hp -= damage;
    }

    public void AddUnit(Unit unit)
    {
        unit.OnCreate();
        unitList.Add(unit);
    }

    public Unit CreateUnit(GameObject obj, Vector3 position)
    {
        GameObject newObj = Instantiate(obj, outTfUnitLayer);
        newObj.transform.localPosition = position;
        return newObj.GetComponent<Unit>();
    }

    public void RemoveUnit(Unit unit)
    {
        unit.OnDie();
        unitList.Remove(unit);
        Destroy(unit.gameObject);
    }

    public bool PushRandomUnit(string key, int y)
    {
        Unit unit = GetUnit(key);
        if(CheckUnit(unit))
        {
            int x = FindBlank(y);
            Debug.Log(string.Format("aienemy x:{0} y:{1}", x, y));
            if(x >= 0)
            {
                Unit newUnit = CreateUnit(unit.gameObject, new Vector3(x, y));
                AddUnit(newUnit);
                Buy(newUnit);
                return true;
            }
            else
            {
                return false; // 자리가 없음
            }
        }
        else
        {
            return false;
        }
    }

    public int FindBlank(int y)
    {
        bool[] xArray = new bool[7];

        for(int i = 0; i < xArray.Length; i++)
        {
            xArray[i] = false;
        }

        foreach (Unit unit in unitList)
        {
            Vector3 pos = unit.transform.localPosition;
            if ((int)pos.y == y)
            {
                xArray[(int)pos.x] = true;
            }
        }

        int x = -1; // 자리가 없을때는 -1을 반환한다
        for(int i = 0; i < xArray.Length; i++)
        {
            if(xArray[i] == false)
            {
                x = i;
                break;
            }
        }

        return x;
    }
}
