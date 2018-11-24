using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class OutputController
{
    private OutputView outputView;

    public OutputController(OutputView view)
    {
        this.outputView = view;
    }

    public void AddUnit(UnitModel model)
    {
        this.outputView.AddUnit(model);
    }

    public void ViewDialog(string text)
    {
        this.outputView.ViewDialog(text);
    }

    public void UpdateGage(UserModel user, UnitGroupController unitGroup)
    {
        this.outputView.UpdateHpGage(user.Hp);
        this.outputView.UpdateGoldGage(user.Gold);
        this.outputView.UpdateFoodData(unitGroup.GetRemainCapacity());
    }
}
