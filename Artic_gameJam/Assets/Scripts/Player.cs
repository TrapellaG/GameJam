using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Player is created on a variable called instance
    public static Player instance = null;
    public Animator animator;
    bool facingright = true;
    bool facingFront = false;
    bool facingBack = false;
    SpriteRenderer myRenderer;

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
    public float maxTemperature = 36.5f;
    public int food;
    public int gas;

    public ParticleSystem snow;

    public AudioSource audioSource;

    public float time = 0;
    public float timeToTemperature = 1;
    public bool inside;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "object")
        {
            Destroy(collision.gameObject);
            player.increasefood();
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
            resourceCreator.instance.Createfood();
            if (food > 0)
            {
                food--;
                Instantiate(resourceCreator.instance.food, transform.position + new Vector3(0, -2, 0), transform.rotation, null);
            }
        }*/
        if (!inside)
        {
            if (myRB.velocity.x != 0)
            {
                resourceCreator.instance.CreateItems();
                //resourceCreator.instance.CreateFood();
                //resourceCreator.instance.CreateGas();
            }
            else if (myRB.velocity.y != 0)
            {
                resourceCreator.instance.CreateItems();
                //resourceCreator.instance.CreateFood();
                //resourceCreator.instance.CreateGas();
            }

            if (temperature <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (horizontal > 0 && !facingright)
        {
            Flip();
        }
        else if (horizontal < 0 && facingright)
        {
            Flip();
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("walkingBack");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("walkingFront");
        }

        myRB.velocity = new Vector2(horizontal * speed, vertical * speed);

        animator.SetFloat("walkingY", Mathf.Abs(horizontal));
        animator.SetFloat("walking", Mathf.Abs(vertical));
    }

    void Flip()
    {
        facingright = !facingright;
        myRenderer.flipX = !myRenderer.flipX;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Outside")
        {
            inside = false;
            audioSource.Play();
            snow.startColor = new Color(snow.startColor.r, snow.startColor.g, snow.startColor.b, 1f);
        }
        else if (collision.gameObject.tag == "Inside")
        {
            snow.startColor = new Color(snow.startColor.r, snow.startColor.g, snow.startColor.b, 0);
            inside = true;
            audioSource.Stop();
            /*for (int i = 0; i < food; i++)
            {
                Manager.instance.food++;
                //food = 0;
            }
            for (int i = 0; i < gas; i++)
            {
                Manager.instance.gas++;
                //gas = 0;
            }*/
            Manager.instance.UpdateResources();
            Manager.instance.changeDay();
        }

        if (collision.gameObject.tag == "food")
        {
            food++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "gas")
        {
            gas++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "npc")
        {
            Manager.instance.conversation.text = collision.gameObject.GetComponent<Npc>().line[Manager.instance.day];
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
        if (time >= timeToTemperature)
        {
            if (temperature < maxTemperature)
            {
                time = 0;
                temperature++;
            }
        }
    }
}
