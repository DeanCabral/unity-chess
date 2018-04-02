using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessItem : MonoBehaviour {

    public bool isWhitePiece;
    public bool isKing;
    public bool isQueen;
    public bool isBishop;
    public bool isKnight;
    public bool isRook;
    public bool isPawn;	

    public virtual bool[,] PossibleMoves(int x, int y)
    {
        return new bool[8, 8];
    }

}
