using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrid : MonoBehaviour
{
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.left);
        Gizmos.DrawRay(transform.position, Vector3.right);
        Gizmos.DrawRay(transform.position, Vector3.forward);
        Gizmos.DrawRay(transform.position, Vector3.back);
    }
    public bool CheckIfCanMove(Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, 1))
        {
            if (hit.collider.CompareTag("PushableObject"))
            {
                RaycastHit hitFromNewPoint;
                if (Physics.Raycast(hit.collider.gameObject.transform.position, direction, out hitFromNewPoint, 1))
                {
                    if(hitFromNewPoint.collider != null)
                    {
                        return false;
                    }
                } else
                {
                    ICommand command = new MoveCommand(hit.collider.gameObject.GetComponent<IMovement>(), direction);
                    CommandInvoker.AddCommand(command);
                    audioManager.Play("Walk");
                    return true;
                }
            }
            return false;
        }
        audioManager.Play("Walk");
        return true;
    }
}
