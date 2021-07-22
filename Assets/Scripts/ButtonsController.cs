using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{

    [SerializeField] private ScriptableBool isMoving;
    private GridMovement gridMovement;
    private CheckGrid checkGrid;
    private ButtonsDelegator buttonsDelegator;
    private MoveCounter moveCounter;
    private bool forward, back, left, right;
    private void Awake()
    {
        checkGrid = GetComponent<CheckGrid>();
        gridMovement = GetComponent<GridMovement>();
        moveCounter = FindObjectOfType<MoveCounter>();
        buttonsDelegator = FindObjectOfType<ButtonsDelegator>();
        forward = back = left = right = false;
    }

    private void OnEnable()
    {
        buttonsDelegator.moveButton += MoveInDirection;
        buttonsDelegator.cancelMovement += CancelMovement;
    }

    private void OnDisable()
    {
        buttonsDelegator.moveButton -= MoveInDirection;
        buttonsDelegator.cancelMovement -= CancelMovement;
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;

        if (forward)
        {
            direction = Vector3.forward;
        } else if (back)
        {
            direction = Vector3.back;
        } else if (left)
        {
            direction = Vector3.left;
        } else if (right)
        {
            direction = Vector3.right;
        }

        if(direction != Vector3.zero)
        {
            if (!isMoving.value)
            {
                if (checkGrid.CheckIfCanMove(direction))
                {
                    isMoving.value = true;
                    ICommand command = new MoveCommand(gridMovement, direction);
                    CommandInvoker.AddCommand(command);
                    AddMove();
                }
            }
        }
    }

    

    /*
    private void MoveInDirection(Vector3 direction)
    {
        if (checkGrid.CheckIfCanMove(direction) && !isMoving.value)
        {
            if (direction == Vector3.forward)
            {
                ICommand command = new MoveCommand(gridMovement, Vector3.forward);
                CommandInvoker.AddCommand(command);
                AddMove();
                return;
            }
            if (direction == Vector3.back)
            {
                ICommand command = new MoveCommand(gridMovement, Vector3.back);
                CommandInvoker.AddCommand(command);
                AddMove();
                return;
            }
            if (direction == Vector3.left)
            {
                ICommand command = new MoveCommand(gridMovement, Vector3.left);
                CommandInvoker.AddCommand(command);
                AddMove();
                return;
            }
            if (direction == Vector3.right)
            {
                ICommand command = new MoveCommand(gridMovement, Vector3.right);
                CommandInvoker.AddCommand(command);
                AddMove();
                return;
            }
        }
        
    }

    */


    private void MoveInDirection(Vector3 direction)
    {
        if(direction == Vector3.forward)
        {
            forward = true;
        }
        if (direction == Vector3.back)
        {
            back = true;
        }
        if (direction == Vector3.left)
        {
            left = true;
        }
        if (direction == Vector3.right)
        {
            right = true;
        }
    }

    private void CancelMovement(Vector3 direction)
    {
        if (direction == Vector3.forward)
        {
            forward = false;
        }
        if (direction == Vector3.back)
        {
            back = false;
        }
        if (direction == Vector3.left)
        {
            left = false;
        }
        if (direction == Vector3.right)
        {
            right = false;
        }
    }


    private void AddMove()
    {
        if (moveCounter != null)
        {
            moveCounter.MakeMove();
        }
    }
}
