using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageResource : MonoBehaviour
{
    private static UnitPlacer unitPlacer;
    private static Stage stage;
    private static Player player;
    private static Dialog dialog;
    private static PalletteView palletteView;
    private static MapSelectView mapSelectView;
    private static AIEnemy aIEnemy;
    private static OffensiveAIEnemy offAiEnemy;

    // Start is called before the first frame update
    void Awake()
    {
        unitPlacer = FindComponent<UnitPlacer>("Stage");
        stage = FindComponent<Stage>("Stage");
        player = FindComponent<Player>("Stage");
        dialog = FindComponent<Dialog>("Dialog");
        palletteView = FindComponent<PalletteView>("Pallette");
        mapSelectView = FindComponent<MapSelectView>("Map");
        aIEnemy = FindComponent<AIEnemy>("EnemyPallette");
        offAiEnemy = FindComponent<OffensiveAIEnemy>("EnemyPallette");

        dialog.gameObject.SetActive(false);
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

    public static PalletteView PalletteView { get { return palletteView; } }
    public static MapSelectView MapSelectView { get { return mapSelectView; } }
    public static Player Player { get { return player; } }
    public static Stage Stage { get { return stage; } }
    public static Dialog Dialog { get { return dialog; } }
}
