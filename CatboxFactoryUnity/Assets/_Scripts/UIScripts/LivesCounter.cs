using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesCounter : MonoBehaviour
{

    public int life;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "" + life;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
