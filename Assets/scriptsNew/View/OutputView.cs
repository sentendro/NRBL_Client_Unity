using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputView : MonoBehaviour
{
    private OutputController outputController;

    public OutputController Controller { get { return this.outputController; } }

    public GameObject outDialog, outGage;
    private DialogView dialogView;
    private GageView gageView;

    public bool IsDialogActive { get { return dialogView.gameObject.activeInHierarchy; } }

    public void Start()
    {
        this.outputController = new OutputController(this);
        this.dialogView = outDialog.GetComponent<DialogView>();
        this.gageView = outGage.GetComponent<GageView>();
    }

    public void AddUnit(UnitModel unit)
    {
        Logger.Log(Logger.KEY_UNIT_MAKE, "unit created to view : " + unit.Prefab);
        GameObject gameObject = Instantiate(unit.Prefab, transform);
        gameObject.transform.localPosition = new Vector3(unit.X, unit.Y);
    }

    public void ViewDialog(string text)
    {
        this.dialogView.View(text);
    }

    public void CloseDialog()
    {
        this.dialogView.Close();
    }

    public void UpdateHpGage(int hp)
    {
        this.gageView.UpdateHpData(hp);
    }

    public void UpdateGoldGage(int gold)
    {
        this.gageView.UpdateGoldData(gold);
    }

    public void UpdateFoodData(int food)
    {
        this.gageView.UpdateFoodData(food);
    }
}
