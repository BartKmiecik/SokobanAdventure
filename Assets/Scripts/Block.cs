using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        gm.AddBlock(gameObject);
    }
    public enum BlockMatch
    {
        red,
        blue,
        yellow,
        green
    }

    public BlockMatch matcher;

    public void CheckMatches(List<GameObject> listWithMatches, Vector3 dir)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, 1))
        {
            Block block = hit.collider.GetComponent<Block>();
            if(block == null)
            {
                return;
            }
            Block.BlockMatch matcher = block.matcher;
            if (matcher == this.matcher)
            {
                listWithMatches.Add(hit.collider.gameObject);
                block.CheckMatches(listWithMatches, dir);
            }
        }
    }

    private void OnDisable()
    {
        gm.RemoveBlock(gameObject);
    }
}
