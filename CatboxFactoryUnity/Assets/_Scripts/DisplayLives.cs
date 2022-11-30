using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayLives : MonoBehaviour
{
    private string text;
    public GameObject lifeCounter;


    // Start is called before the first frame update
    void Start()
    {
        lifeCounter = GameObject.FindGameObjectWithTag("LifeCounter");
    }

    // Update is called once per frame
    void Update()
    {
        text = "x " + lifeCounter.GetComponent<PlayerLives>().life;
        GetComponent<TextMeshProUGUI>().text = text;       
    }
}
