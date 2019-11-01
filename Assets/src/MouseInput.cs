using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
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
                StageAction stageAction = Data.stageAction;

                string tag = collider.tag;

                //Logger.Log("MouseInput Tag", tag, stageAction);

                if (tag.Equals("pallette"))
                {
                    stageAction.ActionPallette(collider);
                }
                else if (tag.Equals("placable"))
                {
                    stageAction.ActionUnitCreate(collider);
                }
                else if(tag.Equals("created"))
                {

                }
            }
        }
    }
}
