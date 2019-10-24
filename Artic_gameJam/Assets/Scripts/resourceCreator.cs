﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceCreator : MonoBehaviour {
    //resourceCreator is created on a variable called instance
    public static resourceCreator instance = null;

    //now we make the instance be like this script
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }// now we can acces to resourceCreator.instance since it is public. Being equal to this script, resourceCreator.instance can 
    //  be used as a reference to this script

    //defining the limits of where to create the resources
    public float maxX;
    public float minX;

    public float maxY;
    public float minY;

    public GameObject food;
    public GameObject gas;

    //here the class will create in random positions clones of the food and gas
    public void CreateItems()
    {
        CreateCans();
        CreateGas();
    }

    public void CreateCans()
    {
        GameObject can = Instantiate(food);
        can.transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
    }

    public void CreateGas()
    {
        GameObject barrel = Instantiate(gas);
        barrel.transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
    }
}