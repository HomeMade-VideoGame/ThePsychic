using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilisationItem : MonoBehaviour
{
    [SerializeField] PredictedEvent _predictedEvent;
    [SerializeField] Animator _animElec;

    #region Private

    private Text _notification;
    private Player _player;

    private bool _canInterract = false;
    private bool _canTurnOffElec;


    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _notification = GetComponentInChildren<Text>();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canInterract && _player._hasAnyItem)
        {
            UIController.instance._pausedNotification.SetActive(true);
            UIController.instance._canClickButton = true;
            LevelManager.instance._isPaused = true;

            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.E) && _canTurnOffElec)
        {
            _animElec.SetTrigger("ElecOff");
            _predictedEvent.DisableEvent();

        }
    }

    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _player._hasAnyItem)
        {
            
            _notification.enabled = true;
            _canInterract = true;
        }

        if (other.CompareTag("Player"))
        {
            _notification.enabled = true;
            _canTurnOffElec = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _notification.enabled = false;
            _canInterract = false;
        }
    }
}
