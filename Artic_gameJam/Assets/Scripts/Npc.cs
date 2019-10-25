using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour {

    public int number;
    public int round;
    public string[] line;
    SpriteRenderer myRenderer;
    public Animator animator;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

}
