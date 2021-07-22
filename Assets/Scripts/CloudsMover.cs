using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CloudsMover : MonoBehaviour
{
    [SerializeField] private Vector3 startingPos1;
    [SerializeField] private GameObject cloud1, cloud2;
    void Start()
    {
        cloud1.transform.DOMoveX(50, 100, false)
            .From(startingPos1)
            .SetLoops(-1);

        cloud2.transform.DOMoveX(150, 120, false)
            .From(startingPos1)
            .SetLoops(-1);
    }


}
