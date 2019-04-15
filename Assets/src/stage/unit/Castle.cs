using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Unit
{
    public GameObject outObjSlave;
    public Stage outStage;
    public AIEnemy outAIEnemy;
    public bool outIsEnemy;
    public Transform outTfUnitLayer;
    public int unitCreateTurn = 0;

    public override void TurnUpdate()
    {
        base.TurnUpdate();

        if(unitCreateTurn >= 0)
        {
            GameObject newSlave = Instantiate(outObjSlave, outTfUnitLayer);
            newSlave.transform.position = new Vector3(transform.position.x, transform.position.y); // 이미 생성된 Castle보다 Unit이 나중에 생성되어 TurnUpdate 영향을 받는다
            newSlave.SetActive(true);

            if(outIsEnemy)
            {
                outAIEnemy.AddUnit(newSlave.GetComponent<Unit>());
            }
            else
            {
                outStage.AddUnit(newSlave.GetComponent<Unit>());
            }

            unitCreateTurn = 0;
        }
        else
        {
            unitCreateTurn++;
        }
    }
}
