using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class OrderModel
{
    //1 : 만들 유닛이 필요
    //2 : 움직일 유닛 ID와 이동방향
    //3 : 해당 유닛 ID와 유저타입
    //4 : 공격 유닛ID과 데미지 입힐 유닛ID
    public const int ORDER_TYPE_UNIT_CREATE = 1, ORDER_TYPE_UNIT_MOVE = 2, ORDER_TYPE_UNIT_UPGRDADE = 3, ORDER_TYPE_ATTACK = 4;
    public const int USER_TYPE_PLAYER = 1, USER_TYPE_ENEMY = 2;

    public int orderType { get; set; }
    public int userType { get; set; }

    public OrderModel(int userType, int orderType)
    {
        this.userType = userType;
        this.orderType = orderType;
    }
}