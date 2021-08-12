using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssigneHintsToButton : MonoBehaviour
{
    [SerializeField] private GameObject hints;
    void Start()
    {
        FindObjectOfType<GameManager>().SetHintsObject(hints);
    }

}
