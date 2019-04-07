using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddUnitController : MonoBehaviour {
    public GameObject outObjPalletteMakerView, outObjMapSelectedView;

    private PalletteMakerView viewPalletteMaker;
    private MapSelectView viewMapSelect;
    private SelectedStatus selectedStatus;

    public AddUnitController(PalletteMakerView palletteMakerView, MapSelectView mapSelectView, SelectedStatus selectedStatus)
    {
        this.viewPalletteMaker = palletteMakerView;
        this.viewMapSelect = mapSelectView;
        this.selectedStatus = selectedStatus;
    }

    public void InputKey(KeyInput keyInput)
    {
        switch(this.selectedStatus)
        {
            case SelectedStatus.PALLETTE:
                PalletteMakerView.SelectResult result = viewPalletteMaker.UpdateSelectedByKey(keyInput);

                break;
            case SelectedStatus.POSITION:
                break;
            case SelectedStatus.ANOTHERTURN:
                break;
        }
    }

    public enum SelectedStatus {
        PALLETTE, POSITION, ANOTHERTURN
    }

    public enum SelectedResult {
        PALLETTE, POSITION, NOCHANGE, NEXTTURN, ADDUNIT
    }
}
