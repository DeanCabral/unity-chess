using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnBehaviour : ChessItem {

    private BoardInteractivity BI;

    void Start()
    {       
        BI = GameObject.Find("Board").GetComponent<BoardInteractivity>();
    }

    public override bool[,] PossibleMoves(int x, int y)
    {
        bool[,] possibleMoves = new bool[8, 8];

        if (isWhitePiece)
        {
            if (x != 0 && y != 7)
            {
                if (BI.GO_AR_BoardPieces[x - 1, y + 1] != null)
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x - 1, y + 1].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x - 1, y + 1] = true;
                    }                    
                }
            }

            if (x != 0 && y != 0)
            {
                if (BI.GO_AR_BoardPieces[x - 1, y - 1] != null)
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x - 1, y - 1].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x - 1, y - 1] = true;
                    }                    
                }
            }

            if (x == 6)
            {
                if (BI.GO_AR_BoardPieces[x - 1, y] == null && BI.GO_AR_BoardPieces[x - 2, y] == null)
                {
                    possibleMoves[x - 2, y] = true;
                }
            }

            if (x != 0)
            {
                if (BI.GO_AR_BoardPieces[x - 1, y] == null)
                {
                    possibleMoves[x - 1, y] = true;
                }
            }
        }
        else
        {
            if (x != 7 && y != 7)
            {
                if (BI.GO_AR_BoardPieces[x + 1, y + 1] != null)
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x + 1, y + 1].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x + 1, y + 1] = true;
                    }                    
                }
            }

            if (x != 7 && y != 0)
            {
                if (BI.GO_AR_BoardPieces[x + 1, y - 1] != null)
                {
                    bool targetWhite = BI.GO_AR_BoardPieces[x + 1, y - 1].GetComponent<ChessItem>().isWhitePiece;
                    if (isWhitePiece != targetWhite)
                    {
                        possibleMoves[x + 1, y - 1] = true;
                    }                    
                }
            }

            if (x == 1)
            {
                if (BI.GO_AR_BoardPieces[x + 1, y] == null && BI.GO_AR_BoardPieces[x + 2, y] == null)
                {
                    possibleMoves[x + 2, y] = true;
                }
            }

            if (x != 7)
            {
                if (BI.GO_AR_BoardPieces[x + 1, y] == null)
                {
                    possibleMoves[x + 1, y] = true;
                }
            }                        
        }

        return possibleMoves;
    }

}
