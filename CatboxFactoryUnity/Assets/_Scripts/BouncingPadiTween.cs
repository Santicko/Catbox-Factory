using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPadiTween : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        iTween.MoveTo(gameObject, iTween.Hash("movetopath", "x", 9, "time", 4, "delay", 1, "onupdate", "myUpdateFunction", "looptype", iTween.LoopType.none));
    }
}
