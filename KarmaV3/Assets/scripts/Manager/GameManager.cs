using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool pack1 = false;
    public bool pack2 = false;
    public bool pack3 = false;

    public GameObject PacoteConsole1AR;
    public GameObject PacoteGabinete2AR;
    public GameObject PacoteMesa3AR;
    public GameObject PacoteLevel4AR;
    public GameObject ScrollCompleto;
    public GameObject ButtonOutMenuLateral;
    public GameObject BarraSuperior;

    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Points;
    public TextMeshProUGUI Multiply;

    public bool start = false;
    public float CurrentTime;
    float StartTime = 90f;

    public int points;
    public int numOfPecas;
    public int TotalScoce;
    int PreviousTotalScore;
    void Start()
    {

        CurrentTime = StartTime;

        Debug.Log(PlayerPrefs.GetInt("TotalPoints"));
        TotalScoce = (PlayerPrefs.GetInt("TotalPoints"));
    }
    void Update()
    {
        if (pack1 && pack2 && pack3)
        {
            StartCoroutine(StartGame());
            //StartGame();
        }

        if(start == true)//Timer do jogo
        {
            CurrentTime -= 1 * Time.deltaTime;

            Timer.text = CurrentTime.ToString("0");

            if (CurrentTime <= 0)
            {
                CurrentTime = 0f;
            }

            Points.text = points.ToString("0");
        }
        //Verificação de tempo para alterar o multiplicador de pontos
        if (CurrentTime <= 90 && CurrentTime >= 70)
        {
            Multiply.text = "x15";
        }
        else if (CurrentTime <= 69 && CurrentTime >= 40)
        {
            Multiply.text = "x10";
        }
        else if (CurrentTime <= 39 && CurrentTime >= 10)
        {
            Multiply.text = "x5";
        }
        else if (CurrentTime <= 9)
        {
            Multiply.text = "x1";
        }
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3);
        PacoteConsole1AR.SetActive(true);
        ScrollCompleto.SetActive(true);
        BarraSuperior.SetActive(true);

        start = true;
        pack1 = false;
        pack2 = false;
        pack3 = false;
    }
    //public void StartGame()
    //{
    //    PacoteConsole1AR.SetActive(true);
    //    ScrollCompleto.SetActive(true);
    //    BarraSuperior.SetActive(true);

    //    start = true;
    //    pack1 = false;
    //    pack2 = false;
    //    pack3 = false;
    //}
    public void Encaixou()
    {
        switch(CurrentTime)
        {
            case float n when n >= 70 && n <= 90:
                points = points + 15;
            break;
            case float n when n >= 40 && n <= 69:
                points = points + 10;
            break;
            case float n when n >= 10 && n <= 39:
                points = points + 5;
            break;
            default:
                points = points + 1;
            break;
        }
        PreviousTotalScore = PlayerPrefs.GetInt("TotalPoints", 0);
        if (points > PreviousTotalScore)
        {
            TotalScoce = points;
            PlayerPrefs.SetInt("TotalPoints", TotalScoce);
        }
    }
    public void ContadorPecas()
    {
        numOfPecas++;

        if (numOfPecas == 6)
        {
            PacoteConsole1AR.SetActive(false);
            PacoteGabinete2AR.SetActive(true);
        }
        else if (numOfPecas == 12)
        {
            PacoteGabinete2AR.SetActive(false);
            PacoteMesa3AR.SetActive(true);
        }
        else if (numOfPecas == 18)
        {
            PacoteMesa3AR.SetActive(false);
            PacoteLevel4AR.SetActive(true);
        }
        else if (numOfPecas == 24)
        {
            SceneManager.LoadScene(4);
        }
    }
    public void Pouse()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void ActivePack1()
    {
        pack1 = true;
    }
    public void ActivePack2()
    {
        pack2 = true;
    }
    public void ActivePack3()
    {
        pack3 = true;
    }
}
