using UnityEngine;

public class CupboardDoor : MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 2f;

    private Quaternion closedRot;
    private Quaternion openRot;

    private bool isOpen = false;

    void Start()
    {
        closedRot = transform.localRotation;
        openRot = closedRot * Quaternion.Euler(0,0, openAngle);
    }

    void Update()
    {
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            isOpen ? openRot : closedRot,
            Time.deltaTime * speed
            );
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
