using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {
    public static GameObject selectedUI;
    public static StageAction stageAction;

    public GameObject outSelectedUI;
    public StageAction outStageAction;

    private void Awake()
    {
        selectedUI = outSelectedUI;
        stageAction = outStageAction;
    }

}
