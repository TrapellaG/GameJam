using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour {

    public Button toMenu;
    string menu = "MainMenu";

    // Use this for initialization
    void Start ()
    {
        Button btn1 = toMenu.GetComponent<Button>();
        btn1.onClick.AddListener(BackMenu);
    }
	
	void BackMenu()
    {
        Application.LoadLevel(menu);
    }
}
