using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
[RequireComponent(typeof(PredictedEvent))]

public class TriggerSystem : MonoBehaviour
{
    [SerializeField] float _minWaitTime, _maxWaitTime;
    [SerializeField] PredictedEvent _predictedEvent;

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
        if (_predictedEvent != null)
        {
            _predictedEvent.StartEvent();
            _eventActive = false;
        }
    }

    IEnumerator WaitForEvent()
    {
        yield return new WaitForSeconds(Random.Range(_minWaitTime, _maxWaitTime));
        GetEvent();
    }
}
