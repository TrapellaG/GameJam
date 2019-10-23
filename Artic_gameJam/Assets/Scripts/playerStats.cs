using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public bool health;
    public float temperature;
    public int cans;

    public void increaseCans()
    {
        Debug.Log("cans ++");
        cans++;
    }
    public void DecreaseCans()
    {
        cans--;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
