using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationAtRandomFrame : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
    }

}
