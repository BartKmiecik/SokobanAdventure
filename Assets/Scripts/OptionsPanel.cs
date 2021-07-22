using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsPanel : MonoBehaviour
{
    private bool buttonsControl, swipeControl;
    [SerializeField] private Toggle butonTog, swipeTog;
    [SerializeField] private ScriptableBool swipeController;
    [SerializeField] private GameObject buttonsController;

    [SerializeField] private Slider musicSlider, effectsSlider;
    private AudioManager audioManager;
    [SerializeField] private GameObject gameUI;
    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        if(gameUI != null)
        {
            gameUI.SetActive(false);
        }
        
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("ClickSound");
        int buttonCont = PlayerPrefs.GetInt("ButtonsControl", 1);
        int swipeCont = PlayerPrefs.GetInt("SwipeControl", 1);
        musicSlider.value = PlayerPrefs.GetFloat("Music", 1);
        effectsSlider.value = PlayerPrefs.GetFloat("Effects", 1);

        buttonsControl = buttonCont == 1;
        swipeControl = swipeCont == 1;

        butonTog.isOn = buttonsControl;
        swipeTog.isOn = swipeControl;
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        if (gameUI != null)
        {
            gameUI.SetActive(true);
        }

        audioManager.Play("ClickSound");
        Time.timeScale = 1;
    }

    public void ButtonsControlOnOff()
    {
        audioManager.Play("ClickSound");
        buttonsControl = butonTog.isOn;
        int control = buttonsControl ? 1 : 0;
        PlayerPrefs.SetInt("ButtonsControl", control);
        if(buttonsController!= null)
        {
            buttonsController.SetActive(buttonsControl);
        }
    }

    public void SwipeControlOnOff()
    {
        audioManager.Play("ClickSound");
        swipeControl = swipeTog.isOn;
        int control = swipeControl ? 1 : 0;
        PlayerPrefs.SetInt("SwipeControl", control);
        swipeController.value = swipeControl;
    }

    public void ChangeMusicVolume()
    {
        audioManager.SetMusicVolume(musicSlider.value);
    }

    public void ChangeEffectsVolume()
    {
        audioManager.SetEffectsVolume(effectsSlider.value);
    }
}
