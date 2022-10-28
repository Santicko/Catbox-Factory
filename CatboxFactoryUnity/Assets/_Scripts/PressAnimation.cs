using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", 1, "time", 0.5f, "delay", 0.5f, "onupdate", "myUpdateFunction", "looptype", iTween.LoopType.pingPong));
    }
}
