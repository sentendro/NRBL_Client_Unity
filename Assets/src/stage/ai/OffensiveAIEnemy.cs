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

        Debug.Log(string.Format("offensive gold : {0} capacity : {1}", aiEnemy.Gold, aiEnemy.Capacity));

        if (aiEnemy.Gold <= 2)
        {
            int buildX = aiEnemy.FindBlank(8);

            if(buildX >= 0)
            {
                aiEnemy.PushRandomUnit("Store", 8);
            }
        }

        if(aiEnemy.Capacity <= 1)
        {
            int buildX = aiEnemy.FindBlank(8);

            if (buildX >= 0)
            {
                aiEnemy.PushRandomUnit("House", 8);
            }
        }

        int turn = 0;
        while (aiEnemy.PushRandomUnit("Soldier", 7))
        {
            turn++;
            Debug.Log("offensive turn" + turn);
            if(turn > maxTurn) // 무한루프 방지 용
            {
                break;
            }
        }

        aiEnemy.TurnUpdate();
    }
}
