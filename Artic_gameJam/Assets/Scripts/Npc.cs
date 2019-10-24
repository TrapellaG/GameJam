using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour {

    public string text;
	// Use this for initialization
	void Start () {
		
	}
	
    //if the player gets near, the npc will talk
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Player.instance
            //talk.setActive(true);
        }
    }
}
