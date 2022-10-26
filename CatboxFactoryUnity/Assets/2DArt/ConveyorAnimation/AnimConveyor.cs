using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimConveyor : MonoBehaviour
{
    public Material[] mat;
    public float animSpeed = 1;
    private float timer = 1;
    private Material myMat;
    private int matCount;


    // Start is called before the first frame update
    void Start()
    {
        myMat = GetComponent<MeshRenderer>().material;
        matCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        animSpeed = transform.root.GetComponentInChildren<ConveyorController>().gameSpeed * 4;
        if (timer > 0) { timer -= Time.deltaTime * animSpeed; }
        else
        {
            timer = 1;
            if (matCount != 10)
            {
                matCount++;
                myMat.mainTexture = mat[matCount].mainTexture;
            }
            else
            {
                matCount = 0;
                myMat.mainTexture = mat[matCount].mainTexture;
            }
        }
    }
}
