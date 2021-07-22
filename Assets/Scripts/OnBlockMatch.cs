using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBlockMatch : ICommand
{
    List<GameObject> objList = new List<GameObject>();

    public OnBlockMatch(List<GameObject> obj)
    {
        this.objList = obj;
    }
    public void Execute()
    {
        foreach(GameObject obj in objList)
        {
            obj.SetActive(false);
        }
    }

    public void Undo()
    {
        foreach (GameObject obj in objList)
        {
            obj.SetActive(true);
        }
    }
}
