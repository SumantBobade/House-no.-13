using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform targetPoint;
    public float speed = 5f;

    private bool shouldMove = false;

    void Update()
    {
        if (!shouldMove) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint.position,
            speed * Time.deltaTime
        );
    }

    public void StartMoving()
    {
        shouldMove = true;
    }
}