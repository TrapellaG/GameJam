using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public static Manager instance = null;

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
    }

    public int day;

    public GameObject[] npc;

    public int necesaryGas;
    public Text gasMeter;
    public Image gas;

    public int necesaryFood;
    public Text foodMeter;

    public Text conversation;
    public float converationLifetime;

    public bool transition;
    public float time;
    public GameObject transitionScreen;
    public GameObject transitionText;

    public Text timer;

    public float timeToDie = 5;

    // Use this for initialization
    void Start () {
        conversation.text = "";
        UpdateResources();
        npc = new GameObject[4];

        SetLevel();
	}

    private void Update()
    {

        if (conversation.text != "")
        {
            converationLifetime += Time.deltaTime;

            if (converationLifetime > 10)
            {
                conversation.text = "";
                converationLifetime = 0;
            }
        }

        if (transition == true)
        {
            transitionScreen.SetActive(true);
            //transitionScreen.GetComponent<Obscure>().fadein();

            time += Time.deltaTime;

            if (time > 6)
            {
                UpdateResources();

                if (day > 1)
                {
                    SceneManager.LoadScene("Final");
                }
                transitionScreen.SetActive(false);
                transitionText.SetActive(false);
                time = 0;
                transition = false;
                
                SetLevel();
            }
            else if (time > 2)
            {
                Player.instance.snow.gameObject.SetActive(true);

                transitionText.GetComponent<Text>().text = "Day " + (day + 1).ToString();
                transitionText.SetActive(true);
            }

        }

    }

    public void changeDay () {

        if (day == 0)
        {
            if (Player.instance.food > 0)
            {
                Player.instance.food -= necesaryFood;


                transition = true;
                day++;

                Timer.instance.time = Timer.instance.maxTime;
            }
        }
        else
        {
            if (Timer.instance.time <= 0)
            {
                if (Player.instance.gas < necesaryGas)
                {
                    Player.instance.dead();
                    time = 0;
                    if (time >= timeToDie)
                        GameOver();
                }
                else if (Player.instance.food < necesaryFood)
                {
                    Player.instance.dead();
                    GameOver();
                }   
            }
            else if (Player.instance.gas >= necesaryGas)
            {
                if (Player.instance.food >= necesaryFood)
                {
                    day++;

                    transition = true;
                }
            }
        }
	}

    public void UpdateResources()
    {
        gasMeter.text = Player.instance.gas.ToString() + "/" + necesaryGas.ToString();
        foodMeter.text = Player.instance.food.ToString() + "/" + necesaryFood.ToString();
    }

    public void SetLevel()
    {
        if (day == 0)
        {
            gasMeter.gameObject.SetActive(false);
            gas.gameObject.SetActive(false);
            timer.gameObject.SetActive(false);
        }
        else
        {
            gasMeter.gameObject.SetActive(true);
            gas.gameObject.SetActive(true);
            timer.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
