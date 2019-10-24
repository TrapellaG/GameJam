using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeOut : MonoBehaviour
{

    public Image whiteFade;
    // Start is called before the first frame update
    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(1.0f);

        fadeout();
    }

    // Update is called once per frame
    void fadeout()
    {
        whiteFade.CrossFadeAlpha(0, 1, false);
    }
}
