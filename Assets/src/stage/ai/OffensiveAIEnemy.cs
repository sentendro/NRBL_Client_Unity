using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveAIEnemy : MonoBehaviour
{
    //public AIEnemy outAiEnemy;
    public int maxTurn = 7;

    public void TurnUpdate()
    {
        AIEnemy aiEnemy = GameResources.AIEnemy;

        Logger.Log("OffensiveAIEnemy", "gold", aiEnemy.Gold, "capacity", aiEnemy.Capacity);

        if (aiEnemy.Gold <= 2)
        {
            int buildX = aiEnemy.FindBlank(8);

            if(buildX >= 0)
            {
                aiEnemy.PushRandomUnit("1Store", 8);
            }
        }

        if(aiEnemy.Capacity <= 1)
        {
            int buildX = aiEnemy.FindBlank(8);

            if (buildX >= 0)
            {
                aiEnemy.PushRandomUnit("3House", 8);
            }
        }

        int turn = 0;
        while (aiEnemy.PushRandomUnit("2Soldier", 7))
        {
            turn++;
            Logger.Log("OffensiveAiEnemy", "turn", turn);
            if(turn > maxTurn) // 무한루프 방지 용
            {
                break;
            }
        }

        aiEnemy.TurnUpdate();
    }
}
