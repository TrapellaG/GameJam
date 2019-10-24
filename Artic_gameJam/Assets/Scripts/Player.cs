﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player is created on a variable called instance
    public static Player instance = null;

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
    }// now we can acces to Player.instance since it is public. Being equal to this script, Player.instance can be used as a reference to this script

    public float speed;
    public Rigidbody2D myRB;

    //I believe to be better having all in one script
    public bool health;
    public float temperature = 36.5f;
    public float maxTemperature;
    public int cans;
    public int barrels;

    /*[HideInInspector]*/ public float time = 0;
    public float timeToTemperature = 1;
    public bool inside;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "object")
        {
            Destroy(collision.gameObject);
            player.increaseCans();
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (inside == true)
        {
            IncreaseTemperature();
        }
        else
            DecreaseTemperature();
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            resourceCreator.instance.CreateCans();
            if (cans > 0)
            {
                cans--;
                Instantiate(resourceCreator.instance.food, transform.position + new Vector3(0, -2, 0), transform.rotation, null);
            }
        }*/
        if (myRB.velocity.x > 0)
        {
            resourceCreator.instance.CreateCans();
            resourceCreator.instance.CreateGas();
        }


        myRB.velocity = new Vector2(horizontal * speed, vertical * speed);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Outside")
        {
            inside = false;
        }
        else if (collision.gameObject.tag == "Inside")
        {
            inside = true;
            for (int i = 0; i < cans; i++)
            {
                Manager.instance.food++;
            }
            for (int i = 0; i < barrels; i++)
            {
                Manager.instance.gas++;
            }
            
            Manager.instance.changeDay();
        }
    }

    public void DecreaseTemperature()
    {
        if (time >= timeToTemperature)
        {
            time = 0;
            temperature--;
        }
    }

    public void IncreaseTemperature()
    {
        time += Time.deltaTime;

        if (time >= timeToTemperature)
        {
            time = 0;
            if (temperature < maxTemperature)
            {
                temperature++;
            }
        }
    }
}
