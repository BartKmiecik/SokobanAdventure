using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText, bestTime, movesText, bestMoves;
    [SerializeField] private List<ScriptableLevelTreshold> tresholdsLevels = new List<ScriptableLevelTreshold>();
    [SerializeField] private GameObject star2, star3;
    [SerializeField] private Sprite disactivestar, activeStar;
    [SerializeField] private GameObject gameUI;

    private void OnDisable()
    {
        gameUI.SetActive(true);
    }

    private void OnEnable()
    {
        gameUI.SetActive(false);
    }
    public void Constructor(int level)
    {
        FormatTime(level);
        FormatBestTime(level);
        movesText.text = "Moves: " + PlayerPrefs.GetInt($"Moves{level}").ToString();
        bestMoves.text = "Best moves: " + PlayerPrefs.GetInt($"BestMoves{level}").ToString();
        PopStars(level);
    }

    private void FormatTime(int level)
    {
        float time = PlayerPrefs.GetFloat($"CurrentTime{level}");
        int seconds = (int)time % 60;
        int minutes = (int)time / 60;

        if (minutes > 0)
        {
            timeText.text = "Time: " + minutes.ToString() + ":" + seconds.ToString() + "m";
        }
        else
        {
            timeText.text = "Time: " + seconds.ToString() + "s";
        }
    }

    private void FormatBestTime(int level)
    {
        float time = PlayerPrefs.GetFloat($"BestTime{level}");
        int seconds = (int)time % 60;
        int minutes = (int)time / 60;

        if (minutes > 0)
        {
            bestTime.text = "Best time: " + minutes.ToString() + ":" + seconds.ToString() + "m";
        }
        else
        {
            bestTime.text = "Best time: " + seconds.ToString() + "s";
        }
    }

    private void PopStars(int level)
    {
        int moves = PlayerPrefs.GetInt($"Moves{level}");
        float time = PlayerPrefs.GetFloat($"CurrentTime{level}");

        if(moves <= tresholdsLevels[level].moves3Stars && time <= tresholdsLevels[level].time3Stars)
        {
            star3.GetComponent<Image>().sprite = activeStar;
            star2.GetComponent<Image>().sprite = activeStar;
            return;
        }

        if (moves <= tresholdsLevels[level].moves2Stars && time <= tresholdsLevels[level].times2Stars)
        {
            star3.GetComponent<Image>().sprite = disactivestar;
            star2.GetComponent<Image>().sprite = activeStar;
            return;
        }

        star3.GetComponent<Image>().sprite = disactivestar;
        star2.GetComponent<Image>().sprite = disactivestar;
    }

}
