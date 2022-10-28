using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPadiTween : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        iTween.MoveTo(other.tag == "Player", iTween.Hash("x", 9, "time", 4, "delay", 1, "onupdate", "myUpdateFunction", "looptype", iTween.LoopType.none));
    }
}
