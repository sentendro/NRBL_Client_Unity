using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitList : MonoBehaviour
{
    private List<Unit> list = new List<Unit>();

    public Unit CreateUnit(GameObject objUnit, Vector3 position)
    {
        Transform tfUnitLayer = GameResources.TfUnitLayer;

        GameObject newObj = Instantiate(objUnit, tfUnitLayer);
        newObj.transform.localPosition = position;
        newObj.tag = "created";

        Unit unit = newObj.GetComponent<Unit>();

        unit.OnCreate();
        list.Add(unit);

        return unit;
    }

    public void RemoveUnit(Unit unit)
    {
        unit.OnDie();
        list.Remove(unit);
        Destroy(unit.gameObject);
    }

    public void TurnUpdate()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].TurnUpdate();
        }
    }
}
