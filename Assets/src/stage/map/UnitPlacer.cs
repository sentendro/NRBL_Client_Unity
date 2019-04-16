using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacer : MonoBehaviour
{
    public PalletteView outPalletteView;
    public MapSelectView outMapSelectView;
    public Dialog outDialog;
    public Transform outTfUnitLayer;
    public Stage outStage;
    public Player outPlayer;
    public PlaceStatus status = PlaceStatus.Default;

    public void OnOk()
    {
        switch (status)
        {
            case PlaceStatus.Default:
                if (Check())
                {
                    outDialog.ShowUnitPlacerCheck();
                    status = PlaceStatus.Check;
                }
                break;
            case PlaceStatus.Check:
                outDialog.Hide();
                status = PlaceStatus.Default;
                Place();
                break;
            case PlaceStatus.Fail:
                outDialog.Hide();
                status = PlaceStatus.Default;
                break;
        }
    }

    public void OnCancel()
    {
        switch (status)
        {
            case PlaceStatus.Default:
                break;
            case PlaceStatus.Check:
                outDialog.Hide();
                status = PlaceStatus.Default;
                break;
            case PlaceStatus.Fail:
                outDialog.Hide();
                break;
        }
    }

    public bool Check()
    {
        if (outPalletteView.inSelectedUnit == null)
        {
            outDialog.ShowUnitPlacerNoSelectUnit();
            status = PlaceStatus.Fail;
            return false;
        }
        else if (outMapSelectView.inSelectedTIle == null)
        {
            outDialog.ShowUnitPlacerNoSelectTile();
            status = PlaceStatus.Fail;
            return false;
        }
        else if(outPlayer.Check(outPalletteView.inSelectedUnit.GetComponent<Unit>()) == false)
        {
            status = PlaceStatus.Fail;
            return false;
        }

        return true;
    }

    public void Place()
    {
        GameObject objPalletteUnit = outPalletteView.inSelectedUnit;
        Vector3 position = outMapSelectView.inSelectedPosition;
        
        Unit unit = outStage.CreateUnit(objPalletteUnit, position);
        
        outStage.AddUnit(unit);
        outPlayer.Buy(unit);

        outPalletteView.HideSelectedUI();
        outMapSelectView.HideSelectedUI();
    }

    public enum PlaceStatus
    {
        Default, Check, Fail
    }
}
