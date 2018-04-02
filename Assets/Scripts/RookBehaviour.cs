using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookBehaviour : ChessItem {

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
            if (x + i < 8)
            {
                if (BI.GO_AR_BoardPieces[x + i, y] == null)
                {
                    possibleMoves[x + i, y] = true;
                }
                else
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x + i, y].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x + i, y] = true;
                    }
                    break;
                }
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (x - i >= 0)
            {
                if (BI.GO_AR_BoardPieces[x - i, y] == null)
                {
                    possibleMoves[x - i, y] = true;
                }
                else
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x - i, y].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x - i, y] = true;
                    }
                    break;
                }
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (y + i < 8)
            {
                if (BI.GO_AR_BoardPieces[x, y + i] == null)
                {
                    possibleMoves[x, y + i] = true;
                }
                else
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x, y + i].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x, y + i] = true;
                    }
                    break;
                }
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (y - i >= 0)
            {
                if (BI.GO_AR_BoardPieces[x, y - i] == null)
                {
                    possibleMoves[x, y - i] = true;
                }
                else
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x, y - i].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x, y - i] = true;
                    }
                    break;
                }
            }
        }

        return possibleMoves;
    }

}
