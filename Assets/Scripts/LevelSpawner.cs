using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelSpawner : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField] private GameObject dustParticles;
    [SerializeField] private List<GameObject> levelList = new List<GameObject>();
    private GameObject target;
    public Ease ease;
    public Ease ease2;
    public float duration;
    [SerializeField] private List<Transform> jumpBoxes = new List<Transform>();
    private ShowTutorial showTutorial;
    private void Awake()
    {
        showTutorial = GetComponent<ShowTutorial>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void SpawnLevel()
    {
        int level = PlayerPrefs.GetInt("Level");
        if(level > levelList.Count - 1)
        {
            level = 0;
            PlayerPrefs.SetInt("Level", level);
        }
        Sequence seq = DOTween.Sequence();

        if(target != null)
        {
            Destroy(target);
        }


        target = Instantiate(levelList[level]);

        seq.Append(target.transform.DOMoveY(0, duration, false)
            .SetEase(ease)
            .From(9)
            .OnComplete(() => JumpBox()))
            .Append(ChakeChilds());

        if (level == 0)
        {
            StartCoroutine(ShowTutorail());
        }
    }

    IEnumerator ShowTutorail()
    {
        yield return new WaitForSeconds(1.75f);
        showTutorial.ShowTutorialPanel();
    }

    public void RestartLevel()
    {
        foreach (Transform child in target.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        SpawnLevel();
    }

    private void JumpBox()
    {
        audioManager.Play("Start");
        Instantiate(dustParticles);
        foreach (Transform tr in jumpBoxes)
        {
            tr.DOShakeScale(1f, 1, 8, 90f, true);
        }
    }

    private Tween ChakeChilds()
    {
        for(int i = 0; i < target.transform.childCount; i++)
        {
            if (!target.transform.GetChild(i).CompareTag("UnShakable"))
            {
                target.transform.GetChild(i).DOShakeScale(1.5f, 1, 10, 90f, true);
            }
            
        }
        return null;
    }


}
