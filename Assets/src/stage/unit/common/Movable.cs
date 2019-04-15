using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이동 기능
// 공격 기능
public class Movable : MonoBehaviour
{
    public bool outIsEnemy;
    public int outMoveStep;

    public void TurnUpdate()
    {
        if(outIsEnemy == true)
        {
            transform.Translate(0, -1 * outMoveStep, 0);
        }
        else
        {
            transform.Translate(0, outMoveStep, 0);
        }
    }
}
