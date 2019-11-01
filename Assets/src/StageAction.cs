using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAction : MonoBehaviour
{
    //public GameObject outSelectedUI;
    public GameObject inSelectedUnit, inSelectedTIle;
    public Vector3 inSelectedPosition;

    /// <summary>
    /// 팔레트 유닛 왼클릭
    /// </summary>
    /// <param name="collider"></param>
    public void ActionPallette(Collider2D collider)
    {
        GameObject selectedUI = Data.selectedUI;

        selectedUI.transform.position = collider.transform.position;
        Logger.Log("StageAction postion", selectedUI.transform.position, collider.transform.position);
        selectedUI.SetActive(true);
        inSelectedUnit = collider.gameObject;
    }

    /// <summary>
    /// 유닛 생성할 맵 선택
    /// </summary>
    /// <param name="collider"></param>
    public void ActionUnitCreate(Collider2D collider)
    {
        GameObject selectedUI = Data.selectedUI;

        // 타일인 경우
        float x = collider.transform.position.x;
        float y = collider.transform.parent.position.y;
        selectedUI.transform.position = new Vector3(x, y);
        selectedUI.SetActive(true);
        inSelectedTIle = collider.gameObject;
        inSelectedPosition = new Vector3(x, y);
    }
}
