using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject mapPrefab;
    private GameObject map;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnStartButton()
    {
        audioManager.Play("ClickSound");
        mainPanel.SetActive(false);
        map = Instantiate(mapPrefab, mainPanel.transform.parent);
    }

    public void OnMapSelectionButton(int level)
    {
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene(1);
    }

    public void FromMapSelectionToMainMenu()
    {
        Destroy(map);
        mainPanel.SetActive(true);
    }

    public void OnQuitButton()
    {
        audioManager.Play("ClickSound");
        Application.Quit();
    }


}
