using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float maxTemperature = 36.5f;
    public int food;
    public int gas;

    public GameObject gasCanister;
    public GameObject gasText;

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
        

        if (!inside)
        {
            if (Manager.instance.day == 0)
            {
                Day0();
            }
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

            if (temperature < 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        
        myRB.velocity = new Vector2(horizontal * speed, vertical * speed);
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

    void Day0()
    {
        snow.gameObject.SetActive(false);
        audioSource.gameObject.SetActive(false);
        thermometer.instance.gameObject.SetActive(false);
    }
}
