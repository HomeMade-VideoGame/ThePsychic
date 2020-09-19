using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilisationItem : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField] BoutonData _boutonData;
    [SerializeField] Player _player;
    [SerializeField] GameObject _notification;

    #endregion

    #region Private

    private bool _canInterract = false;
    private bool _canClickButton = false;

    [HideInInspector]
    public bool _usedWrench, _usedFlower, _usedUmbrella;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        _boutonData.value = GetComponent<UtilisationItem>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canInterract && _player._hasAnyItem)
        {
            UIController.instance._pausedNotification.SetActive(true);
            _canClickButton = true;
            LevelManager.instance._isPaused = true;
        }


    }

    #endregion

    public void UseWrench()
    {
        if (_canClickButton && _player._hasWrench)
        {
            LevelManager.instance._isPaused = false;
            Debug.Log("used wrench");
            UIController.instance._wrenchImage.enabled = false;
            _usedWrench = true;

        }
    }

    public void UseFlower()
    {
        if (_canClickButton && _player._hasFlower)
        {
            LevelManager.instance._isPaused = false;
            Debug.Log("used flower");
            UIController.instance._flowerImage.enabled = false;
            _usedFlower = true;

        }
    }

    public void UseUmbrella()
    {
        if (_canClickButton && _player._hasUmbrella)
        {
            Debug.Log("used umbrella");
            UIController.instance._umbrellaImage.enabled = false;
            _usedUmbrella = true;
            LevelManager.instance._isPaused = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _player._hasAnyItem)
        {
            _notification.SetActive(true);
            _canInterract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _notification.SetActive(false);
            _canInterract = false;
        }
    }
}
