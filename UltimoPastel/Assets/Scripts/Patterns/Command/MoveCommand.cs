using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MoveCommand : ICommand
{
    private PlayerController player;
    private Vector3 direction;

    public MoveCommand(PlayerController player, Vector3 direction)
    {
        this.player = player;
        this.direction = direction;
    }

    public void Execute()
    {
        player.Move(direction);
    }
}