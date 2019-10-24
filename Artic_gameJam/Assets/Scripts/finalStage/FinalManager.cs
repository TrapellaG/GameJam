using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalManager : MonoBehaviour {
    public static FinalManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public float time;


    public float timeToTalk;

    public float timeToTalkAgain;

    public float timeToDie;


    public FinalNpc finalNpc;


    public Text narration;

    public Image fade;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

        if (time >= timeToDie + 1)
        {
            SceneManager.LoadScene("FinalGameOver");
        }
        else if (time >= timeToDie)
        {
            fade.gameObject.SetActive(true);
        }
        else if(time >= timeToTalkAgain)
        {
            narration.text = finalNpc.line[1];
        }
        else if(time >= timeToTalk)
        {
            narration.text = finalNpc.line[0];
        }
    }
}
