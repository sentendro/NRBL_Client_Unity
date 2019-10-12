using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnChecker : MonoBehaviour
{
    //public GameObject outPrefab;
    public Text inText;
    public int turn;
    public bool isEnemy;
    public bool isUpgraded = false;

    public void OnUnitCreate()
    {
        Transform tfTurnCheckerText = GameResources.TfTurnCheckerText;
        GameObject objPrefab = GameResources.ObjTurnCheckerTextPrefab;

        if (isEnemy == false)
        {
            // 텍스트 복사
            GameObject obj = Instantiate(objPrefab, tfTurnCheckerText);
            obj.SetActive(true);
            Logger.Log("TurnChecker", transform.position, transform.localPosition);
            //이상하게 찍힘
            Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
            position.y += 15;
            obj.transform.position = position;

            inText = obj.GetComponent<Text>();
            inText.text = turn.ToString();
        }
    }

    public void TurnUpdate()
    {
        if(turn > 0)
        {
            turn--;
            if (turn == 0)
            {
                isUpgraded = true;
                if (isEnemy == false)
                {
                    inText.color = Color.cyan;
                }
            }

            if(isEnemy == false)
            {
                inText.text = turn.ToString();
            }
        }
    }
}
