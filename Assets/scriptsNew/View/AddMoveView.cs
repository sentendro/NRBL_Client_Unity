﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMoveView : MonoBehaviour {
    public GameObject objBtnUp, objBtnLeft, objBtnDown, objBtnRight;
    public GameObject objBtnOk, objBtnCancel;

    public GameObject objPalletteMakerView;

    public Button btnUp, btnLeft, btnDown, btnRight, btnOk, btnCancel;
    public PalletteMakerView viewPalletteMaker;


	// Use this for initialization
	void Start () {
        btnUp = objBtnUp.GetComponent<Button>();
        btnLeft = objBtnLeft.GetComponent<Button>();
        btnDown = objBtnDown.GetComponent<Button>();
        btnRight = objBtnRight.GetComponent<Button>();

        btnOk = objBtnOk.GetComponent<Button>();
        btnCancel = objBtnCancel.GetComponent<Button>();

        viewPalletteMaker = objPalletteMakerView.GetComponent<PalletteMakerView>();

        btnUp.onClick.AddListener(OnClickUp);
        btnLeft.onClick.AddListener(OnClickLeft);
        btnDown.onClick.AddListener(OnClickDown);
        btnRight.onClick.AddListener(OnClickRight);
    }

    public void OnClickUp()
    {
        
    }

    public void OnClickLeft()
    {

    }

    public void OnClickDown()
    {

    }

    public void OnClickRight()
    {

    }
}
