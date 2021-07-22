using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StarsPopUp : MonoBehaviour
{
    public Ease ease;
    private void OnEnable()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1, 1).SetEase(ease).From(0).SetDelay(Random.Range(0, 1)));
        seq.Append(transform.DOShakeScale(1, .5f, 10, 90, false));
    }
}
