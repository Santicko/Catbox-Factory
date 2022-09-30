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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static PlayerLives Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
