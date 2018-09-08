using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletteMakerView : MonoBehaviour {
    public string fileDir;
    public GameObject[] palletteUnits;
    public GameObject outSelected;
    public Transform tfSelected;

    public int status = 1;
    private const int STATUS_1_POS_Y = 0, STATUS_1_POS_MIN_X = 0, STATUS_1_POS_MAX_X = 5;
    private const int STATUS_2_POS_MIN_Y = 2, STATUS_2_POS_MAX_Y = 3, STATUS_2_POS_MIN_X = 0, STATUS_2_POS_MAX_X = 6;
	// Use this for initialization
	void Start () {
        palletteUnits = Resources.LoadAll<GameObject>(fileDir);
        tfSelected = outSelected.transform;

        for(int i = 0; i < palletteUnits.Length; i++)
        {
            GameObject obj = Instantiate(palletteUnits[i], transform);
            obj.transform.localPosition = new Vector3(i, 0);
        }

        tfSelected.localPosition = new Vector3(0, 0);
    }

    private void AddMoveSelectedOnly(int x, int y)
    {
        Vector3 pos = tfSelected.localPosition;
        pos.x += x;
        pos.y += y;
        tfSelected.localPosition = pos;
    }

    public bool AddMoveSelected(int x, int y)
    {
        Vector3 pos = tfSelected.localPosition;
        pos.x += x;
        pos.y += y;

        if(status == 1)
        {
            if(pos.y == STATUS_1_POS_Y && pos.x >= STATUS_1_POS_MIN_X && pos.x <= STATUS_1_POS_MAX_X)
            {
                tfSelected.localPosition = pos;
            }
            else
            {
                return false;
            }
        }
        else if(status == 2)
        {
            if (pos.y >= STATUS_2_POS_MIN_Y && pos.y <= STATUS_2_POS_MAX_Y && pos.x >= STATUS_2_POS_MIN_X && pos.x <= STATUS_2_POS_MAX_X)
            {
                tfSelected.localPosition = pos;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    public bool AddStatus(int add)
    {
        int changedValue = this.status + add;
        if(changedValue == 1)
        {
            this.status = changedValue;
            tfSelected.localPosition = new Vector3(STATUS_1_POS_MIN_X, STATUS_1_POS_Y);
            return true;
        }
        else if(changedValue == 2)
        {
            this.status = changedValue;
            tfSelected.localPosition = new Vector3(STATUS_1_POS_MIN_X, STATUS_2_POS_MIN_Y);
            return true;
        }
        else
        {
            return false;
        }
    }
}
