using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSizer : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Vector3 size = this.GetComponent<SpriteRenderer>().sprite.bounds.size;
        this.transform.localScale = new Vector3(1 / size.x, 1 / size.y);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
