using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_Destruct : MonoBehaviour {

    // Use this for initialization
    private float time;
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > 3)
        {
            Destroy(this.gameObject);
        }
	}
}
