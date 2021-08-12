using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BouncingArrow : MonoBehaviour
{
    private SpriteRenderer rend;
    private Collider col;
    public enum BouncingDirection
    {
        left,
        right,
        top,
        down
    }

    public BouncingDirection dir;
    Vector3 startingPos;

    private void Awake()
    {
        startingPos = transform.position;
        col = GetComponent<Collider>();
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
        col.enabled = false;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(DeleayStart());
    }
    
    IEnumerator DeleayStart()
    {
        rend.enabled = true;

        switch (dir)
        {
            case BouncingDirection.down:
                transform.DOMoveZ(-.3f + startingPos.z, 1f, false).From(.3f + startingPos.z, true, false).SetLoops(-1);
                break;
            case BouncingDirection.top:
                transform.DOMoveZ(.3f + startingPos.z, 1f, false).From(-.3f + startingPos.z, true, false).SetLoops(-1);
                break;
            case BouncingDirection.left:
                transform.DOMoveX(-.3f + startingPos.x, 1f, false).From(.3f + startingPos.x, true, false).SetLoops(-1);
                break;
            case BouncingDirection.right:
                transform.DOMoveX(.3f + startingPos.x, 1f, false).From(-.3f + startingPos.x, true, false).SetLoops(-1);
                break;
        }

        yield return new WaitForSeconds(.5f);
        col.enabled = true;
    }

    public IEnumerator DeleyDisplay()
    {
        StopCoroutine(DeleayStart());
        rend.enabled = false;
        yield return new WaitForSeconds(2f);
        switch (dir)
        {
            case BouncingDirection.down:
                transform.DOMoveZ(-.3f + startingPos.z, 1f, false).From(.3f + startingPos.z, true, false).SetLoops(-1);
                break;
            case BouncingDirection.top:
                transform.DOMoveZ(.3f + startingPos.z, 1f, false).From(-.3f + startingPos.z, true, false).SetLoops(-1);
                break;
            case BouncingDirection.left:
                transform.DOMoveX(-.3f + startingPos.x, 1f, false).From(.3f + startingPos.x, true, false).SetLoops(-1);
                break;
            case BouncingDirection.right:
                transform.DOMoveX(.3f + startingPos.x, 1f, false).From(-.3f + startingPos.x, true, false).SetLoops(-1);
                break;
        }

        rend.enabled = true;
        col.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
