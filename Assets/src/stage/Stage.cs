using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private UnitList unitList = new UnitList();
    private NextTurnStatus status = NextTurnStatus.Default;

    public Unit CreateUnit(GameObject obj, Vector3 position)
    {
        Player player = GameResources.Player;
        Unit unit = unitList.CreateUnit(obj, position);

        return unit;
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.RemoveUnit(unit);
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
        unitList.TurnUpdate();
    }

    public enum NextTurnStatus
    {
        Default, Check, Wait, WaitCheck
    }
}
