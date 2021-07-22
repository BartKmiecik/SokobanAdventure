using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchChecker : MonoBehaviour
{
    private List<GameObject> matchedBlocksListVertical = new List<GameObject>();
    private List<GameObject> matchedBLocksListHorizontal = new List<GameObject>();
    private Block blockScript;
    private AudioManager audioManager;
    private void Awake()
    {
        blockScript = GetComponent<Block>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void CheckAll()
    {
        matchedBLocksListHorizontal.Clear();
        matchedBlocksListVertical.Clear();
        matchedBlocksListVertical.Add(gameObject);
        matchedBLocksListHorizontal.Add(gameObject);
        blockScript.CheckMatches(matchedBlocksListVertical, Vector3.forward);
        blockScript.CheckMatches(matchedBlocksListVertical, Vector3.back);
        blockScript.CheckMatches(matchedBLocksListHorizontal, Vector3.left);
        blockScript.CheckMatches(matchedBLocksListHorizontal, Vector3.right);
        StartCoroutine(DestroyMatches());
    }

    IEnumerator DestroyMatches()
    {
        
        yield return null;
        // Create separate script to destroy block, implement ICommand interface, play animation and sound
        if(matchedBlocksListVertical.Count >= 3)
        {
            ICommand command = new OnBlockMatch(matchedBlocksListVertical);
            CommandInvoker.AddCommand(command);
            audioManager.Play(blockScript.matcher.ToString());
        }
        if (matchedBLocksListHorizontal.Count >= 3)
        {
            ICommand command = new OnBlockMatch(matchedBLocksListHorizontal);
            CommandInvoker.AddCommand(command);
            audioManager.Play(blockScript.matcher.ToString());
        }
    }
}
