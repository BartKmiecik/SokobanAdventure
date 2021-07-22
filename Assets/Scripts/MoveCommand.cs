using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    Vector3 targetPosition;
    IMovement gridMovement;

    public MoveCommand(IMovement gridMovement, Vector3 target)
    {
        this.gridMovement = gridMovement;
        this.targetPosition = target;
        
    }
    public void Execute()
    {
        gridMovement.MovePlayer(targetPosition);
    }

    public void Undo()
    {
        gridMovement.MovePlayer(-targetPosition);
    }
}
