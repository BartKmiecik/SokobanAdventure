using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPanel : MonoBehaviour
{
    [SerializeField] private GameObject firstScreen, secondScreen, thirdScreen, fourthScreen;

    private void OnEnable()
    {
        Time.timeScale = 0;
        firstScreen.SetActive(true);
        secondScreen.SetActive(false);
        thirdScreen.SetActive(false);
        fourthScreen.SetActive(false);
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
