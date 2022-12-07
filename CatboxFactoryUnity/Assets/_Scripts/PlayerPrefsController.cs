using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsController : MonoBehaviour
{
    public static int levelsCleared;
    public GameObject [] levelButton;
    public GameObject newGameButton;
    public GameObject continueGameButton;


    // Start is called before the first frame update
    void Start()
    {
        levelsCleared = PlayerPrefs.GetInt("levelsCleared");

        if (levelsCleared < 12)
        {
            for (int i = 0; i < levelsCleared + 1; i++)
            {
                levelButton[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                levelButton[i].GetComponent<Button>().interactable = true;
            }
        }

        else
        {
            for (int i = 0; i < levelsCleared; i++)
            {
                levelButton[i].GetComponent<Button>().interactable = true;
            }
        }

            for (int i = 0; i < levelsCleared; i++)
        {
            levelButton[i].GetComponent<Image>().color = new Color32(119, 231, 121, 255);
        }

        if (levelsCleared > 0)
        {
            newGameButton.SetActive(false);
            continueGameButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
