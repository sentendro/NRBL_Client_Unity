 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StageController
{
    private UserModel enemy, player;
    private UnitGroupController enemies;
    private UnitGroupController myUnits;
    private AniQueueController aniQueue;

    public StageController()
    {
        this.enemies = new UnitGroupController();
        this.myUnits = new UnitGroupController();
        this.aniQueue = new AniQueueController();
        this.enemy = new UserModel();
        this.player = new UserModel();
    }

    public void UpdateUnits()
    {
        foreach(UnitController unit in this.myUnits)
        {
            unit.UpdateMove(enemies, myUnits, -1);
            unit.UpdateRangeAttack(enemies, -1);
            unit.UpdatePlayerAttack(enemy, -1);
            unit.UpdateTurn(myUnits, -1);
        }

        foreach (UnitController unit in this.enemies)
        {
            unit.UpdateMove(myUnits, enemies, -1);
            unit.UpdateRangeAttack(myUnits, -1);
            unit.UpdatePlayerAttack(player, -1);
            unit.UpdateTurn(enemies, -1);
        }
    }

    public void AddPlayerUnit(string name, int x, int y)
    {
        this.myUnits.AddUnit(name, x, y);
    }

    public void AddEnemyUnit(string name, int x, int y)
    {
        this.enemies.AddUnit(name, x, y);
    }
}