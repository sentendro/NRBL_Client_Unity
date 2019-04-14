using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Unit
{
    public Player outPlayer;
    public int addValue = 3;

    public override void OnCreate()
    {
        base.OnCreate();
        outPlayer.UpdateHouseCapacity(addValue);
    }
}
