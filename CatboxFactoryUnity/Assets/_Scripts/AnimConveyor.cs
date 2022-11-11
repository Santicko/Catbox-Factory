using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimConveyor : MonoBehaviour
{
    public float animSpeed = 1;
    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animSpeed = transform.root.GetComponentInChildren<ConveyorController>().gameSpeed * Time.time;
        rend.material.SetTextureOffset("_MainTex", new Vector2(-animSpeed/3, 0));
    }
}
