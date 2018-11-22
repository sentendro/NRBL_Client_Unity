 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StageController
{
    private UnitGroupController enemies;
    private UnitGroupController myUnits;
    private OutputController output;

    public StageController(OutputController outputController)
    {
        this.enemies = new UnitGroupController(this);
        this.myUnits = new UnitGroupController(this);
        this.output = outputController;
    }

    public void UpdateUnits()
    {
        foreach(UnitController unit in this.myUnits)
        {
            unit.UpdateMove(enemies, myUnits, -1);
            unit.UpdateRangeAttack(enemies, -1);
            unit.UpdatePlayerAttack(enemies.User, -1);
            unit.UpdateTurn(myUnits, -1);
        }

        foreach (UnitController unit in this.enemies)
        {
            unit.UpdateMove(myUnits, enemies, -1);
            unit.UpdateRangeAttack(myUnits, -1);
            unit.UpdatePlayerAttack(myUnits.User, -1);
            unit.UpdateTurn(enemies, -1);
        }
    }

    public void AddUnit(string name, int x, int y)
    {
        UnitModel model = this.myUnits.AddUnit(name, x, y);

        Logger.Log(Logger.KEY_UNIT_MAKE, string.Format("Stage UnitModel Is {0}", model));

        output.AddUnit(model);
    }
}