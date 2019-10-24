using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Button playButton;
    public Button controlsButton;
    string level = "SampleScene";
    public Button exitButton;
    public GameObject panel;

    // Use this for initialization
    void Start ()
    {
        Button btn1 = playButton.GetComponent<Button>();
        Button btn2 = controlsButton.GetComponent<Button>();
        Button btn3 = exitButton.GetComponent<Button>();

        btn1.onClick.AddListener(PlayGame);
        btn2.onClick.AddListener(ShowControls);
        btn3.onClick.AddListener(ExitGame);
    }
	
	void PlayGame()
    {
        Application.LoadLevel(level);
    }

    void ShowControls()
    {
        panel.SetActive(!panel.activeSelf);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
