using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ScriptableBool isMoving;
    private float threshold = 0.9f;
    private GridMovement gridMovement;
    private CheckGrid checkGrid;
    [SerializeField] private Joystick joystick;
    private void Awake()
    {

        checkGrid = GetComponent<CheckGrid>();
        gridMovement = GetComponent<GridMovement>();
    }
    void Update()
    {
        if (!isMoving.value)
        {
            KeybordMovement();
        }
    }

    private void KeybordMovement()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) >= Mathf.Abs(Input.GetAxisRaw("Vertical")))
        {
            if (Input.GetAxisRaw("Horizontal") < -threshold)
            {
                if (checkGrid.CheckIfCanMove(Vector3.left))
                {
                    ICommand command = new MoveCommand(gridMovement, Vector3.left);
                    CommandInvoker.AddCommand(command);
                }
            }
            if (Input.GetAxisRaw("Horizontal") > threshold)
            {
                if (checkGrid.CheckIfCanMove(Vector3.right))
                {
                    ICommand command = new MoveCommand(gridMovement, Vector3.right);
                    CommandInvoker.AddCommand(command);
                }
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") < -threshold)
            {
                if (checkGrid.CheckIfCanMove(Vector3.back))
                {
                    ICommand command = new MoveCommand(gridMovement, Vector3.back);
                    CommandInvoker.AddCommand(command);
                }
            }
            if (Input.GetAxisRaw("Vertical") > threshold)
            {
                if (checkGrid.CheckIfCanMove(Vector3.forward))
                {
                    ICommand command = new MoveCommand(gridMovement, Vector3.forward);
                    CommandInvoker.AddCommand(command);
                }
            }
        }
    }

}
