using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.ShakeRotation(gameObject, iTween.Hash("x", 10, "amount", 10, "time", 1, "onupdate", "looptype", iTween.LoopType.pingPong));
    }

  
}
