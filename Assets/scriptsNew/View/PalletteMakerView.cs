using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletteMakerView : MonoBehaviour {
    public string fileDir;
    public GameObject[] palletteUnits;
    public GameObject outSelected;
    public int currentIndex;

	// Use this for initialization
	void Start ()
    {
        Create();
    }

    public void Create()
    {
        palletteUnits = Resources.LoadAll<GameObject>(fileDir);

        for (int i = 0; i < palletteUnits.Length; i++)
        {
            GameObject obj = Instantiate(palletteUnits[i], transform);
            obj.transform.localPosition = new Vector3(i, 0);
        }

        outSelected.transform.localPosition = new Vector3(0, 0);
        currentIndex = 0;
    }

    public SelectResult UpdateSelectedByKey(KeyInput key)
    {
        if(key == KeyInput.EXECUTE)
        {
            //위치 선택
            UnitView viewUnit = palletteUnits[currentIndex].GetComponent<UnitView>();
            return new SelectResult(AddUnitController.SelectedResult.POSITION, viewUnit);
        }
        else if(key == KeyInput.ESCAPE)
        {
            //다음턴으로 넘기기
            return new SelectResult(AddUnitController.SelectedResult.NEXTTURN);
        }
        else if(key == KeyInput.LEFT)
        {
            if(currentIndex - 1 >= 0)
            {
                currentIndex--;
                outSelected.transform.localPosition = new Vector3(currentIndex, 0);
            }
        }
        else if(key == KeyInput.RIGHT)
        {
            if(currentIndex + 1 < palletteUnits.Length)
            {
                currentIndex++;
                outSelected.transform.localPosition = new Vector3(currentIndex, 0);
            }
        }

        return new SelectResult(AddUnitController.SelectedResult.NOCHANGE);
    }

    public class SelectResult
    {
        public UnitView palletteUnit;
        public AddUnitController.SelectedResult result;
        public SelectResult(AddUnitController.SelectedResult result)
        {
            this.result = result;
        }

        public SelectResult(AddUnitController.SelectedResult result, UnitView palletteUnit)
        {
            this.result = result;
            this.palletteUnit = palletteUnit;
        }
    }
}
