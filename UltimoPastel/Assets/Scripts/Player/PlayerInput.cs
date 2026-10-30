using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private ICommand moveCommand;
    private Vector2 touchStart;

    private void Awake()
    {
        if (player == null)
            player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.A))
            horizontal = -1f;

        if (Input.GetKey(KeyCode.D))
            horizontal = 1f;

        if (Input.GetKey(KeyCode.W))
            vertical = 1f;

        if (Input.GetKey(KeyCode.S))
            vertical = -1f;

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                touchStart = touch.position;
            Vector2 offset = Vector2.ClampMagnitude((touch.position - touchStart) / (Screen.height * 0.12f), 1f);
            direction = touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled
                ? Vector3.zero : new Vector3(offset.x, 0, offset.y);
        }

        moveCommand = new MoveCommand(player, direction);
        moveCommand.Execute();
    }
}
