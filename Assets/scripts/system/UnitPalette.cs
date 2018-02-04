using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPalette : MonoBehaviour {
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
        if (Input.GetMouseButtonDown(0) && IsDialogActive() == false)
        {
            OnClick();
        }
    }

    public void Release()
    {
        selectedUnit = null;
        goSelected.SetActive(false);
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
        //레이캐스트를 처리하기 위해선 BoxCollider2D가 필요하다
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 5.0f, layerMask);
        
        
        if(hit.collider != null)
        {
            //미리 저장해 두었다가 SelectHelper가 타일선택을 확인받고 해당 유닛을 생성해야 할 때
            //이 정보를 가져와준다
            this.selectedUnit = hit.collider.gameObject;
            //selected = 파란색 선택 그림
            //해당 유닛을 선택했다는 걸 눈에 보이게끔 한다
            goSelected.SetActive(true);
            goSelected.transform.localPosition = this.selectedUnit.transform.localPosition;

            return true;
        }
        else
        {
            return false;
        }
    }
}
