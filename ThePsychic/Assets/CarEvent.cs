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

    //private void Start()
    //{
    //    _countToRed = 1f;
    //}

    //private void Update()
    //{
    //    if (_goingRed)
    //    {
    //        _countToRed -= Time.deltaTime;
    //        if (_countToRed <= 0)
    //        {
    //            _voitureRouge.enabled = true;
    //            _pietonVert.enabled = true;
    //        }
    //    }
    //}

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

    //private void TurningGreen()
    //{
    //    _voitureOrange.enabled = true;
    //    _goingRed = true;
    //}

    #endregion

    #region Coroutine

    IEnumerator WaitForGreenLight()
    {
        yield return new WaitForSeconds(_waitTime);
        _predictedEvent.DisableEvent();
        _animVoiture.SetTrigger("PasseRouge");
        _animPieton.SetTrigger("PasseVert");
        //TurningGreen();
    }

    #endregion

}
