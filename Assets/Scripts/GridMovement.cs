using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour, IMovement
{
    [SerializeField] private ScriptableBool isMoving;
    [SerializeField] private Transform graphix;
    private Animator anim;
    private Vector3 origPos, newPos;
    private float time = .2f;

    private void Start()
    {
        anim = graphix.GetComponent<Animator>();
    }
    public void MovePlayer(Vector3 direction)
    {
        Rotate(direction);
        StartCoroutine(MovePlayerEnumarator(direction));
    }

    IEnumerator MovePlayerEnumarator(Vector3 direction)
    {
        isMoving.value = true;

        anim.SetBool("Run Forward", true);
        float elapsedTime = 0f;

        origPos = transform.position;
        newPos = origPos + direction;

        while(elapsedTime < time)
        {
            transform.position = Vector3.Lerp(origPos, newPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;  
            yield return null;   
        }

        transform.position = newPos;

        isMoving.value = false;
        anim.SetBool("Run Forward", false);
    }

    private void Rotate(Vector3 direction)
    {
        if(direction == Vector3.forward)
        {
            graphix.rotation = Quaternion.Euler(-20, 0, 0);
        }
        if (direction == Vector3.back)
        {
            graphix.rotation = Quaternion.Euler(-40, 180, 0);
        }
        if (direction == Vector3.left)
        {
            graphix.rotation = Quaternion.Euler(-40, -90, 0);
        }
        if (direction == Vector3.right)
        {
            graphix.rotation = Quaternion.Euler(-40, 90, 0);
        }
    }


}
