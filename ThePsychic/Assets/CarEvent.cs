using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEvent : EventDefuser
{
    [SerializeField] int _waitTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitForGreenLight());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(WaitForGreenLight());
        }
    }

    IEnumerator WaitForGreenLight()
    {
        yield return new WaitForSeconds(_waitTime);
        Disarm();
    }


}
