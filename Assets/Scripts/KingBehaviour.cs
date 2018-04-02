using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingBehaviour : ChessItem {

    private BoardInteractivity BI;

    void Start()
    {
        BI = GameObject.Find("Board").GetComponent<BoardInteractivity>();
    }

    public override bool[,] PossibleMoves(int x, int y)
    {
        bool[,] possibleMoves = new bool[8, 8];

        if (x + 1 < 8)
        {
            if (BI.GO_AR_BoardPieces[x + 1, y] == null)
            {
                possibleMoves[x + 1, y] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x + 1, y].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x + 1, y] = true;
                }
            }
        }
        if (x - 1 >= 0)
        {
            if (BI.GO_AR_BoardPieces[x - 1, y] == null)
            {
                possibleMoves[x - 1, y] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x - 1, y].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x - 1, y] = true;
                }
            }
        }
        if (y + 1 < 8)
        {
            if (BI.GO_AR_BoardPieces[x, y + 1] == null)
            {
                possibleMoves[x, y + 1] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x, y + 1].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x, y + 1] = true;
                }
            }
        }
        if (y - 1 >= 0)
        {
            if (BI.GO_AR_BoardPieces[x, y - 1] == null)
            {
                possibleMoves[x, y - 1] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x, y - 1].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x, y - 1] = true;
                }
            }
        }
        if (x + 1 < 8 && y - 1 >= 0)
        {
            if (BI.GO_AR_BoardPieces[x + 1, y - 1] == null)
            {
                possibleMoves[x + 1, y - 1] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x + 1, y - 1].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x + 1, y - 1] = true;
                }
            }
        }
        if (x + 1 < 8 && y + 1 < 8)
        {
            if (BI.GO_AR_BoardPieces[x + 1, y + 1] == null)
            {
                possibleMoves[x + 1, y + 1] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x + 1, y + 1].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x + 1, y + 1] = true;
                }
            }
        }
        if (x - 1 >= 0 && y - 1 >= 0)
        {
            if (BI.GO_AR_BoardPieces[x - 1, y - 1] == null)
            {
                possibleMoves[x - 1, y - 1] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x - 1, y - 1].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x - 1, y - 1] = true;
                }
            }
        }
        if (x - 1 >= 0 && y + 1 < 8)
        {
            if (BI.GO_AR_BoardPieces[x - 1, y + 1] == null)
            {
                possibleMoves[x - 1, y + 1] = true;
            }
            else
            {
                bool targetWhite = BI.GO_AR_BoardPieces[x - 1, y + 1].GetComponent<ChessItem>().isWhitePiece;
                if (isWhitePiece != targetWhite)
                {
                    possibleMoves[x - 1, y + 1] = true;
                }
            }
        }       

        return possibleMoves;
    }

}
