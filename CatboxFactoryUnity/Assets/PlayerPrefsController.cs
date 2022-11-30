using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    public static int levelsCleared;
    public GameObject [] levelButton;


    // Start is called before the first frame update
    void Start()
    {
        levelsCleared = PlayerPrefs.GetInt("levelsCleared");

        for (int i = 0; i < levelsCleared+1; i++)
        {
            levelButton[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
