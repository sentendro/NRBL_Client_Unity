using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text outText;

    public void Show(string text)
    {
        gameObject.SetActive(true);
        outText.text = text;
    }

    public void Hide()
    {
        Debug.Log("Hide");
        gameObject.SetActive(false);
    }

    public void ShowUnitPlacerCheck()
    {
        Show("해당 장소에 유닛을 설치하겠습니까?");
    }

    public void ShowUnitPlacerNoSelectUnit()
    {
        Show("유닛을 선택해주세요");
    }

    public void ShowUnitPlacerNoSelectTile()
    {
        Show("위치를 선택해주세요");
    }

    public void ShowStageNextTurn()
    {
        Show("다음 턴으로 넘기시겠습니까?\n(넘기길 원하면 파란 버튼을 터치해주세요)");
    }

    public void ShowStageWait()
    {
        Show("상대방의 턴 종료를 기다려주세요");
    }

    public void ShowPlayerNotEnoughGold()
    {
        Show("골드가 충분하지 않습니다");
    }

    public void ShowPlayerNotEnoughFood()
    {
        Show("식량이 충분하지 않습니다");
    }
}
