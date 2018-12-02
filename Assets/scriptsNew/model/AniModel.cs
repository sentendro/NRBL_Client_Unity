using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AniModel
{
    public const int TYPE_MOVE = 1, TYPE_ATTACK = 2, TYPE_UPGRADE = 3, TYPE_DEATH = 4;
    public int Type { get; set; }
    public UnitModel Subject { get; set; }//subject to object(attack)
    public UnitModel Object { get; set; }

    public AniModel(int type, UnitModel sub)
    {
        this.Type = type;
        this.Subject = sub;
    }

    public AniModel(int type, UnitModel sub, UnitModel obj)
    {
        this.Type = type;
        this.Subject = sub;
        this.Object = obj;
    }
}