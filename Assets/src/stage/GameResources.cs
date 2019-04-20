using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    public static PalletteView PalletteView { get; private set; }
    public static MapSelectView MapSelectView { get; private set; }
    public static Player Player { get; private set; }
    public static Stage Stage { get; private set; }
    public static Dialog Dialog { get; private set; }
    public static AIEnemy AIEnemy { get; private set; }
    public static OffensiveAIEnemy OffensiveAIEnemy { get; private set; }
    public static UnitPlacer UnitPlacer { get; private set; }

    public static Transform TfUnitLayer { get; private set; }
    public static Transform TfEnemyPallette { get; private set; }
    public static Transform TfTurnCheckerText { get; private set; }

    public static GameObject ObjTurnCheckerTextPrefab { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        UnitPlacer = FindComponent<UnitPlacer>("Stage");
        Stage = FindComponent<Stage>("Stage");
        Player = FindComponent<Player>("Stage");
        Dialog = FindComponent<Dialog>("Dialog");
        PalletteView = FindComponent<PalletteView>("Pallette");
        MapSelectView = FindComponent<MapSelectView>("Map");
        AIEnemy = FindComponent<AIEnemy>("EnemyPallette");
        OffensiveAIEnemy = FindComponent<OffensiveAIEnemy>("EnemyPallette");

        TfUnitLayer = GameObject.Find("UnitLayer").transform;
        TfEnemyPallette = GameObject.Find("EnemyPallette").transform;
        TfTurnCheckerText = GameObject.Find("TurnCheckerText").transform;

        Logger.Log("GameResources", "TfEnemyPallette", TfEnemyPallette);

        ObjTurnCheckerTextPrefab = GameObject.Find("TurnCheckerTextPrefab");

        Dialog.gameObject.SetActive(false);
        ObjTurnCheckerTextPrefab.SetActive(false);
    }

    public T FindComponent<T>(string name)
    {
        GameObject obj = GameObject.Find(name);
        if(obj == null)
        {
            throw new NoAssignedException(this, typeof(GameObject).Name);
        }
        else
        {
            T component = obj.GetComponent<T>();

            if (component == null)
            {
                throw new NoAssignedException(this, typeof(T).Name);
            }
            else
            {
                return component;
            }
        }
    }
}
