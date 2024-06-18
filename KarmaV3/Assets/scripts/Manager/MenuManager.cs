using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void ComAr()
    {
        SceneManager.LoadScene(1);
    }
    public void SemAr()
    {
        SceneManager.LoadScene(2);
    }    
    public void Tutorial()
    {
        SceneManager.LoadScene(3);
    }
    public void MenuMedalhas()
    {
        SceneManager.LoadScene(4);
    }
}
