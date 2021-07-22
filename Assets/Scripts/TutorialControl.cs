using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialControl : MonoBehaviour
{
    [SerializeField] private Transform fingerTransform;
    [SerializeField] private List<Image> buttonsImages = new List<Image>();
    [SerializeField] private Color deselected, selected;
    void Start()
    {
        FingerMovement();
        StartCoroutine(ButtonsBlinkers());
    }

    private void FingerMovement()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(fingerTransform.DOLocalMoveX(-210, 2f, false));
        seq.Append(fingerTransform.DOLocalMoveX(-500, 2f, false)
            .OnComplete(() => FingerMovement()));
    }

    IEnumerator ButtonsBlinkers()
    {
        while (true)
        {
            for(int i = 0; i < buttonsImages.Count; i++)
            {
                buttonsImages[i].color = selected;
                yield return new WaitForSeconds(.5f);
                buttonsImages[i].color = deselected;
                yield return new WaitForSeconds(.5f);
            }
            yield return new WaitForSeconds(2f);
        }
    }

}
