using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilisationItem : MonoBehaviour
{

    #region Private

    private Text _notification;
    private Player _player;

    private bool _canInterract = false;


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
