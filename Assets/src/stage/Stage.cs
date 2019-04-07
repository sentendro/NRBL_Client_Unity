using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Dialog outDialog;
    private List<Unit> unitList = new List<Unit>();
    private NextTurnStatus status = NextTurnStatus.Default;

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
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
                status = NextTurnStatus.Wait;
                outDialog.Hide();
                TurnUpdate();
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
