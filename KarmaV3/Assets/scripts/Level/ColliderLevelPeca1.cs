using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderLevelPeca1 : MonoBehaviour
{
    public RectTransform _RectTransform;
    Vector3 _rotation;
    float valoAngle;
    public Image _image;

    public GameObject gameManager;

    public bool PositionOK = false;

    public AudioManager _AudioManager;
    public AudioClip SoundPecaEncaixando;
    void Start()
    {
        _AudioManager = GameObject.FindGameObjectWithTag("AudioManager")?.GetComponent<AudioManager>();
        gameManager = GameObject.Find("GameManager");
        _RectTransform = GetComponent<RectTransform>();
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
        if (other.CompareTag("LevelPart1") && PositionOK)
        {
            Destroy(gameObject);
            _image.color = Color.white;
            gameManager.GetComponent<GameManager>().Encaixou();
            gameManager.GetComponent<GameManager>().ContadorPecas();
            _AudioManager.StartSom(SoundPecaEncaixando);
        }
        else
        {
            Debug.Log("Colidiu com outro");
        }
    }
}
