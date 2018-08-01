using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMoveView : MonoBehaviour {
    public GameObject objBtnUp, objBtnLeft, objBtnDown, objBtnRight;
    public GameObject objBtnOk, objBtnCancel;

    public Button btnUp, btnLeft, btnDown, btnRight, btnOk, btnCancel;

	// Use this for initialization
	void Start ()
    {
        Create();
    }

    private void Update()
    {
        //테스트 용
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            InputKey(KeyInput.LEFT);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            InputKey(KeyInput.UP);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            InputKey(KeyInput.RIGHT);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            InputKey(KeyInput.DOWN);
        }
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z))
        {
            InputKey(KeyInput.EXECUTE);
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.X))
        {
            InputKey(KeyInput.ESCAPE);
        }
    }

    public void Create()
    {
        btnUp = objBtnUp.GetComponent<Button>();
        btnLeft = objBtnLeft.GetComponent<Button>();
        btnDown = objBtnDown.GetComponent<Button>();
        btnRight = objBtnRight.GetComponent<Button>();

        btnOk = objBtnOk.GetComponent<Button>();
        btnCancel = objBtnCancel.GetComponent<Button>();

        viewPalletteMaker = objPalletteMakerView.GetComponent<PalletteMakerView>();

        btnUp.onClick.AddListener(() => 
        {
            InputKey(KeyInput.UP);
        });

        btnLeft.onClick.AddListener(() => 
        {
            InputKey(KeyInput.LEFT);
        });

        btnDown.onClick.AddListener(() => 
        {
            InputKey(KeyInput.DOWN);
        });

        btnRight.onClick.AddListener(() => 
        {
            InputKey(KeyInput.RIGHT);
        });

        btnOk.onClick.AddListener(() =>
        {
            InputKey(KeyInput.EXECUTE);
        });

        btnCancel.onClick.AddListener(() =>
        {
            InputKey(KeyInput.ESCAPE);
        });
    }

    public void InputKey(KeyInput key)
    {

    }
}
