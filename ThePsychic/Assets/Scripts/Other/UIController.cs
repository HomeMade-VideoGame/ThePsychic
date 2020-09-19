using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Singleton
    public static UIController instance;

    private void Awake()
    {
        instance = this;
        _player = FindObjectOfType<Player>();
    }
    #endregion

    public Image _wrenchImage, _flowerImage, _umbrellaImage;
    public GameObject _pausedNotification;


    #region Private

    public bool _canClickButton = false;
    private Player _player;

    [HideInInspector]
    public bool _usedWrench, _usedFlower, _usedUmbrella;

    #endregion


    public void UseWrench()
    {
        if (_canClickButton && _player._hasWrench)
        {
            Debug.Log("used wrench");
            LevelManager.instance._isPaused = false;
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
}
