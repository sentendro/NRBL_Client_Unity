using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletteMakerView : MonoBehaviour {
    public string fileDir;
    public GameObject[] palletteUnits;
    public GameObject outSelected;

	// Use this for initialization
	void Start () {
        palletteUnits = Resources.LoadAll<GameObject>(fileDir);

        for(int i = 0; i < palletteUnits.Length; i++)
        {
            GameObject obj = Instantiate(palletteUnits[i], transform);
            obj.transform.localPosition = new Vector3(i, 0);
        }

        outSelected.transform.localPosition = new Vector3(0, 0);


    }

    public void moveLeft()
    {

    }

    public void moveRight()
    {

    }
}
