using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    private string levelName;
    private int levelNumber;
    

    // Start is called before the first frame update
    void Start()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        levelName = scene.name;
        string[] x = levelName.Split('_');

        levelNumber = int.Parse(x[1]);
    }

    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("Level_" + (levelNumber+1));
    }

    public void LevelClick()
    {
        string levelButtonName = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("Level_" + levelButtonName);
    }
}
