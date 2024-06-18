using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotacionarObjeto : MonoBehaviour
{   
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            if (toque.phase == TouchPhase.Moved)
            {
                Vector2 rotacao = new Vector2(toque.deltaPosition.y, toque.deltaPosition.x * -1);
                transform.Rotate(rotacao * 10 * Time.deltaTime, Space.Self);
            }
        }

    }
}
