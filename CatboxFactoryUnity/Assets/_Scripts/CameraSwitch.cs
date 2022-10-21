using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public GameObject Cam1;

    public GameObject Cam2;

    public GameObject Cam3;

    public void Camera1()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
    }

    public void Camera2()
    {
        
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            Cam3.SetActive(false);
        
    }

    public void Camera3()
    {
        
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(true);
        
    }
}
