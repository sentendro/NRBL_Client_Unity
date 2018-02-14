using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour {

    List<AUnit> player1;
    List<AUnit> player2;

    private static UnitsManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        player1 = new List<AUnit>();
        player2 = new List<AUnit>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static UnitsManager getInstance()
    {
        return instance;
    }

    public List<AUnit> getUnitsList(int player)
    {
        switch(player)
        {
            case 1:
                return player1;
            case 2:
                return player2;
        }
        return null;
    }
}
