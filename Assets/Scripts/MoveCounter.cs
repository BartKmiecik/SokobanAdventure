using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoveCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI movesText;
    private bool isGameStarted;
    int moves;
    void Start()
    {
        moves = 0;
    }

    public void MakeMove()
    {
        ++moves;
        movesText.text = moves.ToString();
    }

    public void ResetMoves()
    {
        moves = 0;
        movesText.text = moves.ToString();
    }

    public int GetMovesCount()
    {
        return moves;
    }
}
