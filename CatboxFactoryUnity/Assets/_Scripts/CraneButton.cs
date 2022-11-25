using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraneButton : MonoBehaviour
{
    private GameObject[] cranes;
    public Button buttonGreenCranes;
    public Button buttonRedCranes;
    public Button buttonBlueCranes;
    public TMP_Text textGreenCranes;
    public TMP_Text textRedCranes;
    public TMP_Text textBlueCranes;
    private bool greenCranesActive;
    private bool redCranesActive;
    private bool blueCranesActive;
    private float greenTextTimer;
    private float redTextTimer;
    private float blueTextTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (greenCranesActive)
        {
            greenTextTimer += Time.deltaTime;

            if (greenTextTimer >= 2f)
            {
                textGreenCranes.text = "Green Cranes";
                greenCranesActive = false;
                buttonGreenCranes.interactable = true;
                greenTextTimer = 0f;
            }
            else if (greenTextTimer >= 1f)
            {
                textGreenCranes.text = "1s...";
            }
        }

        if (redCranesActive)
        {
            redTextTimer += Time.deltaTime;

            if (redTextTimer >= 2f)
            {
                textRedCranes.text = "Red Cranes";
                redCranesActive = false;
                buttonRedCranes.interactable = true;
                redTextTimer = 0f;
            }
            else if (redTextTimer >= 1f)
            {
                textRedCranes.text = "1s...";
            }
        }

        if (blueCranesActive)
        {
            blueTextTimer += Time.deltaTime;

            if (blueTextTimer >= 2f)
            {
                textBlueCranes.text = "Blue Cranes";
                blueCranesActive = false;
                buttonBlueCranes.interactable = true;
                blueTextTimer = 0f;
            }
            else if (blueTextTimer >= 1f)
            {
                textBlueCranes.text = "1s...";
            }
        }
    }

    public void ClickedButtonGreen()
    {
        cranes = GameObject.FindGameObjectsWithTag("CraneGreen");
        
        foreach (GameObject crane in cranes)
        {
            crane.GetComponentInChildren<ActivateCrane>().ClickedCrane();
            greenCranesActive = true;
            buttonGreenCranes.interactable = false;
            textGreenCranes.text = "2s...";
        }
    }

    public void ClickedButtonRed()
    {
        cranes = GameObject.FindGameObjectsWithTag("CraneRed");

        foreach (GameObject crane in cranes)
        {
            crane.GetComponentInChildren<ActivateCrane>().ClickedCrane();
            redCranesActive = true;
            buttonRedCranes.interactable = false;
            textRedCranes.text = "2s...";
        }
    }

    public void ClickedButtonBlue()
    {
        cranes = GameObject.FindGameObjectsWithTag("CraneBlue");

        foreach (GameObject crane in cranes)
        {
            crane.GetComponentInChildren<ActivateCrane>().ClickedCrane();
            blueCranesActive = true;
            buttonBlueCranes.interactable = false;
            textBlueCranes.text = "2s...";
        }
    }
}
