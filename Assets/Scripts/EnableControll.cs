using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableControll : MonoBehaviour
{
    private SwipeController swipeController;
    private ButtonsController buttonsController;
    private float waitingTime = 1f;
    private void Awake()
    {
        swipeController = GetComponent<SwipeController>();
        buttonsController = GetComponent<ButtonsController>();
    }

    private void OnEnable()
    {
        StartCoroutine(DelayController());
    }

    IEnumerator DelayController()
    {
        swipeController.enabled = false;
        buttonsController.enabled = false;
        yield return new WaitForSeconds(waitingTime);
        swipeController.enabled = true;
        buttonsController.enabled = true;
    }
}
