 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageView : MonoBehaviour {
    public GameObject gageHp, gageGold, gageFood;
    private Text gageHpText, gageGoldText, gageFoodText;

	// Use this for initialization
	void Start () {
        gageHpText = gageHp.GetComponent<Text>();
        gageGoldText = gageGold.GetComponent<Text>();
        gageFoodText = gageFood.GetComponent<Text>();
	}

    public void UpdateHpData(int hp)
    {
        gageHpText.text = string.Format("{0}", hp);
    }

    public void UpdateGoldData(int gold)
    {
        gageGoldText.text = string.Format("{0}", gold);
    }

    public void UpdateFoodData(int food)
    {
        gageFoodText.text = string.Format("{0}", food);
    }
}
