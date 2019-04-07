using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectView : MonoBehaviour
{
    public GameObject outSelectedUI;
    public GameObject inSelectedTIle;
    public Vector3 inSelectedPosition;

    // Start is called before the first frame update
    void Start()
    {
        outSelectedUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼클릭
        {
            Vector2 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(vector, Vector2.zero);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);

            for (int i = 0; i < hits.Length; i++)
            {
                Collider2D collider = hits[i].collider;

                if (collider.tag.Equals("placable"))
                {
                    // 타일인 경우
                    float x = collider.transform.localPosition.x;
                    float y = collider.transform.parent.localPosition.y;
                    outSelectedUI.transform.localPosition = new Vector3(x, y);
                    outSelectedUI.SetActive(true);
                    inSelectedTIle = collider.gameObject;
                    inSelectedPosition = new Vector3(x, y);
                }
            }
        }
    }

    public void HideSelectedUI()
    {
        outSelectedUI.SetActive(false);
        inSelectedTIle = null;
    }
}
