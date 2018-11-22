using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputView : MonoBehaviour
{
    private OutputController outputController;

    public OutputController Controller { get { return this.outputController; } }

    public void Start()
    {
        this.outputController = new OutputController(this);    
    }

    public void AddUnit(UnitModel unit)
    {
        Logger.Log(Logger.KEY_UNIT_MAKE, "unit created to view : " + unit.Prefab);
        GameObject gameObject = Instantiate(unit.Prefab, transform);
        gameObject.transform.localPosition = new Vector3(unit.X, unit.Y);
    }

    public void ViewDialog(int reason)
    {
         
    }
}
