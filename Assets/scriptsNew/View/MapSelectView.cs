using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectView : MonoBehaviour {
    public GameObject outPallette, outUnits, outTiles, outSelected;

    public GameObject[] palletteUnits;
    public string palletteDir;

    void Start()
    {

    }

    public void Create()
    {
        palletteUnits = Resources.LoadAll<GameObject>(palletteDir);

        for (int i = 0; i < palletteUnits.Length; i++)
        {
            GameObject obj = Instantiate(palletteUnits[i], transform);
            obj.transform.localPosition = new Vector3(i, 0);
        }

        outSelected.transform.localPosition = new Vector3(0, 0);
    }
}
