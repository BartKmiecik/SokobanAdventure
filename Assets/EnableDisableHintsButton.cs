using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnableDisableHintsButton : MonoBehaviour
{
    [SerializeField] private Button hintButton;
    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void EnableHintButton()
    {
        hintButton.interactable = true;
    }

    public void DisableHintsButton()
    {
        if (gm.Hints.activeInHierarchy)
        {
            return;
        }
        hintButton.interactable = false;
    }
}
