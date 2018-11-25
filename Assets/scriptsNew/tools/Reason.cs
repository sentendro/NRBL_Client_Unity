using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Reason
{
    public const int ADD_UNIT_SUCCESS = 0, ADD_UNIT_PRICE = 1, ADD_UNIT_FOOD = 2, ADD_UNIT_POSITION = 3;

    public static string[] message = new string[] { "유닛이 추가되었습니다", "골드가 부족합니다", "식량이 부족합니다", "이미 해당 자리에 유닛이 존재합니다" };
}