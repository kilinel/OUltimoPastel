
using UnityEngine;

public class VoarPastel : MonoBehaviour
{
    [SerializeField] private float floatHeight = 0.25f;
    [SerializeField] private float floatSpeed = 2f;
    [SerializeField] private float rotationSpeed = 50f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        // Flutuar para cima e para baixo
        float offset = Mathf.Sin(Time.time * floatSpeed)
                       * floatHeight;

        transform.localPosition = startPosition
                                  + Vector3.up * offset;

        // Girar continuamente
        transform.Rotate(
            Vector3.up,
            rotationSpeed * Time.deltaTime,
            Space.Self
        );
    }
}
