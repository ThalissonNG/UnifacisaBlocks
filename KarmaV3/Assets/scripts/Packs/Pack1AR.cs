using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Vuforia;

public class Pack1AR : MonoBehaviour
{
    public bool Pack1Visible = false;

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
    public void Target1InScreen()
    {
        Pack1Visible = true;
        if (Pack1Visible == true)
        {
            gameManager.GetComponent<GameManager>().ActivePack1();
            StartCoroutine(DestroyObject());
        }
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3);
        GameObject.Destroy(gameObject);
    }
}
