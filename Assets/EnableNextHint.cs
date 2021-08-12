using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNextHint : MonoBehaviour
{
    [SerializeField] private GameObject nextHint;

    private void OnDestroy()
    {
        nextHint.SetActive(true);
    }
}
