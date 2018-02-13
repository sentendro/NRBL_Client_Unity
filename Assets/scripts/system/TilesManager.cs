using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour {
    //전체 타일
    Tiles[][] allTiles;

    //전체 타일 한 줄의 수
    const int numOfTile = 7;

    //싱글톤 패턴
    private static TilesManager instance;

    //직접 생성 불가
    private TilesManager() { }

    private void Awake()
    {
        //싱글톤 패턴
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        //전체 타일 공간확보
        allTiles = new Tiles[numOfTile][];
        for(int i = 0; i < numOfTile; i++)
        {
            allTiles[i] = new Tiles[numOfTile];
        }
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateTile(Tiles newTile)
    {
        allTiles[(int)(newTile.selfPosition.x)][(int)(newTile.selfPosition.y)] = newTile;
    }
    public void updateTile(Tiles newTile, Vector2 tiledPosition)
    {
        allTiles[(int)(tiledPosition.x)][(int)(tiledPosition.y)] = newTile;
    }
    public static TilesManager getInstance()
    {
        return instance;
    }
}
