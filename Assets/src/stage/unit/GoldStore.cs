using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldStore : Unit
{
    public Player outPlayer;
    public AIEnemy outAiEnemy;
    public bool outIsEnemy;
    public int outAddValue = 1;

    private void Start()
    {
        if (outIsEnemy == true && outAiEnemy == null)
        {
            throw new NoAssignedException(this.GetType() + ".outAiEnemy");
        }
    }

    public override void TurnUpdate()
    {
        base.TurnUpdate();

        if(outIsEnemy)
        {
            outAiEnemy.UpdateGoldStoreGold(outAddValue);
        }
        else
        {
            outPlayer.UpdateGoldStoreGold(outAddValue);
        }
    }
}
