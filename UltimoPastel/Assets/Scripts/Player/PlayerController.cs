using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    public void Move(Vector3 direction)
    {
        moveDirection = Vector3.ClampMagnitude(direction, 1f);
    }

    private void FixedUpdate()
    {
        Vector3 movement = moveDirection * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }
}