using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TriggerSystem : MonoBehaviour
{
    [SerializeField] float _minWaitTime, _maxWaitTime;
    [SerializeField] PredictedEvent _event; //Assigné au début

    private bool _eventActive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !_eventActive)
        {
            _eventActive = true;
            StartCoroutine(WaitForEvent());
        }
    }

    public void GetEvent()
    {
        if (_event != null)
        {
            Debug.Log("Event Triggered !");
            _event.StartEvent();
        }
        else Debug.LogError("Event is missing from Trigger");
    }

    IEnumerator WaitForEvent()
    {
        yield return new WaitForSeconds(Random.Range(_minWaitTime, _maxWaitTime));
        GetEvent();
    }
}
