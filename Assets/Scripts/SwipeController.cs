using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private ScriptableBool isMoving;
    [SerializeField] private ScriptableBool swipeController;
    private Swipe swipe;
    private CheckGrid checkGrid;
    private GridMovement gridMovement;
    private MoveCounter moveCounter;
    private void Start()
    {
        moveCounter = FindObjectOfType<MoveCounter>();
        swipe = GetComponent<Swipe>();
        checkGrid = GetComponent<CheckGrid>();
        gridMovement = GetComponent<GridMovement>();
        swipeController.value = PlayerPrefs.GetInt("SwipeControl", 1) == 1 ? true : false;
    }

    private void Update()
    {
        if(Time.timeScale != 0 && swipeController.value)
        {
            if (!isMoving.value)
            {
                if (swipe.SwipeLeft && checkGrid.CheckIfCanMove(Vector3.left))
                {
                    ICommand command = new MoveCommand(gridMovement, Vector3.left);
                    CommandInvoker.AddCommand(command);
                    AddMove();
                }
                if (swipe.SwipeRight && checkGrid.CheckIfCanMove(Vector3.right))
                {
                    ICommand command = new MoveCommand(gridMovement, Vector3.right);
                    CommandInvoker.AddCommand(command);
                    AddMove();
                }
                if (swipe.SwipeUp && checkGrid.CheckIfCanMove(Vector3.forward))
                {
                    ICommand command = new MoveCommand(gridMovement, Vector3.forward);
                    CommandInvoker.AddCommand(command);
                    AddMove();
                }
                if (swipe.SwipeDown && checkGrid.CheckIfCanMove(Vector3.back))
                {
                    ICommand command = new MoveCommand(gridMovement, Vector3.back);
                    CommandInvoker.AddCommand(command);
                    AddMove();
                }
            }
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
