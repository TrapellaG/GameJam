using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thermometer : MonoBehaviour {

    Canvas temperature;
    public Slider temperatureSlider;

    // Use this for initialization
    void Start ()
    {
        temperature = GetComponent<Canvas>();
    }
	
	// Update is called once per frame
	void Update () {

        temperatureSlider.value = Player.instance.temperature;		
	}
}
