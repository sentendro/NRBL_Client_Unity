using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHelper : MonoBehaviour, OKCancelListener {
    //입력을 해야하는 GameObject변수 앞에는 go가 붙도록 한다
    public GameObject goSelected;
    public GameObject goOKOnlyDlg, goOKCancelDlg;
    public GameObject goUnitPalette;
    public GameObject selectedTile;

    private UnitPalette unitPalette;
    private OKOnlyDialog okOnlyDlg;
    private OKCancelDialog okCancelDlg;

	// Use this for initialization
	void Start () {
        unitPalette = goUnitPalette.GetComponent<UnitPalette>();
        okOnlyDlg = goOKOnlyDlg.GetComponent<OKOnlyDialog>();
        okCancelDlg = goOKCancelDlg.GetComponent<OKCancelDialog>();
        
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && IsDialogActive() == false)
        {
            OnClick();
        }
	}

    public bool OnClick()
    {
        //AutoMapper에서 0 ~ 2부분만 유닛을 설치 가능한 'Placable' 레이어에 할당해놓았다
        int layerMask = 1 << LayerMask.NameToLayer("Placable");
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //레이캐스트를 처리하기 위해선 BoxCollider2D가 필요하다
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 5f, layerMask);

        if (hit.collider != null)
        {
            //애초에 팔레트로 선택된 유닛이 없으면 생산자체가 불가능
            if (unitPalette.selectedUnit == null)
            {
                //다이얼로그 처리 : '팔레트에서 원하는 유닛을 선택해주세요'
                //이 다이얼로그 처리 이후 발생할 이벤트는 없기에 null을 넣어준다
                okOnlyDlg.View("팔레트에서 원하는 유닛을 선택해주세요", null);
                return false;
            }
            else
            {
                //hit.collider = 타일
                selectedTile = hit.collider.gameObject;
                //선택화면 공개
                goSelected.SetActive(true);
                goSelected.transform.localPosition = selectedTile.transform.localPosition;

                okCancelDlg.View("해당 위치에 선택한 유닛을 생산하시겠습니까?", this);
                return true;
            }
        }
        else
        {
            return false;
        }

    }

    public void CreateUnit()
    {
        //유닛팔레트에서 선택된 유닛을 그대로 복사생성한다
        GameObject createdUnit = Instantiate(unitPalette.selectedUnit, transform);
        //유닛 클래스를 타일에 저장
        selectedTile.GetComponent<Tiles>().setOn(createdUnit.GetComponent<AUnit>());
        
        //위치를 타일과 일치시켜준다
        //createdUnit.transform.parent = selectedTile.transform;
        //위로 변경할 시 타일의 하위로 두면서 위치를 유지할 수 있음
        createdUnit.transform.localPosition = selectedTile.transform.localPosition;
        //선택된 유닛을 취소한다
        unitPalette.Release();
        goSelected.SetActive(false);
    }

    public bool IsDialogActive()
    {
        return goOKCancelDlg != null && goOKCancelDlg.activeInHierarchy == true
            && goOKOnlyDlg != null && goOKOnlyDlg.activeInHierarchy == true;
    }
    
    //선택한 유닛을 생산할것인가?에 대한 예 대답
    public void OnOK()
    {
        CreateUnit();
        okOnlyDlg.View("유닛이 생산되었습니다", null);
    }

    //선택한 유닛을 생산할것인가?에 대한 아니오 대답
    public void OnCancel()
    {
        //선택화면 사라지기
        goSelected.SetActive(false);
        selectedTile = null;
    }
}
