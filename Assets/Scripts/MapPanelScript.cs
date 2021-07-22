using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MapPanelScript : MonoBehaviour
{
    private MainMenu mainMenu;
    [SerializeField] private Transform spawningPoint;
    [SerializeField] private GameObject mapButtonPrefab;
    [SerializeField] private Sprite discoveredSprite;
    private int levelsCount = 40;

    void Start()
    {
        mainMenu = GameObject.FindObjectOfType<MainMenu>();
        int discoveredLevels = PlayerPrefs.GetInt("MaxLevel", 0);

        for(int i = 0; i < levelsCount; i++)
        {
            GameObject temp = Instantiate(mapButtonPrefab, spawningPoint);
            temp.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            if(i <= discoveredLevels)
            {
                temp.GetComponent<Image>().sprite = discoveredSprite;
                temp.AddComponent<Button>().onClick.AddListener(() =>mainMenu.OnMapSelectionButton(temp.transform.GetSiblingIndex()));

            }
        }
    }

    public void BackToMenu()
    {
        mainMenu.FromMapSelectionToMainMenu();
    }

}
