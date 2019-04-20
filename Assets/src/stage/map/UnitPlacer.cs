using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacer : MonoBehaviour
{
    //public PalletteView outPalletteView;
    //public MapSelectView outMapSelectView;
    //public Dialog outDialog;
    //public Transform outTfUnitLayer;
    //public Stage outStage;
    //public Player outPlayer;
    public PlaceStatus status = PlaceStatus.Default;

    /// <summary>
    /// 'V' 버튼을 눌렀을때 발생
    /// </summary>
    public void OnOk()
    {
        Dialog dialog = GameResources.Dialog;

        switch (status)
        {
            case PlaceStatus.Default:
                if (Check())
                {
                    dialog.ShowUnitPlacerCheck();
                    status = PlaceStatus.Check;
                }
                break;
            case PlaceStatus.Check:
                dialog.Hide();
                status = PlaceStatus.Default;
                Place();
                break;
            case PlaceStatus.Fail:
                dialog.Hide();
                status = PlaceStatus.Default;
                break;
        }
    }

    /// <summary>
    /// 'X' 버튼을 눌렀을때 발생
    /// </summary>
    public void OnCancel()
    {
        Dialog dialog = GameResources.Dialog;

        switch (status)
        {
            case PlaceStatus.Default:
                break;
            case PlaceStatus.Check:
                dialog.Hide();
                status = PlaceStatus.Default;
                break;
            case PlaceStatus.Fail:
                dialog.Hide();
                break;
        }
    }

    public bool Check()
    {
        PalletteView palletteView = GameResources.PalletteView;
        MapSelectView mapSelectView = GameResources.MapSelectView;
        Player player = GameResources.Player;
        Dialog dialog = GameResources.Dialog;

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
        PalletteView palletteView = GameResources.PalletteView;
        MapSelectView mapSelectView = GameResources.MapSelectView;
        Player player = GameResources.Player;
        Stage stage = GameResources.Stage;

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
