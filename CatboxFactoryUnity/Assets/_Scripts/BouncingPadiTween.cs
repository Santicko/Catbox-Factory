using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPadiTween : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", -1, "time", 4, "delay", 1, "onupdate", "myUpdateFunction", "looptype", iTween.LoopType.none));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
