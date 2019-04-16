using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveAIEnemy : MonoBehaviour
{
    public AIEnemy outAiEnemy;
    public int maxTurn = 7;

    public void TurnUpdate()
    {
        Debug.Log("OffensiveAIEnemy TurnUpdate");
        if (outAiEnemy.Gold <= 2)
        {
            int buildX = outAiEnemy.FindBlank(8);

            if(buildX >= 0)
            {
                outAiEnemy.PushRandomUnit("Store", 8);
            }
        }

        if(outAiEnemy.Capacity <= 1)
        {
            int buildX = outAiEnemy.FindBlank(8);

            if (buildX >= 0)
            {
                outAiEnemy.PushRandomUnit("House", 8);
            }
        }

        int turn = 0;
        int createX = outAiEnemy.FindBlank(7);
        while (outAiEnemy.PushRandomUnit("Soldier", 7))
        {
            turn++;
            if(turn > maxTurn) // 무한루프 방지 용
            {
                break;
            }
            createX = outAiEnemy.FindBlank(7);
        }

        outAiEnemy.TurnUpdate();
    }
}
