using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D myRB;
    playerStats player;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "object")
        {
            Destroy(collision.gameObject);
            player.increaseCans();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        player = GetComponent<playerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        myRB.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
