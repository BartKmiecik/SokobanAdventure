using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoveCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI movesText;
    private EnableDisableHintsButton enableDisableHintsButton;
    private bool isGameStarted;
    private int moves;
    void Start()
    {
        enableDisableHintsButton = GetComponent<EnableDisableHintsButton>();
        moves = 0;
        enableDisableHintsButton.EnableHintButton();
    }

    public void MakeMove()
    {
        enableDisableHintsButton.DisableHintsButton();
        ++moves;
        movesText.text = moves.ToString();
    }

    public void ResetMoves()
    {
        moves = 0;
        movesText.text = moves.ToString();
        enableDisableHintsButton.EnableHintButton();
    }

    public int GetMovesCount()
    {
        return moves;
    }
}
