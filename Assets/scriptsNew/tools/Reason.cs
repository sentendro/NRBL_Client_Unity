using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Reason
{
    public const int ADD_UNIT_SUCCESS = 0, ADD_UNIT_PRICE = 1, ADD_UNIT_FOOD = 2;

    public static string[] message = new string[] { "유닛이 추가되었습니다", "골드가 부족합니다", "식량이 부족합니다" };
}