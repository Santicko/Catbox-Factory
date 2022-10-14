using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticLifeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("StaticLifeCounter") != null )
        {
            // It is here!
        }
        else
        {
            Instantiate(go, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
