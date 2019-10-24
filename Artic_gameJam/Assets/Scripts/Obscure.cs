using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obscure : MonoBehaviour
{
    public float duration;

    public Image whiteFade;
    // Start is called before the first frame update
    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(0.0f);

        fadein();
    }

    // Update is called once per frame
    public void fadein()
    {
        whiteFade.CrossFadeAlpha(1, duration, false);
    }
}
