using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour{
    //해당 타일의 타일상 좌표
    public Vector2 selfPosition { get; set; }
    //해당 타일에 존재하는 유닛
    public AUnit on;

    private void Awake()
    {
        on = null;
    }

    public void setOn(AUnit unit)
    {
        on = unit;
    }
}
