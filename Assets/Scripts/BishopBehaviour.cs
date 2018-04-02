using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopBehaviour : ChessItem {

    private BoardInteractivity BI;

    void Start()
    {
        BI = GameObject.Find("Board").GetComponent<BoardInteractivity>();
    }

    public override bool[,] PossibleMoves(int x, int y)
    {
        bool[,] possibleMoves = new bool[8, 8];

        for (int i = 1; i < 8; i++)
        {
            if (x + i < 8 && y + i < 8)
            {
                if (BI.GO_AR_BoardPieces[x + i, y + i] == null)
                {
                    possibleMoves[x + i, y + i] = true;
                }
                else
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x + i, y + i].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x + i, y + i] = true;
                    }
                    break;
                }
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (x + i < 8 && y - i >= 0)
            {
                if (BI.GO_AR_BoardPieces[x + i, y - i] == null)
                {
                    possibleMoves[x + i, y - i] = true;
                }
                else
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x + i, y - i].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x + i, y - i] = true;
                    }
                    break;
                }
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (x - i >= 0 && y + i < 8)
            {
                if (BI.GO_AR_BoardPieces[x - i, y + i] == null)
                {
                    possibleMoves[x - i, y + i] = true;
                }
                else
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x - i, y + i].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x - i, y + i] = true;
                    }
                    break;
                }
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (x - i >= 0 && y - i >= 0)
            {
                if (BI.GO_AR_BoardPieces[x - i, y - i] == null)
                {
                    possibleMoves[x - i, y - i] = true;
                }
                else
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x - i, y - i].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x - i, y - i] = true;
                    }
                    break;
                }
            }
        }

        return possibleMoves;
    }
}
