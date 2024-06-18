using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColliderConsolePeca1 : MonoBehaviour
{
    Vector3 _rotation;
    float valoAngle;
    public Vector3 initialPosition;

    public Image _image;

    public RectTransform _RectTransform;
    public GameObject gameManager;

    public bool PositionOK = false;

    public AudioManager _AudioManager;
    public AudioClip SoundPecaEncaixando;
    void Start()
    {
        _AudioManager = GameObject.FindGameObjectWithTag("AudioManager")?.GetComponent<AudioManager>();
        gameManager = GameObject.Find("GameManager");
        _RectTransform = GetComponent<RectTransform>();

        initialPosition = transform.position;
    }
    void Update()
    {
        _rotation = _RectTransform.eulerAngles;
        valoAngle = _rotation.z - 90;

        if (Mathf.Abs(valoAngle) < 1)
        {
            PositionOK = true;
        }
        else
        {
            PositionOK = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ConsoleControlePart1") && PositionOK)
        {
            Destroy(gameObject);
            _image.color = Color.white;
            gameManager.GetComponent<GameManager>().Encaixou();
            gameManager.GetComponent<GameManager>().ContadorPecas();
            _AudioManager.StartSom(SoundPecaEncaixando);
        }
        else
        {
            //Debug.Log("Colidiu com outro");
            //transform.position = initialPosition;
        }
    }
}
