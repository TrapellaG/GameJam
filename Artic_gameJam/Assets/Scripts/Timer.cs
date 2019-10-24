using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Canvas timer;
    public Text countdown;
    public float time = 200.0f; 

	// Use this for initialization
	void Start ()
    {
        timer = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
        countdown.text = ("time: " + (int)time);

        if(time == 0)
        {
            time = 200;
        }
	}
}
