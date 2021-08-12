using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssigneHintsToButton : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<GameManager>().SetHintsObject(this.gameObject);
    }

}
