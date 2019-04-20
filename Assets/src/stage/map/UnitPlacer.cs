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

    /// <summary>
    /// 'V' 버튼을 눌렀을때 발생
    /// </summary>
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

    /// <summary>
    /// 'X' 버튼을 눌렀을때 발생
    /// </summary>
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
        PalletteView palletteView = StageResource.PalletteView;
        MapSelectView mapSelectView = StageResource.MapSelectView;
        Player player = StageResource.Player;
        Dialog dialog = StageResource.Dialog;

        if (palletteView.UnitPlacerSelectedUnit() == null)
        {
            dialog.ShowUnitPlacerNoSelectUnit();
            status = PlaceStatus.Fail;
            return false;
        }
        else if (mapSelectView.UnitPlacerSelectedTile() == null)
        {
            dialog.ShowUnitPlacerNoSelectTile();
            status = PlaceStatus.Fail;
            return false;
        }
        else if(player.Check(palletteView.UnitPlacerSelectedUnit()) == false)
        {
            status = PlaceStatus.Fail;
            return false;
        }

        return true;
    }

    public void Place()
    {
        PalletteView palletteView = StageResource.PalletteView;
        MapSelectView mapSelectView = StageResource.MapSelectView;
        Player player = StageResource.Player;
        Stage stage = StageResource.Stage;

        Unit palletteUnit = palletteView.UnitPlacerSelectedUnit();
        Vector3 position = mapSelectView.UnitPlacerSelectedPosition();
        
        Unit unit = stage.CreateUnit(palletteUnit.gameObject, position);
        
        stage.AddUnit(unit);
        player.Buy(unit);

        palletteView.HideSelectedUI();
        mapSelectView.HideSelectedUI();
    }

    public enum PlaceStatus
    {
        Default, Check, Fail
    }
}
