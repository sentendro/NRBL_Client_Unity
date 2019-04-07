

public class UnitModel {
    private int kindId, id, x, y;

    public static int UNIT_LAST_ID = 1;
    public UnitModel(int kindId, int x, int y)
    {
        this.kindId = kindId;
        this.x = x;
        this.y = y;
        this.id = UNIT_LAST_ID++;
    }

}
