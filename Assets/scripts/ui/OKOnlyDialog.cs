using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface OKOnlyListener
{
    void OnOKOnly();
}

public class OKOnlyDialog : MonoBehaviour {
    public GameObject goDlgText;
    private Text dlgText;
    private OKOnlyListener listener;
	// Use this for initialization
	void Start() {
        dlgText = goDlgText.GetComponent<Text>();
        //처음에 꺼져있는채로 시작한다
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void View(string text, OKOnlyListener listener)
    {
        gameObject.SetActive(true);
        dlgText.text = text;
        this.listener = listener;
    }

    public void OnOK()
    {
        //만약 이 다이얼로그를 리스너에서 바로 실행시킬 때
        //미리 꺼놓치 않으면 다이얼로그 세팅이 완료된 후 꺼지게 되는
        //불상사가 발생할 수 있다. 반드시 이 순서를 유지 시켜야 한다
        this.gameObject.SetActive(false);
        if(this.listener != null)
            this.listener.OnOKOnly();
    }
}
