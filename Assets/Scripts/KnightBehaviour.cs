using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBehaviour : ChessItem {

    private BoardInteractivity BI;

    void Start()
    {
        BI = GameObject.Find("Board").GetComponent<BoardInteractivity>();
    }

    public override bool[,] PossibleMoves(int x, int y)
    {
        bool[,] possibleMoves = new bool[8, 8];

        // Up-Right
        if (x + 2 < 8 && y + 1 < 8)
        {
            if (BI.GO_AR_BoardPieces[x + 2, y + 1] == null)
            {
                possibleMoves[x + 2, y + 1] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x + 2, y + 1].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x + 2, y + 1] = true;
                }
            }
        }
        // Up-Left
        if (x + 2 < 8 && y - 1 >= 0)
        {
            if (BI.GO_AR_BoardPieces[x + 2, y - 1] == null)
            {
                possibleMoves[x + 2, y - 1] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x + 2, y - 1].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x + 2, y - 1] = true;
                }
            }
        }
        // Right-Up
        if (x + 1 < 8 && y + 2 < 8)
        {
            if (BI.GO_AR_BoardPieces[x + 1, y + 2] == null)
            {
                possibleMoves[x + 1, y + 2] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x + 1, y + 2].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x + 1, y + 2] = true;
                }
            }
        }
        // Right-Down
        if (x - 1 >= 0 && y + 2 < 8)
        {
            if (BI.GO_AR_BoardPieces[x - 1, y + 2] == null)
            {
                possibleMoves[x - 1, y + 2] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x - 1, y + 2].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x - 1, y + 2] = true;
                }
            }
        }
        // Down-Right
        if (x - 2 >= 0 && y + 1 < 8)
        {
            if (BI.GO_AR_BoardPieces[x - 2, y + 1] == null)
            {
                possibleMoves[x - 2, y + 1] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x - 2, y + 1].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x - 2, y + 1] = true;
                }
            }
        }
        // Down-Left
        if (x - 2 >= 0 && y - 1 >= 0)
        {
            if (BI.GO_AR_BoardPieces[x - 2, y - 1] == null)
            {
                possibleMoves[x - 2, y - 1] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x - 2, y - 1].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x - 2, y - 1] = true;
                }
            }
        }
        // Left-Up
        if (x + 1 < 8 && y - 2 >= 0)
        {
            if (BI.GO_AR_BoardPieces[x + 1, y - 2] == null)
            {
                possibleMoves[x + 1, y - 2] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x + 1, y - 2].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x + 1, y - 2] = true;
                }
            }
        }
        // Left-Down
        if (x - 1 >= 0 && y - 2 >= 0)
        {
            if (BI.GO_AR_BoardPieces[x - 1, y - 2] == null)
            {
                possibleMoves[x - 1, y - 2] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x - 1, y - 2].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x - 1, y - 2] = true;
                }
            }
        }              

        return possibleMoves;
    }

}
