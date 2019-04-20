using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletteView : MonoBehaviour
{
    public GameObject outSelectedUI;
    public GameObject inSelectedUnit;

    private void Start()
    {
        outSelectedUI.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) // 마우스 왼클릭
        {
            Vector2 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(vector, Vector2.zero);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
            
            for(int i = 0; i < hits.Length; i++)
            {
                Collider2D collider = hits[i].collider;

                if(collider.tag.Equals("pallette"))
                {
                    // 팔레트 유닛인 경우
                    outSelectedUI.transform.localPosition = collider.transform.localPosition;
                    outSelectedUI.SetActive(true);
                    inSelectedUnit = collider.gameObject;
                }
            }
        }
    }

    public void HideSelectedUI()
    {
        outSelectedUI.SetActive(false);
        inSelectedUnit = null;
    }

    public Unit UnitPlacerSelectedUnit()
    {
        if(inSelectedUnit == null)
        {
            return null;
        }
        else
        {
            return inSelectedUnit.GetComponent<Unit>();
        }
    }
}
