using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //if the player gets near, the npc will talk
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "")
        {
            //talk
        }
    }
}
