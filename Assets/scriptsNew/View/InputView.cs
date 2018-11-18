using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputView : MonoBehaviour
{
    public const string UNITDATA_DIR = "data/units";
    private InputController inputController;
    private OutputView outputView;

    public GameObject outOutputView;
    public GameObject outSelected;
    public GameObject outDialog;

    public Transform tfSelected;
    public Dialog cmpDialog;

	// Use this for initialization
	void Start () {
        this.tfSelected = outSelected.transform;
        int palletteLength = XmlLoad();

        this.tfSelected.localPosition = new Vector3(0, 0);
        this.cmpDialog = outDialog.GetComponent<Dialog>();

        this.outputView = outOutputView.GetComponent<OutputView>();
        this.inputController = new InputController(this, outputView, palletteLength);
    }

    /// <summary>
    /// Xml데이터로 저장되어있는 유닛들을 불러옴
    /// </summary>
    /// <returns></returns>
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
        return inputController.AddMoveSelected(x, y, tfSelected);
    }

    /// <summary>
    /// V, X버튼에 따라 상태를 변경하며 좌표도 자동 변경
    /// </summary>
    /// <param name="add"></param>
    /// <returns></returns>
    public bool AddStatus(int add)
    {
        return inputController.AddStatus(add, tfSelected, cmpDialog);
    }
}
