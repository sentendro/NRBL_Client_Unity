﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnChecker : MonoBehaviour
{
    public GameObject outPrefab;
    public Text inText;
    public int turn;
    public bool isEnemy;
    public bool isUpgraded = false;

    public void OnUnitCreate()
    {
        if (isEnemy == false)
        {
            // 텍스트 복사
            GameObject obj = Instantiate(outPrefab, GameObject.Find("Canvas").transform);
            obj.SetActive(true);
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
                inText.color = Color.cyan;
            }

            if(isEnemy == false)
            {
                inText.text = turn.ToString();
            }
        }
    }
}
