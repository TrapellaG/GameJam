using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obscure : MonoBehaviour
{
    public float duration;

    public Image whiteFade;
    public Text text;
    // Start is called before the first frame update
    /*void Start()
    {
        if (!whiteFade)
        {
            fadeinText();
        }
        else
            fadein();
    }*/

    private void OnEnable()
    {
        if (!whiteFade)
        {
            fadeinText();
        }
        else
            fadein();
    }

    // Update is called once per frame
    public void fadein()
    {
        whiteFade.canvasRenderer.SetAlpha(0.0f);
        whiteFade.CrossFadeAlpha(1, duration, false);
    }

    public void fadeinText()
    {
        text.canvasRenderer.SetAlpha(0.0f);
        text.CrossFadeAlpha(1, duration, false);
    }
}
