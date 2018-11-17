using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class InputStateMachine
{
    private const int STATUS_1_POS_Y = 0, STATUS_1_POS_MIN_X = 0, STATUS_1_POS_MAX_X = 5;
    private const int STATUS_2_POS_MIN_Y = 2, STATUS_2_POS_MAX_Y = 3, STATUS_2_POS_MIN_X = 0, STATUS_2_POS_MAX_X = 6;
    public const int STATUS_TURN_END = 0, STATUS_PALLETTE_SELECT = 1, STATUS_MAP_SELECT = 2, STATUS_UNIT = 3;

    private int status = STATUS_PALLETTE_SELECT;
    private int palletteLength = 0;
    private PalletteMakerView palletteView;
    private StageController stage;

    public InputStateMachine(PalletteMakerView palletteView, int palletteLength)
    {
        this.palletteView = palletteView;
        this.palletteLength = palletteLength;
        this.stage = new StageController();
    }

    /// <summary>
    /// 선택 이미지의 이동(위치 제한)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool AddMoveSelected(int x, int y, Transform tfSelected)
    {
        Vector3 pos = tfSelected.localPosition;
        pos.x += x;
        pos.y += y;

        if (status == 1)
        {
            if (pos.y == STATUS_1_POS_Y && pos.x >= STATUS_1_POS_MIN_X && pos.x < this.palletteLength)
            {
                tfSelected.localPosition = pos;
            }
            else
            {
                return false;
            }
        }
        else if (status == 2)
        {
            if (pos.y >= STATUS_2_POS_MIN_Y && pos.y <= STATUS_2_POS_MAX_Y && pos.x >= STATUS_2_POS_MIN_X && pos.x <= STATUS_2_POS_MAX_X)
            {
                tfSelected.localPosition = pos;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// V, X버튼에 따라 상태를 변경하며 좌표도 자동 변경
    /// </summary>
    /// <param name="add"></param>
    /// <returns></returns>
    public bool AddStatus(int add, Transform tfSelected, Dialog cmpDialog)
    {
        int changedValue = this.status + add;
        cmpDialog.Close();
        if (status == STATUS_UNIT && add == -1)
        {
            this.status = changedValue;
        }
        else if (changedValue == STATUS_PALLETTE_SELECT) // 지역 선택 => 팔레트 선택
        {
            this.status = changedValue;
            tfSelected.localPosition = new Vector3(STATUS_1_POS_MIN_X, STATUS_1_POS_Y);
        }
        else if (changedValue == STATUS_MAP_SELECT) //팔레트 선택 => 지역 선택
        {
            this.status = changedValue;
            tfSelected.localPosition = new Vector3(STATUS_1_POS_MIN_X, STATUS_2_POS_MIN_Y);
        }
        else if (changedValue == STATUS_TURN_END) //턴 종료 확인
        {
            this.status = changedValue;
            cmpDialog.View(Message.END_TURN_CHECK);
        }
        else if (status == STATUS_TURN_END && add == 1) //턴 종료
        {
            this.status = STATUS_PALLETTE_SELECT;
            tfSelected.localPosition = new Vector3(STATUS_1_POS_MIN_X, STATUS_1_POS_Y);
        }
        else if (changedValue == STATUS_UNIT) //유닛 배치 확인
        {
            this.status = changedValue;
            cmpDialog.View(Message.PLACE_UNIT_CHECK);
        }
        else if (status == STATUS_UNIT && add == 1) //유닛 배치
        {
            this.status = STATUS_PALLETTE_SELECT;
            tfSelected.localPosition = new Vector3(STATUS_1_POS_MIN_X, STATUS_1_POS_Y);
        }
        else
        {
            return false;
        }
        return true;
    }
}