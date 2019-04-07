using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int gold, hp, capacity, timer;
    public Text textGold, textHp, textCapacity, textTimer;
    public Dialog outDialog;

    private Coroutine coroutine;

    private void Start()
    {
        textGold.text = gold.ToString();
        textHp.text = hp.ToString();
        textCapacity.text = capacity.ToString();
        textTimer.text = timer.ToString();

        coroutine = StartCoroutine("TimerCount");
    }

    public IEnumerator TimerCount()
    {
        while(timer > 0)
        {
            yield return new WaitForSeconds(2f);
            timer--;
            textTimer.text = timer.ToString();
        }
    }

    public void UpdateGoldStoreGold(int value)
    {
        gold += value;
        textGold.text = gold.ToString();
    }

    public bool Check(Unit unit)
    {
        Debug.Log(gold + "/" + unit.price + "/" + capacity + "/" + unit.food);
        if(gold < unit.price)
        {
            outDialog.ShowPlayerNotEnoughGold();
            return false;
        }
        else if(capacity < unit.food)
        {
            outDialog.ShowPlayerNotEnoughFood();
            return false;
        }

        return true;
    }

    public void Buy(Unit unit)
    {
        gold -= unit.price;
        capacity -= unit.food;
        textGold.text = gold.ToString();
        textCapacity.text = capacity.ToString();
    }

    public void NextTurn()
    {
        StopCoroutine(coroutine);
        timer = 10;
        textTimer.text = timer.ToString();
    }
}
