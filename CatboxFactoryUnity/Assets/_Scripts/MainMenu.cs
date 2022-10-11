using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int levelID;

    public void OpenScene()
    {
        SceneManager.LoadScene("Lvl" + levelID);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }
}