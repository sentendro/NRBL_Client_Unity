using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldStore : Unit
{
    public Player outPlayer;
    public int addValue = 1;

    private void Start()
    {
        
    }

    public override void TurnUpdate()
    {
        base.TurnUpdate();
        outPlayer.UpdateGoldStoreGold(addValue);
    }
}
