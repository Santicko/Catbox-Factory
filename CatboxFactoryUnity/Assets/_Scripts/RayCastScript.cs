using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastScript : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;

    private GameObject selected = null;
    private GameObject oldSelected = null;

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

    /*public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private string selectableTag = "Selectable";
        [SerializeField] private Material highlightMaterial;

        private Material originalMaterial;

        private GameObject selected = null;
        private GameObject oldSelected = null;

        private Renderer selectionRenderer;
        private Renderer oldSelectionRenderer;

        // Update is called once per frame
        void Update()
        {
            //change the color to the highlight
            if (Input.GetMouseButtonDown(0))
            {
                //if selected set to highlight color
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 300.0f))
                {
                    selected = hit.transform.gameObject;
                    Debug.Log("1111 new Selection --> " + selected);

                    if (selected.CompareTag(selectableTag))
                    {
                        //newSelection
                        if (selected != oldSelected)
                        {
                            //Set original material to oldSelected if it's not the first selection
                            if (oldSelected != null)
                            {
                                oldSelectionRenderer = oldSelected.GetComponent<Renderer>();
                                oldSelectionRenderer.material = originalMaterial;
                            }

                            //Set highlighted material to selected
                            selectionRenderer = selected.GetComponent<Renderer>();
                            originalMaterial = selectionRenderer.material;
                            selectionRenderer.material = highlightMaterial;

                            //assign oldSelected GO to your current selection
                            oldSelected = selected;
                        }
                    }
                }
            }
        }
    }*/
}
