using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Unit
{
    public override void TurnUpdate()
    {
        base.TurnUpdate();

        transform.Translate(0, 1, 0);
    }
}
