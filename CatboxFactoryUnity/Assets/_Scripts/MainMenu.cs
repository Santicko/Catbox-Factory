using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool secondGridIsActive;
    public int levelID;
    public GameObject StartMenu;
    public GameObject LevelSelect;
    public GameObject grid1;
    public GameObject grid2;
    public GameObject backButton;
    public TMP_Text nextPreviousText;

    public void NewGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Level_" + (PlayerPrefsController.levelsCleared + 1));
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }

    public void LevelSelectButton()
    {
        StartMenu.SetActive(false);
        LevelSelect.SetActive(true);
        grid1.SetActive(true);
        grid2.SetActive(false);
        backButton.SetActive(true);
    }

    public void NextPrevious()
    {
        if (secondGridIsActive)
        {
            grid1.SetActive(true);
            grid2.SetActive(false);
            secondGridIsActive = false;
            nextPreviousText.text = "Next Page";
        }
        else
        {
            grid1.SetActive(false);
            grid2.SetActive(true);
            secondGridIsActive = true;
            nextPreviousText.text = "Previous Page";
        }
    }

    public void BackButton()
    {
        StartMenu.SetActive(true);
        LevelSelect.SetActive(false);
        backButton.SetActive(false);
    }
}