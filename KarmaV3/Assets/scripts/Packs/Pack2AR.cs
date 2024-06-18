using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Pack2AR : MonoBehaviour
{
    public bool Pack2Visible = false;

    public GameManager gameManager;

    private ObserverBehaviour mObserverBehaviour;
    void Awake()
    {
        ObserverBehaviour mObserverBehaviour = GetComponent<ObserverBehaviour>();

        if (mObserverBehaviour != null)
            mObserverBehaviour.OnTargetStatusChanged += OnStatusChanged;
    }
    void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        Debug.LogFormat("TargetName: {0}, Status is: {1}, StatusInfo is: {2}", behaviour.TargetName, status.Status, status.StatusInfo);
    }
    void OnDestroy()
    {
        if (mObserverBehaviour != null)
            mObserverBehaviour.OnTargetStatusChanged -= OnStatusChanged;
    }

    public void Target2InScreen()
    {
        Pack2Visible = true;
        if (Pack2Visible == true)
        {
            gameManager.GetComponent<GameManager>().ActivePack2();
            StartCoroutine(DestroyObject());
        }
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3);
        GameObject.Destroy(gameObject);
    }
}
