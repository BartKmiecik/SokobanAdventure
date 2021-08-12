using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleyFirstHint : MonoBehaviour
{
    private List<BouncingArrow> hintToDeeley = new List<BouncingArrow>();

    private void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            BouncingArrow ba = transform.GetChild(i).GetComponent<BouncingArrow>();
            if(ba != null)
            {
                hintToDeeley.Add(ba);
            }
        }
    }

    private void Start()
    {
        foreach(BouncingArrow ba in hintToDeeley)
        {
            ba.StopAllCoroutines();
            StartCoroutine(ba.DeleyDisplay());
        }
    }
}
