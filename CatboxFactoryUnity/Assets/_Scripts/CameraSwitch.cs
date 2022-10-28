using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public GameObject Cam0;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;

    public Button Cam1button;
    public Button Cam2button;
    public Button Cam3button;
    public Button Cam1buttonActive;
    public Button Cam2buttonActive;
    public Button Cam3buttonActive;

    private void Start()
    {

    }

    public void Camera1()
    {
        Cam1.SetActive(true);
        Cam1button.GetComponent<RawImage>().enabled = false;
        Cam1buttonActive.GetComponent<RawImage>().enabled = true;

        Cam2.SetActive(false);
        Cam2button.GetComponent<RawImage>().enabled = true;
        Cam2buttonActive.GetComponent<RawImage>().enabled = false;

        Cam3.SetActive(false);
        Cam3button.GetComponent<RawImage>().enabled = true;
        Cam3buttonActive.GetComponent<RawImage>().enabled = false;
    }

    public void Camera2()
    {
        Cam1.SetActive(false);
        Cam1button.GetComponent<RawImage>().enabled = true;
        Cam1buttonActive.GetComponent<RawImage>().enabled = false;

        Cam2.SetActive(true);
        Cam2button.GetComponent<RawImage>().enabled = false;
        Cam2buttonActive.GetComponent<RawImage>().enabled = true;

        Cam3.SetActive(false);
        Cam3button.GetComponent<RawImage>().enabled = true;
        Cam3buttonActive.GetComponent<RawImage>().enabled = false;
    }

    public void Camera3()
    {
        Cam1.SetActive(false);
        Cam1button.GetComponent<RawImage>().enabled = true;
        Cam1buttonActive.GetComponent<RawImage>().enabled = false;

        Cam2.SetActive(false);
        Cam2button.GetComponent<RawImage>().enabled = true;
        Cam2buttonActive.GetComponent<RawImage>().enabled = false;

        Cam3.SetActive(true);
        Cam3button.GetComponent<RawImage>().enabled = false;
        Cam3buttonActive.GetComponent<RawImage>().enabled = true;
    }

    public void Camera0()
    {
        Cam0.SetActive(true);
        Cam1.SetActive(false);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
    }
}
