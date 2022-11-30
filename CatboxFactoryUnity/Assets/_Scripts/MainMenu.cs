using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool isActive;
    public int levelID;
    public GameObject StartMenu;
    public GameObject LevelSelect;

    public void OpenScene()
    {
        SceneManager.LoadScene("Level_" + levelID);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }

    public void BackButton()
    {
        if (isActive)
        {
            StartMenu.SetActive(true);
            LevelSelect.SetActive(false);
            isActive = false;
        }
        else
        {
            StartMenu.SetActive(false);
            LevelSelect.SetActive(true);
            isActive = true;
        }
    }
}