using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveAIEnemy : MonoBehaviour
{
    public AIEnemy outAiEnemy;
    public int randomX = 0;
    public int maxTurn = 7;

    public void TurnUpdate()
    {
        Debug.Log("OffensiveAIEnemy TurnUpdate");
        if (outAiEnemy.Gold <= 2)
        {
            outAiEnemy.PushUnit("Store", new Vector3(randomX++, 8));
            if (randomX >= 7)
            {
                randomX = 0;
            }
        }

        if(outAiEnemy.Capacity == 1)
        {
            outAiEnemy.PushUnit("House", new Vector3(randomX++, 8));
            if(randomX >= 7)
            {
                randomX = 0;
            }
        }

        int turn = 0;
        while (outAiEnemy.PushUnit("Soldier", new Vector3(randomX++, 7)))
        {
            if(randomX >= 7)
            {
                randomX = 0;
            }

            turn++;
            if(turn > maxTurn) // 무한루프 방지 용
            {
                break;
            }
        }
    }
}
