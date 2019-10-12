using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Unit
{
    //public Player outPlayer;
    //public AIEnemy outAiEnemy;
    public bool outIsEnemy;
    public int outAddValue = 3;

    public override void OnCreate()
    {
        AIEnemy aiEnemy = GameResources.AIEnemy;
        Player player = GameResources.Player;

        base.OnCreate();

        if(outIsEnemy)
        {
            aiEnemy.UpdateHouseCapacity(outAddValue);
        }
        else
        {
            player.UpdateHouseCapacity(outAddValue);
        }
    }
}
