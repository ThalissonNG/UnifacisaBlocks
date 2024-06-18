using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class MovePecas : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public RectTransform _rectTransform;
    public Canvas _canvas;

    public int Angulo = 0;
    public int NumOfClick = 0;

    public float CurrentTime = 0;
    float StartTime = 0.3f;


    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();

        CurrentTime = StartTime;
    }

    void Update()
    {
        if (NumOfClick == 1)
        {
            CurrentTime -= 1 * Time.deltaTime;
        }
        
        if (CurrentTime <= 0)
        {
            CurrentTime = StartTime;
            NumOfClick = 0;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        NumOfClick++;

        if (NumOfClick >= 2)
        {
            Angulo += -90;
            _rectTransform.eulerAngles = new Vector3 (0, 0, Angulo);
            
            NumOfClick = 0;
            CurrentTime = StartTime;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Quando o arraste come�a, podemos fazer algo, se necess�rio.
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Atualiza a posi��o da imagem para seguir o toque do usu�rio.
       _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Quando o arraste termina, podemos fazer algo, se necess�rio.
    }   
}