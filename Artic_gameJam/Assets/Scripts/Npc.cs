using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour {

    public int number;
    public int round;
    public string line;

	// Use this for initialization
	void Start () {
		
	}
	
    //if the player gets near, the npc will talk
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //line = LineManager.instance.lines[number][round];

            //Player.instance.SetLine();
            //Player.instance
            //talk.setActive(true);
        }
    }
}
