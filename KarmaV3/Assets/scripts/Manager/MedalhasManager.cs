using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MedalhasManager : MonoBehaviour
{
    public GameManager _GameManager;
    public GameObject _GameManagerObject;

    public TextMeshProUGUI TotalScore;

    void Start()
    {
        _GameManagerObject = GameObject.Find("GameManager");
        _GameManager = _GameManagerObject.GetComponent<GameManager>();
        //TotalScore.text = (_GameManager.TotalScoce).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TotalScore.text = (_GameManager.TotalScoce).ToString();
        Debug.Log(_GameManager.TotalScoce);
    }
}
