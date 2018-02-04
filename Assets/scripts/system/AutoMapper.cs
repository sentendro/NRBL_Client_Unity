using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMapper : MonoBehaviour {
    public string TILEPALETTE_DIR = "tile", MAPDATA_DIR = "data/map";
    public int xgap = 0, ygap = -2;
    public int pstart = 0, pend = 2;
	// Use this for initialization
	void Start () {
        Load(MAPDATA_DIR);
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void Load(string mapfilename)
    {
        //타일을 종류별로 불러옴
        GameObject[] tilePalette = Resources.LoadAll<GameObject>(TILEPALETTE_DIR);
        //맵파일 불러옴
        string mapData = LoadMapData(mapfilename);
        //좌표 0, 0이 가운데일수도 있음
        int x = xgap, y = ygap;
        for(int i = 0; i < mapData.Length; i++)
        {
            //문자 0은 실제 숫자 0과 다른개념이다
            int idx = mapData[i] - '0';
            if (idx == -35)
            {
                y++;
                i++;//왜인지는 모르겠으나 갱행문자가 2개로 나타남
                x = xgap;
                continue;
            }
            //자기자신의 자식으로 넣어 관리가 가능하게 한다
            GameObject goTile = Instantiate(tilePalette[idx], transform);
            goTile.transform.localPosition = new Vector3(x, y);
            goTile.name = "tile(" + x + "," + y + ")";

            if(pstart <= y && y <= pend)
            {
                //플레이어가 유닛을 선택 가능한 지역을 다른 레이어에
                //추가 시켜놓고 이들에 대해서만 레이캐스트 처리를 하려 한다
                goTile.layer = LayerMask.NameToLayer("Placable");
            }

            x++;
        }
    }

    public string LoadMapData(string filename)
    {
        //데이터를 일반 파일처리식으로 불러오면 빌드 후에 사용이 불가능
        return Resources.Load<TextAsset>(filename).text;
    }
}
