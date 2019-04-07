using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour {
    public GameObject[] outButtons;
    private Button[] buttons;

    public int BUTTON_LEFT = 0, BUTTON_UP = 1, BUTTON_RIGHT = 2, BUTTON_DOWN = 3, BUTTON_EXECUTE = 4, BUTTON_CANCEL = 5;

	// Use this for initialization
	void Start () {
        buttons = new Button[outButtons.Length];
        KeyInput[] inputs = { KeyInput.LEFT, KeyInput.UP, KeyInput.RIGHT, KeyInput.DOWN, KeyInput.EXECUTE, KeyInput.ESCAPE };

		for(int i = 0; i < outButtons.Length; i++)
        {
            buttons[i] = outButtons[i].GetComponent<Button>();
            buttons[i].onClick.AddListener(() =>
            {
                //키입력 처리
                InputKey(inputs[i]);
            });
        }
	}

    public void InputKey(KeyInput key)
    {

    }
}
