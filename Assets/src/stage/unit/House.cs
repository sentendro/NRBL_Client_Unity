using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Unit
{
    public Player outPlayer;
    public AIEnemy outAiEnemy;
    public bool outIsEnemy;
    public int outAddValue = 3;

    public override void OnCreate()
    {
        base.OnCreate();

        if(outIsEnemy)
        {

        }
        else
        {
            outPlayer.UpdateHouseCapacity(outAddValue);
        }
    }
}
