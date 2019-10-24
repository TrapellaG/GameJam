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

    public float gas;
    public float necesaryGas;
    public Text gasMeter;

    public float food;
    public float necesaryFood;
    public Text foodMeter;

    // Use this for initialization
    void Start () {
        UpdateMeters();
        npc = new GameObject[4];
	}
	
	public void changeDay () {
        if (Timer.instance.time >= 0)
        {
            if (gas < necesaryGas)
            {
                //game over
            }
            else if (food < necesaryFood)
            {
                //game over
            }

            food -= necesaryFood;
            gas -= necesaryGas;

            day++;
        }
	}

    public void UpdateMeters()
    {
        gasMeter.text = gas.ToString() + "/" + necesaryGas.ToString();
        foodMeter.text = food.ToString() + "/" + necesaryFood.ToString();
    }

    public void KillNpc()
    {
        //Destroy();
    }

    public void GameOver()
    {

    }
}
