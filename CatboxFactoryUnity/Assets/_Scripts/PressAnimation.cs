using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnimation : MonoBehaviour
{
    public float animationTime;
    public float animationDelay;
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", 1, "time", animationTime, "delay", animationDelay, "onupdate", "myUpdateFunction", "looptype", iTween.LoopType.pingPong));
    }
}
