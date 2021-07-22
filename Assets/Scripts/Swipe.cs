using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipteRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    private bool isDragging;
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipteRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

    private void Start()
    {
        isDragging = false;
    }
    private void Update()
    {
        tap = swipeLeft = swipteRight = swipeUp = swipeDown = false;

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
            isDragging = true;
        } else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        swipeDelta = Vector2.zero;

        if(isDragging)
        {
            if(Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            } else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if(swipeDelta.magnitude > 50)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x < 0)
                {
                    swipeLeft = true;
                } else
                {
                    swipteRight = true;
                }
            } else
            {
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }

            //Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }
}
