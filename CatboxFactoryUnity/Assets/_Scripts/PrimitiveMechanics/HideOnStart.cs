using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    // Disable the Mesh component to hide the texture on launch. this is used to hide hitboxes in game
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
