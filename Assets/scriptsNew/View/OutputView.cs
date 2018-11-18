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
        GameObject gameObject = Instantiate(unit.Prefab, transform);
    }

    public void ViewDialog(int reason)
    {
         
    }
}
