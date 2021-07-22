using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledEffects : MonoBehaviour
{
    [SerializeField] private GameObject effects;
    private Block block;
    
    private void Awake()
    {
        block = GetComponent<Block>();

    }

    private void OnDisable()
    {
        Instantiate(effects, transform.position, Quaternion.identity);
    }
}
