using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnDelay = 1;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0) { timer -= Time.deltaTime; }
        if(timer <= 0)
        {
            Instantiate(objectToSpawn,transform);
            timer = spawnDelay;
        }
    }
}
