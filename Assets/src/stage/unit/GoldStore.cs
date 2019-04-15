using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldStore : Unit
{
    public Player outPlayer;
    public AIEnemy outAiEnemy;
    public bool outIsEnemy;
    public int outAddValue = 1;

    public override void TurnUpdate()
    {
        base.TurnUpdate();

        if(outIsEnemy)
        {

        }
        else
        {
            outPlayer.UpdateGoldStoreGold(outAddValue);
        }
    }
}
