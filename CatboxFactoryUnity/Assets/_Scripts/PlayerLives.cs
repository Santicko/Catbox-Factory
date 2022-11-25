using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public int life = 9;

    // Start is called before the first frame update
    void Start()
    {
        life = 9;
        if (Application.platform == RuntimePlatform.WebGLPlayer) { GameObject.Find("quitButton").gameObject.SetActive(false); }
    }

    private void Update()
    {
        transform.parent = null;
    }


    public static PlayerLives Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
