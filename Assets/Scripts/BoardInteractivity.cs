using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInteractivity : MonoBehaviour {

    public GameObject GO_tile;
    public GameObject[] GO_AR_Pieces;
    public GameObject[,] GO_AR_Tiles;
    public GameObject[,] GO_AR_BoardPieces;
    private GameObject selectedPiece;
    public Material mSelectedMat;
    public Material mEnemyMat;
    public Material mPotentialMat;
    public Material mTransparentMat;
    private GameManager GM;
    private bool[,] possibleMoves;
    private int selectedX;
    private int selectedY;
    private int currentX;
    private int currentY;
    public int pawnPromotionType;
    public bool whiteTurn;

    // Use this for initialization
    void Start () {
        
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        pawnPromotionType = -1;
        GenerateBoard();
	}
	
	// Update is called once per frame
	void Update () {

        UserInput();
	}

    private void GenerateBoard()
    {
        // Initialise board tiles, pieces and boolean arrays
        GO_AR_Tiles = new GameObject[8, 8];
        GO_AR_BoardPieces = new GameObject[8, 8];
        possibleMoves = new bool[8,8];

        // Procedurally generate tile game objects, and assign their positions to the SingleTile component
        Vector3 origin = new Vector3(-40.53f, 7.4f, -31.5f);
        Vector3 startOrigin = origin;

        for (int x = 0; x < GO_AR_Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < GO_AR_Tiles.GetLength(1); y++)
            {
                GO_tile.name = "Tile[" + x + "," + y + "]";
                GO_tile.GetComponent<SingleTile>().posX = x;
                GO_tile.GetComponent<SingleTile>().posY = y;
                GO_AR_Tiles[x, y] = Instantiate(GO_tile, new Vector3(origin.x + 9, origin.y, origin.z), Quaternion.identity);
                GO_AR_Tiles[x, y].transform.SetParent(transform);
                origin = GO_AR_Tiles[x, y].transform.position;
            }

            startOrigin.z += 9;
            origin = startOrigin;
        }

        // Load chess pieces onto board
        LoadPieces();
    }

    private void LoadPieces()
    {
        selectedPiece = null;

        // King and Queen
        GO_AR_BoardPieces[0,4] = Instantiate(GO_AR_Pieces[0], GO_AR_Tiles[0,4].transform.position, Quaternion.identity);
        GO_AR_BoardPieces[0,3] = Instantiate(GO_AR_Pieces[1], GO_AR_Tiles[0,3].transform.position, Quaternion.identity);
        // Bishops
        GO_AR_BoardPieces[0,5] = Instantiate(GO_AR_Pieces[2], GO_AR_Tiles[0,5].transform.position, Quaternion.identity);
        GO_AR_BoardPieces[0,2] = Instantiate(GO_AR_Pieces[2], GO_AR_Tiles[0,2].transform.position, Quaternion.identity);
        // Knights
        GO_AR_BoardPieces[0,6] = Instantiate(GO_AR_Pieces[3], GO_AR_Tiles[0,6].transform.position, Quaternion.identity);
        GO_AR_BoardPieces[0,1] = Instantiate(GO_AR_Pieces[3], GO_AR_Tiles[0,1].transform.position, Quaternion.Euler(0, 180, 0));
        // Rooks
        GO_AR_BoardPieces[0,7] = Instantiate(GO_AR_Pieces[4], GO_AR_Tiles[0,7].transform.position, Quaternion.identity);
        GO_AR_BoardPieces[0,0] = Instantiate(GO_AR_Pieces[4], GO_AR_Tiles[0,0].transform.position, Quaternion.identity);
        // Pawns
        for (int i = 0; i < 8; i++)
            GO_AR_BoardPieces[1, i] = Instantiate(GO_AR_Pieces[5], GO_AR_Tiles[1, i].transform.position, Quaternion.identity);

        // King and Queen
        GO_AR_BoardPieces[7, 4] = Instantiate(GO_AR_Pieces[6], GO_AR_Tiles[7, 4].transform.position, Quaternion.identity);
        GO_AR_BoardPieces[7, 3] = Instantiate(GO_AR_Pieces[7], GO_AR_Tiles[7, 3].transform.position, Quaternion.identity);
        // Bishops
        GO_AR_BoardPieces[7, 5] = Instantiate(GO_AR_Pieces[8], GO_AR_Tiles[7, 5].transform.position, Quaternion.identity);
        GO_AR_BoardPieces[7, 2] = Instantiate(GO_AR_Pieces[8], GO_AR_Tiles[7, 2].transform.position, Quaternion.identity);
        // Knights
        GO_AR_BoardPieces[7, 6] = Instantiate(GO_AR_Pieces[9], GO_AR_Tiles[7, 6].transform.position, Quaternion.identity);
        GO_AR_BoardPieces[7, 1] = Instantiate(GO_AR_Pieces[9], GO_AR_Tiles[7, 1].transform.position, Quaternion.Euler(0, 180, 0));
        // Rooks
        GO_AR_BoardPieces[7, 7] = Instantiate(GO_AR_Pieces[10], GO_AR_Tiles[7, 7].transform.position, Quaternion.identity);
        GO_AR_BoardPieces[7, 0] = Instantiate(GO_AR_Pieces[10], GO_AR_Tiles[7, 0].transform.position, Quaternion.identity);
        // Pawns
        for (int i = 0; i < 8; i++)
            GO_AR_BoardPieces[6, i] = Instantiate(GO_AR_Pieces[11], GO_AR_Tiles[6, i].transform.position, Quaternion.identity);
    }

    private void UserInput()
    {
        // Debugging tool for quickly switching turns
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hita;
            Ray raya = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(raya, out hita, 500.0f))
            {
                SwitchTurns();
            }        
        }

        if (Input.GetMouseButtonDown(0) && !GM.pauseGame)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 500.0f))
            {
                var singleTile = hit.collider.GetComponent<SingleTile>();

                if (singleTile != null)
                {
                    if (selectedPiece == null)
                    {
                        selectedX = singleTile.posX;
                        selectedY = singleTile.posY;

                        if (GO_AR_BoardPieces[selectedX, selectedY] == null) return;

                        // Sets the chess piece at the selected position, and also generates its possible moves array
                        selectedPiece = GO_AR_BoardPieces[selectedX, selectedY];
                        possibleMoves = selectedPiece.GetComponent<ChessItem>().PossibleMoves(selectedX, selectedY);
                        // Highlights board
                        SetSelectedPiece(1);

                        // Clears board highlights
                        if (whiteTurn != selectedPiece.GetComponent<ChessItem>().isWhitePiece) SetSelectedPiece(0);

                    }
                    else
                    {
                        currentX = singleTile.posX;
                        currentY = singleTile.posY;

                        if (possibleMoves[currentX, currentY])
                        {
                            if (GO_AR_BoardPieces[currentX, currentY] != null)
                            {
                                if (selectedPiece.GetComponent<ChessItem>().isWhitePiece)
                                {
                                    // Checks for king piece in order to meet success condition
                                    if (GO_AR_BoardPieces[currentX, currentY].GetComponent<ChessItem>().isKing)
                                    {
                                        GM.PlayerTwoWin();
                                        return;
                                    }
                                    else
                                    {
                                        GameManager.p1PieceCount--;
                                    }
                                }
                                else
                                {
                                    if (GO_AR_BoardPieces[currentX, currentY].GetComponent<ChessItem>().isKing)
                                    {
                                        GM.PlayerOneWin();
                                        return;
                                    }
                                    else
                                    {
                                        GameManager.p2PieceCount--;
                                    }
                                }
                                Destroy(GO_AR_BoardPieces[currentX, currentY]);
                            }

                            // Moves chess piece position
                            selectedPiece.transform.position = GO_AR_Tiles[currentX, currentY].transform.position;
                            GO_AR_BoardPieces[currentX, currentY] = selectedPiece;
                            GO_AR_BoardPieces[selectedX, selectedY] = null;

                            if (selectedPiece.GetComponent<ChessItem>().isPawn && (currentX == 0 || currentX == 7))
                            {
                                PawnPromotion(currentX, currentY);
                            }

                            SwitchTurns();
                        }

                        SetSelectedPiece(0);
                    }
                }                
            }
        }
    }

    private void SwitchTurns()
    {
        whiteTurn = !whiteTurn;

        StopAllCoroutines();
        if (whiteTurn) StartCoroutine(WhiteTeam());
        else StartCoroutine(BlackTeam());
    }

    private void SetSelectedPiece(int type)
    {
        switch (type)
        {
            case 0:
                selectedPiece = null;
                ClearHighlights();              
                break;
            case 1:
                BoardHighlight(possibleMoves, selectedX, selectedY);                                
                break;
            default:
                ClearHighlights();
                break;
        }
    }

    private void BoardHighlight(bool[,] array, int sX, int sY)
    {
        // Handles board highlighting for potential, enemy and player positions
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (array[x, y])
                {
                    if (GO_AR_BoardPieces[x,y] == null)
                    {
                        GO_AR_Tiles[x, y].GetComponent<Renderer>().material = mPotentialMat;
                    }               
                    else
                    {
                        GO_AR_Tiles[x, y].GetComponent<Renderer>().material = mEnemyMat;
                    }    
                }                
            }
        }

        GO_AR_Tiles[sX, sY].GetComponent<Renderer>().material = mSelectedMat;

    }

    private void ClearHighlights()
    {
        foreach (GameObject tile in GO_AR_Tiles)
        {
            tile.GetComponent<Renderer>().material = mTransparentMat;                
        }
    }

    public void PawnPromotion(int x, int y)
    {
        if (x == 0)
        {
            Destroy(GO_AR_BoardPieces[x, y]);
            GO_AR_BoardPieces[x, y] = Instantiate(GO_AR_Pieces[7], GO_AR_Tiles[0, y].transform.position, Quaternion.identity);
            GameManager.p2PromotionCount++;
        }
        else if (x == 7)
        {
            Destroy(GO_AR_BoardPieces[x, y]);
            GO_AR_BoardPieces[x, y] = Instantiate(GO_AR_Pieces[1], GO_AR_Tiles[7, y].transform.position, Quaternion.identity);
            GameManager.p1PromotionCount++;
        }
        
    }

    IEnumerator WhiteTeam()
    {
        Vector3 whiteTeamPos = new Vector3(0, 60, 70);
        Vector3 whiteTeamEuler = new Vector3(45, 180, 0);
        GM.pauseGame = true;
        while (true)
        {
            if (Vector3.Distance(Camera.main.transform.eulerAngles, whiteTeamEuler) > 2f)
            {
                Camera.main.transform.RotateAround(Vector3.zero, Vector3.up, 100 * Time.deltaTime);
                yield return null;
            }
            else
            {
                Camera.main.transform.position = whiteTeamPos;
                Camera.main.transform.eulerAngles = whiteTeamEuler;
                GM.pauseGame = false;
                break;
            }
        }        
    }

    IEnumerator BlackTeam()
    {
        Vector3 blackTeamPos = new Vector3(0, 60, -70);
        Vector3 blackTeamEuler = new Vector3(45, 0, 0);
        GM.pauseGame = true;
        while (true)
        {
            if (Vector3.Distance(Camera.main.transform.eulerAngles, blackTeamEuler) > 2f)
            {
                Camera.main.transform.RotateAround(Vector3.zero, Vector3.down, 100 * Time.deltaTime);
                yield return null;
            }
            else
            {
                Camera.main.transform.position = blackTeamPos;
                Camera.main.transform.eulerAngles = blackTeamEuler;
                GM.pauseGame = false;
                break;
            }           
        }
    }

}
