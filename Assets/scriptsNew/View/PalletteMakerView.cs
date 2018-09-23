using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletteMakerView : MonoBehaviour
{
    public const string UNITDATA_DIR = "data/units";
    private const int STATUS_1_POS_Y = 0, STATUS_1_POS_MIN_X = 0, STATUS_1_POS_MAX_X = 5;
    private const int STATUS_2_POS_MIN_Y = 2, STATUS_2_POS_MAX_Y = 3, STATUS_2_POS_MIN_X = 0, STATUS_2_POS_MAX_X = 6;

    public const int STATUS_TURN_END = 0, STATUS_PALLETTE_SELECT = 1, STATUS_MAP_SELECT = 2, STATUS_UNIT = 3;

    public GameObject outSelected;
    public GameObject outDialog;

    public Transform tfSelected;
    public Dialog cmpDialog;

    public int status = 1;
    public int palletteLength;

	// Use this for initialization
	void Start () {
        this.tfSelected = outSelected.transform;
        this.palletteLength = XmlLoad();

        this.tfSelected.localPosition = new Vector3(0, 0);
        this.cmpDialog = outDialog.GetComponent<Dialog>();
    }

    public int XmlLoad()
    {
        string strUnitArray = Resources.Load<TextAsset>(UNITDATA_DIR).text;
        XElement xeUnitArray = XElement.Parse(strUnitArray);

        IEnumerable<XElement> iterator = xeUnitArray.Elements();

        int i = 0;
        foreach (XElement child in iterator)
        {
            GameObject unit = Resources.Load<GameObject>("unit/blue/" + child.Element("FileName").Value);
            GameObject obj = Instantiate(unit, transform);
            obj.transform.localPosition = new Vector3(i, 0);
            i++;
        }

        return i;
    }

    /// <summary>
    /// 선택 이미지의 이동
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    private void AddMoveSelectedOnly(int x, int y)
    {
        Vector3 pos = tfSelected.localPosition;
        pos.x += x;
        pos.y += y;
        tfSelected.localPosition = pos;
    }

    /// <summary>
    /// 선택 이미지의 이동(위치 제한)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool AddMoveSelected(int x, int y)
    {
        Vector3 pos = tfSelected.localPosition;
        pos.x += x;
        pos.y += y;

        if(status == 1)
        {
            if(pos.y == STATUS_1_POS_Y && pos.x >= STATUS_1_POS_MIN_X && pos.x < this.palletteLength)
            {
                this.tfSelected.localPosition = pos;
            }
            else
            {
                return false;
            }
        }
        else if(status == 2)
        {
            if (pos.y >= STATUS_2_POS_MIN_Y && pos.y <= STATUS_2_POS_MAX_Y && pos.x >= STATUS_2_POS_MIN_X && pos.x <= STATUS_2_POS_MAX_X)
            {
                this.tfSelected.localPosition = pos;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// V, X버튼에 따라 상태를 변경하며 좌표도 자동 변경
    /// </summary>
    /// <param name="add"></param>
    /// <returns></returns>
    public bool AddStatus(int add)
    {
        int changedValue = this.status + add;
        this.cmpDialog.Close();
        if(status == STATUS_UNIT && add == -1)
        {
            this.status = changedValue;
        }
        else if (changedValue == STATUS_PALLETTE_SELECT) // 지역 선택 => 팔레트 선택
        {
            this.status = changedValue;
            this.tfSelected.localPosition = new Vector3(STATUS_1_POS_MIN_X, STATUS_1_POS_Y);
        }
        else if (changedValue == STATUS_MAP_SELECT) //팔레트 선택 => 지역 선택
        {
            this.status = changedValue;
            this.tfSelected.localPosition = new Vector3(STATUS_1_POS_MIN_X, STATUS_2_POS_MIN_Y);
        }
        else if (changedValue == STATUS_TURN_END) //턴 종료 확인
        {
            this.status = changedValue;
            this.cmpDialog.View(Message.END_TURN_CHECK);
        }
        else if (status == STATUS_TURN_END && add == 1) //턴 종료
        {
            this.status = STATUS_PALLETTE_SELECT;
            this.tfSelected.localPosition = new Vector3(STATUS_1_POS_MIN_X, STATUS_1_POS_Y);
        }
        else if (changedValue == STATUS_UNIT) //유닛 배치 확인
        {
            this.status = changedValue;
            this.cmpDialog.View(Message.PLACE_UNIT_CHECK);
        }
        else if (status == STATUS_UNIT && add == 1) //유닛 배치
        {
            this.status = STATUS_PALLETTE_SELECT;
            this.tfSelected.localPosition = new Vector3(STATUS_1_POS_MIN_X, STATUS_1_POS_Y);
        }
        else
        {
            return false;
        }
        return true;
    }
}
