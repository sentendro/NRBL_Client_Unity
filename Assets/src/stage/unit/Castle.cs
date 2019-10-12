using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Unit
{
    public GameObject outObjSlave;
    //public Stage outStage;
    //public AIEnemy outAIEnemy;
    public bool outIsEnemy;
    //public Transform outTfUnitLayer;
    public int unitCreateTurn = 0;

    public override void TurnUpdate()
    {
        Transform tfUnitLayer = GameResources.TfUnitLayer;
        AIEnemy aiEnemy = GameResources.AIEnemy;
        Stage stage = GameResources.Stage;

        base.TurnUpdate();

        if(unitCreateTurn >= 0)
        {
            if(outIsEnemy)
            {
                GameObject newSlave = Instantiate(outObjSlave, tfUnitLayer);
                newSlave.transform.position = new Vector3(transform.position.x, transform.position.y); // 이미 생성된 Castle보다 Unit이 나중에 생성되어 TurnUpdate 영향을 받는다
                newSlave.SetActive(true);

                aiEnemy.AddUnit(newSlave.GetComponent<Unit>());
            }
            else
            {
                stage.CreateUnit(outObjSlave, new Vector3(transform.position.x, transform.position.y));
            }

            unitCreateTurn = 0;
        }
        else
        {
            unitCreateTurn++;
        }
    }
}
