using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGridMovement : MonoBehaviour, IMovement 
{
    [SerializeField] private ScriptableBool isMoving;
    private float movingTime = .2f;
    private Vector3 orignalPos, targetPos;
    private MatchChecker checker;
    void Start()
    {
        checker = GetComponent<MatchChecker>();
        isMoving.value = false;
    }

    public void MovePlayer(Vector3 direction)
    {
        StartCoroutine(MovePlayerCoroutina(direction));
    }

    private IEnumerator MovePlayerCoroutina(Vector3 direction)
    {
        isMoving.value = true;

        float elapsedTime = 0f;

        orignalPos = transform.position;
        targetPos = orignalPos + direction;

        while (elapsedTime < movingTime)
        {
            transform.position = Vector3.Lerp(orignalPos, targetPos, (elapsedTime / movingTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving.value = false;
        if(checker != null)
        {
            checker.CheckAll();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.left);
        Gizmos.DrawRay(transform.position, Vector3.right);
        Gizmos.DrawRay(transform.position, Vector3.forward);
        Gizmos.DrawRay(transform.position, Vector3.back);
    }
}
