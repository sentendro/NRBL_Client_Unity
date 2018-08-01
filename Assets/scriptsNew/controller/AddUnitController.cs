using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddUnitController : MonoBehaviour {
    public GameObject outObjPalletteMakerView, outObjMapSelectedView;

    private PalletteMakerView viewPalletteMaker;
    private MapSelectView viewMapSelect;
    private SelectedStatus selectedStatus;





    public enum SelectedStatus {
        PALLETTE, POSITION
    }

    public enum SelectedResult {
        PALLETTE, POSITION, NOCHANGE, NEXTTURN
    }
}
