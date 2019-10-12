using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int gold, hp, capacity, timer;
    public Text textGold, textHp, textCapacity, textTimer;
    //public Dialog outDialog;

    public int Gold
    {
        set
        {
            gold = value;
            textGold.text = "G:" + gold;
        }
        get { return gold; }
    }

    public int Capacity
    {
        set
        {
            capacity = value;
            textCapacity.text = "C:" + capacity;
        }
        get { return capacity; }
    }

    public int Hp
    {
        set
        {
            hp = value;
            textHp.text = "H:" + hp;
        }
        get { return hp; }
    }

    public int Timer
    {
        set
        {
            timer = value;
            textTimer.text = "T:" + timer;
        }
        get { return timer; }
    }

    private Coroutine coroutine;

    private void Start()
    {
        Gold = Gold;
        Hp = Hp;
        Capacity = Capacity;
        Timer = Timer;
        //textGold.text = gold.ToString();
        //textHp.text = hp.ToString();
        //textCapacity.text = capacity.ToString();
        //textTimer.text = timer.ToString();

        coroutine = StartCoroutine("TimerCount");
    }

    public IEnumerator TimerCount()
    {
        while(timer > 0)
        {
            yield return new WaitForSeconds(2f);
            Timer--;
            //textTimer.text = timer.ToString();
        }
    }

    public void UpdateGoldStoreGold(int value)
    {
        Gold += value;
        //gold += value;
        //textGold.text = gold.ToString();
    }

    public void UpdateHouseCapacity(int value)
    {
        Capacity += value;
        //capacity += value;
        //textCapacity.text = capacity.ToString();
    }

    public void UpdateMovableDamage(int damage)
    {
        Hp -= damage;
        Debug.Log("player damage");
    }

    public bool Check(Unit unit)
    {
        Dialog dialog = GameResources.Dialog;

        if(gold < unit.PlayerPrice)
        {
            dialog.ShowPlayerNotEnoughGold();
            return false;
        }
        else if(capacity < unit.PlayerFood)
        {
            dialog.ShowPlayerNotEnoughFood();
            return false;
        }

        return true;
    }

    public void Buy(Unit unit)
    {
        Gold -= unit.PlayerPrice;
        Capacity -= unit.PlayerFood;
        //gold -= unit.PlayerPrice;
        //capacity -= unit.PlayerFood;
        //textGold.text = gold.ToString();
        //textCapacity.text = capacity.ToString();
    }

    public void NextTurn()
    {
        StopCoroutine(coroutine);
        Timer = 10;
        //timer = 10;
        //textTimer.text = timer.ToString();
    }
}
