using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPallette : MonoBehaviour {
    public GameObject goSelected;
    public GameObject goOKOnlyDlg, goOKCancelDlg;
    public int startX, startY;
    public GameObject selectedUnit;
    public string PALETTE_DIR = "unit/blue";

	// Use this for initialization
	void Start () {
        PlacePaletteUnits(PALETTE_DIR);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && IsDialogActive())
        {
            OnClick();
        }
    }

    public bool IsDialogActive()
    {
        return goOKCancelDlg != null && goOKCancelDlg.activeInHierarchy == true
            && goOKOnlyDlg != null && goOKOnlyDlg.activeInHierarchy == true;
    }

    public void PlacePaletteUnits(string dir)
    {
        GameObject[] palette = Resources.LoadAll<GameObject>(dir);
        for(int i = 0; i < palette.Length; i++)
        {
            GameObject pu = Instantiate(palette[i], transform);
            pu.transform.localPosition = new Vector3(i + startX, startY);
        }
    }

    public bool OnClick()
    {
        //레이캐스트 확인은 팔레트 유닛들만 하면 된다
        int layerMask = 1 << LayerMask.NameToLayer("Unit");
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //distance는 5정도면 충분히 길것 같아.. 사실 잘은 모름
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);// 20.0f, layerMask);

        Debug.Log(hit.collider);
        if(hit.collider != null)
        {
            //미리 저장해 두었다가 SelectHelper가 타일선택을 확인받고 해당 유닛을 생성해야 할 때
            //이 정보를 가져와준다
            this.selectedUnit = hit.collider.gameObject;
            //selected = 파란색 선택 그림
            //해당 유닛을 선택했다는 걸 눈에 보이게끔 한다
            goSelected.transform.localPosition = this.selectedUnit.transform.localPosition;

            return true;
        }
        else
        {
            return false;
        }
    }
}
