using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    public static Queue<ICommand> commandsBuffer;
    public static List<ICommand> commandsHistory;
    public static int counter;
    private bool canUndo;

    private void Awake()
    {
        canUndo = true;
        commandsBuffer = new Queue<ICommand>();
        commandsHistory = new List<ICommand>();
    }

    private void OnDisable()
    {
        counter = 0;
        commandsHistory.Clear();
        commandsBuffer.Clear();
    }

    public static void AddCommand(ICommand command)
    {
        if(counter < commandsHistory.Count)
        {
            while(commandsHistory.Count > counter)
            {
                commandsHistory.RemoveAt(counter);
            }
        }
        commandsBuffer.Enqueue(command);
        command.Execute();
        commandsHistory.Add(command);
        ++counter;
    }

    public void UndoAction()
    {
        if (canUndo)
        {
            canUndo = false;
            StartCoroutine(UndoDeeley());
        }

    }

    IEnumerator UndoDeeley()
    {
        yield return new WaitForSeconds(.2f);
        if (counter > 0)
        {
            --counter;
            commandsHistory[counter].Undo();
        }
        canUndo = true;
    }
}
