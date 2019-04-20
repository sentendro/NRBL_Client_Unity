using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private List<Unit> unitList = new List<Unit>();
    private NextTurnStatus status = NextTurnStatus.Default;
    //public Dialog outDialog;
    //public OffensiveAIEnemy outOffAiEnemy;
    //public Transform outTfUnitLayer;

    public Unit CreateUnit(GameObject obj, Vector3 position)
    {
        Transform tfUnitLayer = GameResources.TfUnitLayer;

        GameObject newObj = Instantiate(obj, tfUnitLayer);
        newObj.transform.localPosition = position;
        newObj.tag = "created";
        return newObj.GetComponent<Unit>();
    }

    public void AddUnit(Unit unit)
    {
        unit.OnCreate();
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        unit.OnDie();
        unitList.Remove(unit);
        Destroy(unit.gameObject);
    }

    public void OnNextTurn()
    {
        Dialog dialog = GameResources.Dialog;
        OffensiveAIEnemy offAiEnemy = GameResources.OffensiveAIEnemy;

        switch(status)
        {
            case NextTurnStatus.Default:
                dialog.ShowStageNextTurn();
                status = NextTurnStatus.Check;
                break;
            case NextTurnStatus.Check:
                dialog.Hide();
                TurnUpdate();
                if (offAiEnemy != null)
                {
                    offAiEnemy.TurnUpdate();
                    status = NextTurnStatus.Default;
                }
                else
                {
                    status = NextTurnStatus.Wait;
                }
                break;
            case NextTurnStatus.Wait:
                status = NextTurnStatus.WaitCheck;
                dialog.ShowStageWait();
                break;
            case NextTurnStatus.WaitCheck:
                status = NextTurnStatus.Default;
                dialog.Hide();
                break;
        }
    }

    public void TurnUpdate()
    {
        for(int i = 0; i < unitList.Count; i++)
        {
            unitList[i].TurnUpdate();
        }
    }

    public enum NextTurnStatus
    {
        Default, Check, Wait, WaitCheck
    }
}
