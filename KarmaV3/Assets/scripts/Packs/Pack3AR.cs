using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Pack3AR : MonoBehaviour
{
    public bool Pack3Visible = false;

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

    public void Target3InScreen()
    {
        Pack3Visible = true;
        if (Pack3Visible == true)
        {
            gameManager.GetComponent<GameManager>().ActivePack3();
            StartCoroutine(DestroyObject());
        }
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3);
        GameObject.Destroy(gameObject);
    }
}
