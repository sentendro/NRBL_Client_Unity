using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이동 기능
// 공격 기능
public class Movable : MonoBehaviour
{
    public bool outIsEnemy;
    public int outMoveStep;
    public int damage;
    //public Player outPlayer;
    //public AIEnemy outAiEnemy;
    //public Stage outStage;

    public void TurnUpdate()
    {
        Player player = GameResources.Player;
        AIEnemy aiEnemy = GameResources.AIEnemy;
        Stage stage = GameResources.Stage;

        if(outIsEnemy == true)
        {
            transform.Translate(0, -1 * outMoveStep, 0);
        }
        else
        {
            transform.Translate(0, outMoveStep, 0);
        }

        // 상대 플레이어에게 데미지
        if(transform.localPosition.y <= 1 && outIsEnemy == true)
        {
            player.UpdateMovableDamage(damage);
            aiEnemy.RemoveUnit(GetComponent<Unit>());
        }
        else if(transform.localPosition.y > 8 && outIsEnemy == false)
        {
            aiEnemy.UpdateMovableDamage(damage);
            stage.RemoveUnit(GetComponent<Unit>());
        }
    }
}
