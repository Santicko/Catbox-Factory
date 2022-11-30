using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBlinkiing : MonoBehaviour
{
    private float timer;
    private float destroyTimer;
    public GameObject button;
    public Button buttonBlinking;
    public Button Cam1button;
    public Button Cam1buttonActive;
    public Button Cam2button;
    public Button Cam2buttonActive;
    public GameObject Cam1;
    public GameObject Cam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            buttonBlinking.GetComponent<RawImage>().enabled = true;
            Cam2button.GetComponent<RawImage>().enabled = false;
        }
        if (timer >= 5.5f)
        {
            buttonBlinking.GetComponent<RawImage>().enabled = false;
            Cam2button.GetComponent<RawImage>().enabled = true;
            timer = 4.5f;
        }
        if (destroyTimer >= 10f)
        {
            Destroy(button);
        }
    }

    public void ButtonClicked()
    {
        Cam1button.GetComponent<RawImage>().enabled = true;
        Cam1buttonActive.GetComponent<RawImage>().enabled = false;
        Cam2buttonActive.GetComponent<RawImage>().enabled = true;
        Cam1.SetActive(false);
        Cam2.SetActive(true);
        Destroy(button);
    }
}
