﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D myRB;

    //I believe to be better having all in one script
    public bool health;
    public float temperature;
    public int cans;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "object")
        {
            Destroy(collision.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        float vertical = Input.GetAxis("Vertical");

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            resourceCreator.instance.CreateCans();
            /*if (cans > 0)
            {
                cans--;
                Instantiate(resourceCreator.instance.food, transform.position + new Vector3(0, -2, 0), transform.rotation, null);
            }*/
        }

        myRB.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}