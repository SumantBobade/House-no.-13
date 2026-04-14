using UnityEngine;

public class CeilingMonster : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2f;
    public float detectDistance = 5f;
    public LayerMask playerLayer;

    private int currentPoint = 0;
    private Rigidbody rb;
    private bool isDropping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        transform.position = patrolPoints[0].position;
    }

    void Update()
    {
        if (!isDropping)
        {
            Patrol();
            DetectPlayerBelow();
        }
    }

    void Patrol()
    {
        Transform target = patrolPoints[currentPoint];

        // Move
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // Direction
        Vector3 dir = (target.position - transform.position).normalized;

        if (dir != Vector3.zero)
        {
            // 🔥 IMPORTANT: Keep monster inverted while rotating
            transform.rotation = Quaternion.LookRotation(dir) * Quaternion.Euler(180f, 0f, 0f);
        }

        // Switch point
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void DetectPlayerBelow()
    {
        RaycastHit hit;

        // ✅ Always use world DOWN (not transform.down)
        if (Physics.Raycast(transform.position, Vector3.down, out hit, detectDistance, playerLayer))
        {
            Drop();
        }

        Debug.DrawRay(transform.position, Vector3.down * detectDistance, Color.red);
    }

    void Drop()
    {
        isDropping = true;

        // Optional: small delay for horror effect
        Invoke(nameof(EnableGravity), 0.3f);
    }

    void EnableGravity()
    {
        rb.useGravity = true;
    }
}