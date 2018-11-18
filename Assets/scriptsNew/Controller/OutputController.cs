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

    public void ViewDialog(int reason)
    {

    }
}
