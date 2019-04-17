using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Dialog outDialog;
    private List<Unit> unitList = new List<Unit>();
    private NextTurnStatus status = NextTurnStatus.Default;
    public OffensiveAIEnemy outOffAiEnemy;
    public Transform outTfUnitLayer;

    private void Start()
    {
        if(outTfUnitLayer == null)
        {
            throw new NoAssignedException(this.GetType() + ".outTfUnitLayer");
        }
    }

    public Unit CreateUnit(GameObject obj, Vector3 position)
    {
        GameObject newObj = Instantiate(obj, outTfUnitLayer);
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
        switch(status)
        {
            case NextTurnStatus.Default:
                outDialog.ShowStageNextTurn();
                status = NextTurnStatus.Check;
                break;
            case NextTurnStatus.Check:
                outDialog.Hide();
                TurnUpdate();
                if (outOffAiEnemy != null)
                {
                    outOffAiEnemy.TurnUpdate();
                    status = NextTurnStatus.Default;
                }
                else
                {
                    status = NextTurnStatus.Wait;
                }
                break;
            case NextTurnStatus.Wait:
                status = NextTurnStatus.WaitCheck;
                outDialog.ShowStageWait();
                break;
            case NextTurnStatus.WaitCheck:
                status = NextTurnStatus.Default;
                outDialog.Hide();
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
