using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class UserModel
{
    public const int DEFAULT_HP = 20, DEFAULT_GOLD = 5;
    
    public int Gold { get; set; }
    public int Hp { get; set; }

    public UserModel()
    {
        this.Hp = DEFAULT_HP;
        this.Gold = DEFAULT_GOLD;
    }
}
