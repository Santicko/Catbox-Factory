using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private Material mat;
    public float life;
    public float colorLife;
    private int rnd;
    private int size;
    private float alpha;

    // Start is called before the first frame update
    void Start()
    {
        life = 1f;
        gameObject.AddComponent<Rigidbody>();
        mat = GetComponent<Renderer>().material;
        mat.color = Color.red;
        rnd = Random.Range(1, 5);
        size = rnd;
        transform.localScale = new Vector3(size, size, size);
        alpha = 255;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Destroy(gameObject);
        }
        if (life > 0)
        {
            if (colorLife <= 255)
            {
                if (life < 2)
                {
                    alpha -= Time.deltaTime;
                }
                colorLife += (Time.deltaTime * 2);
                mat.color = new Color(colorLife * rnd, colorLife * rnd / 2, colorLife * rnd / 4, alpha);
            }
            life -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
