using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : Unit
{
    public override void TurnUpdate()
    {
        base.TurnUpdate();

        GetComponent<Movable>().TurnUpdate();
    }
}
