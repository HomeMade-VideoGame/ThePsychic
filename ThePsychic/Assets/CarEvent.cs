using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEvent : MonoBehaviour
{
    [SerializeField] int _waitTime;
    [SerializeField] PredictedEvent _predictedEvent;

    private IEnumerator _waitForGreenLight;

    private void Awake()
    {
        _waitForGreenLight = WaitForGreenLight();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(_waitForGreenLight);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(_waitForGreenLight);
        }
    }

    IEnumerator WaitForGreenLight()
    {
        yield return new WaitForSeconds(_waitTime);
        _predictedEvent.DisableEvent();
    }


}
