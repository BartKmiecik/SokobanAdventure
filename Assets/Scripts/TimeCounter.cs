using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    private bool isGameStarted;
    float time;


    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            time += Time.deltaTime;
            int seconds = (int)time % 60;
            int minutes = (int)time / 60;

            if (minutes > 0)
            {
                timeText.text = minutes.ToString() + ":" + seconds.ToString() + "m";
            }
            else
            {
                timeText.text = seconds.ToString() + "s";
            }
        }
    }

    public void SetGameState(bool state)
    {
        isGameStarted = state;
        time = 0;
    }

    public float GetTime()
    {
        return time;
    }
}
