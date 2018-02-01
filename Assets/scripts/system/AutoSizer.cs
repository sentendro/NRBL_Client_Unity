using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 크기가 1이 되게끔 텍스쳐의 크기를 고려해 GameObject 크기를 조정함.
 * 하지만 Transform을 복사해서 넣어둔 이후에는 
 * 더 이상 AutoSizer를 굳이 스크립트에 추가해둘 필요가 없음
 * 그래서 오브젝트들에는 AutoSizer가 들어있지 않음
 */
public class AutoSizer : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //크기를 그냥 1로하면 텍스쳐크기대로 나온다.
        //텍스쳐크기가 1을 초과하는 경우 그 비율만큼 크기를 줄여주면 된다
        Vector3 size = this.GetComponent<SpriteRenderer>().sprite.bounds.size;
        this.transform.localScale = new Vector3(1 / size.x, 1 / size.y);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
