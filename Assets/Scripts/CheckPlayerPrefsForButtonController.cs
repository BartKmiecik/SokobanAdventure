using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerPrefsForButtonController : MonoBehaviour
{
    private void OnEnable()
    {
        int buttonCont = PlayerPrefs.GetInt("ButtonsControl", 1);
        bool active = buttonCont == 1 ? true : false;
        gameObject.SetActive(active);
    }
}
