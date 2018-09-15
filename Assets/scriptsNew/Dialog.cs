using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {
    public Text cmpText;

	// Use this for initialization
	void Awake () {
        cmpText = transform.GetChild(0).GetComponent<Text>();
	}

    public void View(string text)
    {
        gameObject.SetActive(true);
        cmpText.text = text;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
