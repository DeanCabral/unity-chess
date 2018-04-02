using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text timerText;
    public Text currentPlayerText;
    public Text countText;
    public Text promotionCountText;
    public Text winScreenText;
    public Button replayGame;
    public Button resumeGame;
    public Button exitGame;
    private BoardInteractivity BI;
    public GameObject timer;
    public GameObject tacticalMenu;
    public GameObject winScreen;
    public static int p1PieceCount;
    public static int p2PieceCount;
    public static int p1PromotionCount;
    public static int p2PromotionCount;
    private Vector3 currentCamPos;
    private Vector3 currentCamEuler;
    private float secondsCount;
    private int minuteCount;
    public bool pauseGame;
    private bool menuOpen;

    // Use this for initialization
    void Start () {

        BI = GameObject.Find("Board").GetComponent<BoardInteractivity>();
        p1PieceCount = 16;
        p2PieceCount = 16;
        p1PromotionCount = 0;
        p1PromotionCount = 0;
        pauseGame = false;
        menuOpen = false;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {

        UserInput();
        UpdateUI();
        UpdateTimer();
	}

    private void UpdateUI()
    {
        if (!BI.whiteTurn) currentPlayerText.text = "Black Team";
        else currentPlayerText.text = "White Team";

        countText.text = "Black Team: " + p1PieceCount + "\nWhite Team: " + p2PieceCount;
        promotionCountText.text = "Black Team: " + p1PromotionCount + "\nWhite Team: " + p2PromotionCount;
    }

    private void UpdateTimer()
    {
        secondsCount += Time.deltaTime;
        timerText.text = minuteCount + " min: " + (int)secondsCount + " sec";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
    }

    private void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuOpen)
            {
                TacticalMenu(1);
                menuOpen = !menuOpen;
            }
            else
            {
                if (!pauseGame)
                {
                    currentCamPos = Camera.main.transform.position;
                    currentCamEuler = Camera.main.transform.eulerAngles;
                    TacticalMenu(0);
                    menuOpen = !menuOpen;
                }               
            }            
        }
    }

    public void PlayerOneWin()
    {
        Time.timeScale = 0;
        winScreen.SetActive(true);
        winScreenText.text = "This match has been won by the Black Team";
        timerText.color = Color.red;
    }

    public void PlayerTwoWin()
    {
        Time.timeScale = 0;
        winScreen.SetActive(true);
        winScreenText.text = "This match has been won by the White Team";
        timerText.color = Color.red;
    }

    private void TacticalMenu(int type)
    {
        StopAllCoroutines();
        switch (type)
        {
            case 0:                
                StartCoroutine(ShowMenu());
                break;
            case 1:
                StartCoroutine(HideMenu());                          
                break;
            default:
                break;
        }
    }

    public void ResumeGame()
    {
        StartCoroutine(HideMenu());
        menuOpen = !menuOpen;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator ShowMenu()
    {
        float lerpTime = 0;

        Camera.main.transform.position = new Vector3(34, 60, 5);
        Camera.main.transform.eulerAngles = new Vector3(95, 0, 0);
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 45;
        timer.SetActive(false);

        while (lerpTime < 1)
        {           
            lerpTime += Time.deltaTime * 2;
            tacticalMenu.GetComponent<RectTransform>().localPosition = Vector3.Lerp(new Vector3(560, -5, 0), new Vector3(230, -5, 0), lerpTime);
            yield return null;
        }

        if (lerpTime >= 1)
        {
            pauseGame = true;
            Time.timeScale = 0;
        }
    }

    IEnumerator HideMenu()
    {
        float lerpTime = 0;
        pauseGame = false;
        Time.timeScale = 1;

        while (lerpTime < 1)
        {
            lerpTime += Time.deltaTime * 4;
            tacticalMenu.GetComponent<RectTransform>().localPosition = Vector3.Lerp(new Vector3(230, -5, 0), new Vector3(560, -5, 0), lerpTime);
            yield return null;
        }

        if (lerpTime >= 1)
        {
            Camera.main.transform.position = currentCamPos;
            Camera.main.transform.eulerAngles = currentCamEuler;
            Camera.main.orthographic = false;
            Camera.main.orthographicSize = 5;
            timer.SetActive(true);            
        }
    }

}
