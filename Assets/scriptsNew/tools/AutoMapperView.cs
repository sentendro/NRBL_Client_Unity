using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

public class AutoMapperView : MonoBehaviour {
    public GameObject[] tiles;
    public string[] xmlData;
    public float xDif = -3.0f, yDif = -4.0f;

	// Use this for initialization
	void Start () {
        tiles = Resources.LoadAll<GameObject>("tile");
        ParseAndView(Resources.Load<TextAsset>("data/map").ToString());
	}

    public void ParseAndView(string xml)
    {
        xmlData = xml.Split('\n');
        for (int i = 0; i < xmlData.Length; i++)
        {
            string rowData = xmlData[i];

            //row별로 묶어서 맵을 관리
            GameObject rowObj = new GameObject();
            rowObj.transform.parent = transform;
            rowObj.transform.localPosition = new Vector3(xDif, i + yDif, 0);
            rowObj.name = "row" + i;

            for(int j = 0; j < rowData.Length; j++)
            {
                int tileIdx = rowData[j] - '0';
                GameObject tileObj = Instantiate(tiles[tileIdx], rowObj.transform);
                tileObj.transform.localPosition = new Vector3(j, 0, 0);
            }
        }
    }
}
