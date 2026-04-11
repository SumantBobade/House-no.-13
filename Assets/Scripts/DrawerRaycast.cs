using UnityEngine;
using UnityEngine.UI;

public class DrawerRaycast : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public Text status;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        status.gameObject.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            DrawerOpening drawer = hit.collider.GetComponent<DrawerOpening>();

            if (drawer != null)
            {
                status.gameObject.SetActive(true);
                status.text = drawer.IsOpen() ? "Press E to Close" : "Press E to Open";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    drawer.ToggleDrawer();
                }

                return;
            }
        }

        status.gameObject.SetActive(false);
    }
}