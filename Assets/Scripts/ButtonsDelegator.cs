using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsDelegator : MonoBehaviour
{
    [SerializeField] private ScriptableBool isMoving;
    public delegate void ButtonsDelegate(Vector3 direction);
    public ButtonsDelegate moveButton;
    public ButtonsDelegate cancelMovement;

    private void Start()
    {
        moveButton += DummyMethod;
        cancelMovement += DummyMethod;
    }

    private void DummyMethod(Vector3 direction)
    {

    }


    public void MoveForward()
    {
        if (!isMoving.value)
        {
            moveButton(Vector3.forward);
        }
    }
    
    public void CancelMoveForward()
    {
        cancelMovement(Vector3.forward);
    }

    public void MoveBack()
    {
        if (!isMoving.value)
        {
            moveButton(Vector3.back);
        }
    }

    public void CancelMoveBack()
    {
        cancelMovement(Vector3.back);
    }

    public void MoveLeft()
    {
        if (!isMoving.value)
        {
            moveButton(Vector3.left);
        }
    }

    public void CancelMoveLeft()
    {
        cancelMovement(Vector3.left);
    }

    public void MoveRight()
    {
        if (!isMoving.value)
        {
            moveButton(Vector3.right);
        }
    }

    public void CancelMoveRight()
    {
        cancelMovement(Vector3.right);
    }

}
