using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorial : MonoBehaviour
{
    [SerializeField] private GameObject gameUIPanel, tutorialPanel;

    public void ShowTutorialPanel()
    {
        gameUIPanel.SetActive(false);
        tutorialPanel.SetActive(true);
    }
}
