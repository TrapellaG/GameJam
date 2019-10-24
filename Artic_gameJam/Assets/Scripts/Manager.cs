using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float food;
    public float necesaryFood;

    // Use this for initialization
    void Start () {
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

    public void killNpc()
    {
        //Destroy();
    }

}
