using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
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
                hit.transform.parent.GetComponentInChildren<ActivateCrane>().ClickedCrane();
            }
            hit.transform.root.GetComponentInChildren<ShowSkin>().EnableSkin();
        } 
    }
}
