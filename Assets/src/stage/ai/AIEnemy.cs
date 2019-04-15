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

    public bool CheckUnit(Unit unit)
    {
        Debug.Log(gold + "/" + unit.EnemyPrice);
        if(gold < unit.EnemyPrice)
        {
            return false;
        }
        else if(capacity < unit.EnemyFood)
        {
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

    public void AddUnit(Unit unit)
    {
        unit.OnCreate();
        unitList.Add(unit);
    }

    public void CreateUnit(GameObject obj, Vector3 position)
    {
        GameObject newObj = Instantiate(obj, outTfUnitLayer);
        newObj.transform.localPosition = position;
    }

    public bool PushUnit(string key, Vector3 position)
    {
        Unit unit = GetUnit(key);
        if(CheckUnit(unit))
        {
            CreateUnit(unit.gameObject, position);
            AddUnit(unit);
            Buy(unit);
            return true;
        }
        else
        {
            Debug.Log("Push Unit Fail");
            return false;
        }
    }
}
