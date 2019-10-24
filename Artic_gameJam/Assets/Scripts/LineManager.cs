using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

    public static LineManager instance = null;

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

    //round will increase with each day, so that npcs can choose their correct line as time goes by
    public int round;
    public string[][] lines;
    
    private void Start()
    {
        lines = new string[5][];
        for (int i = 0; i < 5; i++)
        {
            lines[i] = new string[5];
            for (int j = 0; j < 5; j++)
            {
                lines[i][j] = "We need to go";
                Debug.Log(lines[i][j]);
            }
        }

        
        
    }

}
