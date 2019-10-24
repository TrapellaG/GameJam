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

    public int necesaryFood;
    public Text foodMeter;

    public Text conversation;
    public float converationLifetime;

    public bool transition;
    public float time;
    public GameObject transitionScreen;
    public GameObject transitionText;

    // Use this for initialization
    void Start () {
        conversation.text = "";
        UpdateResources();
        npc = new GameObject[4];
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
                transitionScreen.SetActive(false);
                transitionText.SetActive(false);
                time = 0;
                transition = false;
            }
            else if (time > 2)
            {
                transitionText.GetComponent<Text>().text = "Day " + day.ToString();
                transitionText.SetActive(true);
                //transitionText.GetComponent<Obscure>().fadeinText();
            }

        }

    }

    public void changeDay () {
        if (Timer.instance.time <= 0)
        {
            if (Player.instance.gas < necesaryGas)
            {
                GameOver();
            }
            else if (Player.instance.food < necesaryFood)
            {
                GameOver();
            }

            Player.instance.food -= necesaryFood;
            Player.instance.gas -= necesaryGas;

            UpdateResources();

            Timer.instance.maxTime -= 10;
            Timer.instance.time = Timer.instance.maxTime;

            day++;
        }
	}

    public void UpdateResources()
    {
        gasMeter.text = Player.instance.gas.ToString() + "/" + necesaryGas.ToString();
        foodMeter.text = Player.instance.food.ToString() + "/" + necesaryFood.ToString();
    }

    public void SetLevel()
    {
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
