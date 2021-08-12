using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private AdsManager adsManager;
    [SerializeField] private GameObject buttonsControll;
    private List<GameObject> blocksList = new List<GameObject>();
    private LevelSpawner levelSpawner;
    private GameObject endGamePanel;

    private bool isGameStart;
    private TimeCounter timeCounter;
    int currentLevel;
    private MoveCounter moveCounter;

    private AudioManager audioManager;
    
    private GameObject hints;
    public GameObject Hints
    {
        get { return hints; }
    }

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        moveCounter = FindObjectOfType<MoveCounter>();
        currentLevel = PlayerPrefs.GetInt("Level");
        timeCounter = FindObjectOfType<TimeCounter>();
        endGamePanel = GameObject.Find("EndGamePanel");
        endGamePanel.SetActive(false);
        levelSpawner = FindObjectOfType<LevelSpawner>();
        isGameStart = false;
    }

    private void Start()
    {
        adsManager = FindObjectOfType<AdsManager>();
        adsManager.SetGameManager(this);
        NextLevel();
    }


    public void RemoveBlock(GameObject obj)
    {
        blocksList.Remove(obj);
        if(blocksList.Count == 0 && isGameStart)
        {
            StartCoroutine(WinningMatch());
        }
    }

    public void PlayClickSound()
    {
        audioManager.Play("ClickSound");
    }

    IEnumerator WinningMatch()
    {
        yield return new WaitForSeconds(1f);
        audioManager.Play("Win");
        buttonsControll.SetActive(false);
        int moves = moveCounter.GetMovesCount();
        PlayerPrefs.SetInt($"Moves{currentLevel}", moves);

        int bestMoves = PlayerPrefs.GetInt($"BestMoves{currentLevel}", 9999);
        if(moves < bestMoves)
        {
            PlayerPrefs.SetInt($"BestMoves{currentLevel}", moves);
        }

        float time = timeCounter.GetTime();
        float bestTime = PlayerPrefs.GetFloat($"BestTime{currentLevel}", 9999);

        if(time < bestTime)
        {
            PlayerPrefs.SetFloat($"BestTime{currentLevel}", time);
        }
        PlayerPrefs.SetFloat($"CurrentTime{currentLevel}", time);


        timeCounter.SetGameState(false);
        endGamePanel.SetActive(true);
        endGamePanel.GetComponent<EndGamePanel>().Constructor(currentLevel);
        isGameStart = false;
        ++currentLevel;

        if (currentLevel > PlayerPrefs.GetInt("MaxLevel", 0))
        {
            PlayerPrefs.SetInt("MaxLevel", currentLevel);
        }
        PlayerPrefs.SetInt("Level", currentLevel);
    }

    public void AddBlock(GameObject obj)
    {
        blocksList.Add(obj);
    }

    public void RestartLevel()
    {
        audioManager.Play("ClickSound");
        buttonsControll.SetActive(true);
        isGameStart = false;
        levelSpawner.RestartLevel();
        isGameStart = true;
        timeCounter.SetGameState(true);
        moveCounter.ResetMoves();
    }

    public void NextLevel()
    {
        if(currentLevel > 1)
        {
            adsManager.ShowRewardedVideo();
        } else
        {
            BuildNextLevel();
        }
        
    }

    public void BuildNextLevel()
    {
        audioManager.Play("ClickSound");
        buttonsControll.SetActive(true);
        endGamePanel.SetActive(false);
        levelSpawner.SpawnLevel();
        isGameStart = true;
        timeCounter.SetGameState(true);
        moveCounter.ResetMoves();
    }

    public void BackToMenu()
    {
        audioManager.Play("ClickSound");
        moveCounter.ResetMoves();
        isGameStart = false;
        timeCounter.SetGameState(false);
        SceneManager.LoadScene(0);
    }

    public void SetHintsObject(GameObject obj)
    {
        if(obj != null)
        {
            hints = obj;
        }
    }

    public void ShowHideHints()
    {
        if(hints != null)
        {
            bool active = hints.activeInHierarchy;
            hints.SetActive(!active);
        }
    }
}
