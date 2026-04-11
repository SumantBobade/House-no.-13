using UnityEngine;
using UnityEngine.UI;

public class DrawerOpening : MonoBehaviour
{
    public Transform drawer;
    public float openDistance = 1f;
    public float speed = 2f;

    private Vector3 closedPos;
    private Vector3 openPos;

    private bool isOpen = false;

    void Start()
    {
        closedPos = drawer.localPosition;
        openPos = closedPos + new Vector3(0, -openDistance, 0);
    }

    void Update()
    {
        // Animate drawer
        drawer.localPosition = Vector3.Lerp(
            drawer.localPosition,
            isOpen ? openPos : closedPos,
            Time.deltaTime * speed
        );
    }

    public void ToggleDrawer()
    {
        isOpen = !isOpen;
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}