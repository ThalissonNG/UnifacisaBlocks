using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorial = new GameObject[6];
    public int ValorOfFala = 0;
    //int x = 0;

    public void ProximaFala()
    {
        ValorOfFala++;
    }
    public void AnteriorFala()
    {
        ValorOfFala--;
        if (ValorOfFala < 0)
        {
            ValorOfFala = 0;
        }   
    }
    void Update()
    {
        if (ValorOfFala > 5)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            for (int i = 0; i < tutorial.Length; i++)
            {
                if (i == ValorOfFala)
                {
                    tutorial[i].SetActive(true);
                }
                else
                {
                    tutorial[i].SetActive(false);
                }
            }
        }
    }
}
