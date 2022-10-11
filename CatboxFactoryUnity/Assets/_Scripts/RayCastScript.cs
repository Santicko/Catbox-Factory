using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastScript : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;

    private GameObject selected = null;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
  
        if (Physics.Raycast(ray, out hit, 100, mask))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Crane")
            {
                selected = hit.transform.gameObject;
                selected.transform.parent.GetComponentInChildren<ActivateCrane>().ShowButtons();
            } else if (Input.GetMouseButtonDown(0) && hit.transform.tag != "Crane")
            {
                selected.transform.parent.GetComponentInChildren<ActivateCrane>().HideButtons();
            }
            hit.transform.root.GetComponentInChildren<ShowSkin>().EnableSkin();
        }
    }
}
