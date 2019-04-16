using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Unit
{
    public Player outPlayer;
    public AIEnemy outAiEnemy;
    public bool outIsEnemy;
    public int outAddValue = 3;

    private void Start()
    {
        if (outIsEnemy == true && outAiEnemy == null)
        {
            throw new NoAssignedException(this.GetType() + ".outAiEnemy");
        }
    }

    public override void OnCreate()
    {
        base.OnCreate();

        if(outIsEnemy)
        {
            outAiEnemy.UpdateHouseCapacity(outAddValue);
        }
        else
        {
            outPlayer.UpdateHouseCapacity(outAddValue);
        }
    }
}
