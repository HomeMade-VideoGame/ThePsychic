using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEvent : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField] int _waitTime;
    [SerializeField] PredictedEvent _predictedEvent;

    [SerializeField] Animator _animPieton, _animVoiture;

    #endregion

    #region Private

    private IEnumerator _waitForGreenLight;
    private float _countToRed;
    private bool _goingRed;

    #endregion

    private void Awake()
    {
        _waitForGreenLight = WaitForGreenLight();
    }

    #region Private methods

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

    #endregion

    #region Coroutine

    IEnumerator WaitForGreenLight()
    {
        yield return new WaitForSeconds(_waitTime);
        _predictedEvent.DisableEvent();
        _animVoiture.SetTrigger("PasseRouge");
        _animPieton.SetTrigger("PasseVert");
    }

    #endregion

}
