using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AniController
{
    private Queue<AniModel> queue = new Queue<AniModel>();

    public void InsertAni(int type, UnitModel sub)
    {
        AniModel model = new AniModel(type, sub);
    }

    public void InsertAni(int type, UnitModel sub, UnitModel obj)
    {
        AniModel model = new AniModel(type, sub, obj);
    }

    public IEnumerator<object> StartCorutine()
    {
        if(queue.Count > 0)
        {
            AniModel current = queue.Dequeue();
            switch (current.Type) {
                case AniModel.TYPE_ATTACK:
                    ExecuteAttack(current);
                    break;
                case AniModel.TYPE_DEATH:
                    ExecuteDeath(current);
                    break;
                case AniModel.TYPE_MOVE:
                    ExecuteMove(current);
                    break;
                case AniModel.TYPE_UPGRADE:
                    ExecuteUpgrade(current);
                    break;
            }

            yield return new WaitForSeconds(0.5f);//0.5초에 한 행동씩
        }
        else
        {
            yield break;
        }
    }

    public void ExecuteMove(AniModel model)
    {
        UnitModel unit = model.Subject;
        Transform tf = unit.GObject.transform;
        tf.localPosition = new Vector3(unit.X, unit.Y);
    }

    public void ExecuteDeath(AniModel model)
    {

    }

    public void ExecuteAttack(AniModel model)
    {

    }

    public void ExecuteUpgrade(AniModel model)
    {

    }
}