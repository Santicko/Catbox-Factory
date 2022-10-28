using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;

    public Button Cam1button;
    public Button Cam2button;
    public Button Cam3button;

    private void Start()
    {
        Cam1button.GetComponent<Image>().color = new Color(0.3f, 1f, 0.8f, 1);
    }

    public void Camera1()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        if (Cam3 != null)
        {
            Cam3.SetActive(false);
        }

        Cam1button.GetComponent<Image>().color = new Color(0.3f, 1f, 0.8f, 1);
        Cam2button.GetComponent<Image>().color = Color.white;
        Cam3button.GetComponent<Image>().color = Color.white;
    }

    public void Camera2()
    {
        Cam1.SetActive(false);
        Cam2.SetActive(true);
        if (Cam3 != null)
        {
            Cam3.SetActive(false);
        }

        Cam1button.GetComponent<Image>().color = Color.white;
        Cam2button.GetComponent<Image>().color = new Color(0.3f, 1f, 0.8f, 1);
        Cam3button.GetComponent<Image>().color = Color.white;

    }

    public void Camera3()
    {
        Cam1.SetActive(false);
        Cam2.SetActive(false);
        if (Cam3 != null)
        {
            Cam3.SetActive(true);
        }

        Cam1button.GetComponent<Image>().color = Color.white;
        Cam2button.GetComponent<Image>().color = Color.white;
        Cam3button.GetComponent<Image>().color = new Color(0.3f, 1f, 0.8f, 1);
    }
}
