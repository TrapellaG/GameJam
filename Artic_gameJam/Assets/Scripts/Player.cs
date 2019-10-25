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
    public AudioSource pickup;

    public float time = 0;
    public float timeToTemperature = 1;
    bool die;
    float timeToDie = 3;
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

        if (Manager.instance.day > 0)
        {
            if (inside == true)
            {
                IncreaseTemperature();
            }
            else
                DecreaseTemperature();
        }
                

        if (!inside)
        {
            //if it is the first day...
            if (Manager.instance.day == 0)
            {
                Day0();
            }
            else if (Manager.instance.day > 0)
            {
                Day1();
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
            }
            
            if (temperature <= 0)
            {
                animator.SetTrigger("dead");
                timeToDie -= Time.deltaTime;
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

        if(timeToDie <=0)
        {
            SceneManager.LoadScene("GameOver");
        }
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

            gameObject.GetComponent<SpriteRenderer>().color = new Color(
                gameObject.GetComponent<SpriteRenderer>().color.r,
                gameObject.GetComponent<SpriteRenderer>().color.g,
                gameObject.GetComponent<SpriteRenderer>().color.b,
                1f);
        }
        else if (collision.gameObject.tag == "Inside")
        {
            inside = true;
            audioSource.Stop();

            gameObject.GetComponent<SpriteRenderer>().color = new Color(
                gameObject.GetComponent<SpriteRenderer>().color.r,
                gameObject.GetComponent<SpriteRenderer>().color.g,
                gameObject.GetComponent<SpriteRenderer>().color.b,
                0);

            Manager.instance.UpdateResources();
            Manager.instance.changeDay();
        }

        if (collision.gameObject.tag == "food")
        {
            food++;
            Destroy(collision.gameObject);
            pickup.Play();
        }
        else if (collision.gameObject.tag == "gas")
        {
            gas++;
            Destroy(collision.gameObject);
            pickup.Play();
        }
        else if (collision.gameObject.tag == "npc")
        {
            Manager.instance.conversation.text = collision.gameObject.GetComponent<Npc>().line[Manager.instance.day];
        }


    }

    public void dead()
    {
        animator.SetBool("dead", true);

        if (timeToDie <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void DecreaseTemperature()
    {
        if (time >= timeToTemperature)
        {
            time = 0;
            temperature--;
            audioSource.volume += 0.03f;
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
                audioSource.volume -= 0.03f;
            }
        }
    }

    void Day0()
    {
        snow.gameObject.SetActive(false);
        audioSource.gameObject.SetActive(false);
        thermometer.instance.gameObject.SetActive(false);
    }

    //we deactivate the snowfall, the breathing and the thermometer
    void Day1()
    {
        snow.gameObject.SetActive(true);
        audioSource.gameObject.SetActive(true);
        thermometer.instance.gameObject.SetActive(true);
    }
}
