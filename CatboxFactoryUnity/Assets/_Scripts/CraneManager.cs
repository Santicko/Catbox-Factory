using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneManager : MonoBehaviour
{
    public GameObject selectedCrane;
    public GameObject[] craneList;

    public void Start()
    {
        craneList = GameObject.FindGameObjectsWithTag("CraneMinion");
    }

    public void Activate()
    {
        foreach (GameObject crane in craneList)
        {
            if (crane != selectedCrane)
            {
                crane.GetComponent<ActivateCrane>().RemovePlayer();
            } 
        }
    }
}
