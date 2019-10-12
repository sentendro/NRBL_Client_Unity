using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Unit
{
    public override void TurnUpdate()
    {
        base.TurnUpdate();

        GetComponent<Movable>().TurnUpdate();
    }
}
