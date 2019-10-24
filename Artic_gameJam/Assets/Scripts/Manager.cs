using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public static Manager instance = null;

    //now we make the instance be like this script
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance);
        }
    }

    public int day;

    public GameObject[] npc;

    public int necesaryGas;
    public Text gasMeter;

    public int necesaryFood;
    public Text foodMeter;

    // Use this for initialization
    void Start () {
        UpdateMeters();
        npc = new GameObject[4];
	}
	
	public void changeDay () {
        if (Timer.instance.time >= 0)
        {
            if (Player.instance.gas < necesaryGas)
            {
                //game over
            }
            else if (Player.instance.food < necesaryFood)
            {
                //game over
            }

            Player.instance.food -= necesaryFood;
            Player.instance.gas -= necesaryGas;

            day++;
        }
	}

    public void UpdateMeters()
    {
        gasMeter.text = Player.instance.gas.ToString() + "/" + necesaryGas.ToString();
        foodMeter.text = Player.instance.food.ToString() + "/" + necesaryFood.ToString();
    }

    public void KillNpc()
    {
        //Destroy();
    }

    public void GameOver()
    {

    }
}
