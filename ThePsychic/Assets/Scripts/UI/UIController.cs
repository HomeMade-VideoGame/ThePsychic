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
    public GameObject _inventory;
    public GameObject _pausedNotification;
    public float _waitToDisplayInventory;


    #region Private

    public bool _canClickButton = false;
    private Player _player;

    public Image _fadeScreen;
    public float _fadeSpeed;

    [HideInInspector]
    public int _itemCode = 0;
    private bool _fadeToBlack, _fadeOutBlack;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        _fadeOutBlack = true;
        _fadeToBlack = false;
    }

    private void Update()
    {
        if (_player._theSr.isVisible)
        {
            StartCoroutine(DisplayInventory());
        }

        if (_fadeOutBlack)
        {
            _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b, Mathf.MoveTowards(_fadeScreen.color.a, 0f, _fadeSpeed * Time.deltaTime));

            if (_fadeScreen.color.a == 0f)
            {
                _fadeOutBlack = false;
            }
        }

        if (_fadeToBlack)
        {
            _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b, Mathf.MoveTowards(_fadeScreen.color.a, 1f, _fadeSpeed * Time.deltaTime));

            if (_fadeScreen.color.a == 1f)
            {
                _fadeToBlack = false;
            }
        }
    }

    #endregion

    #region Public methods

    public void StartFadeToBlack()
    {
        _fadeToBlack = true;
        _fadeOutBlack = false;
    }

    public void UseWrench()
    {
        if (_canClickButton && _player._hasWrench)
        {
            Debug.Log("used wrench");
            LevelManager.instance._isPaused = false;
            UIController.instance._wrenchImage.enabled = false;
            _itemCode = 1;

        }
    }

    public void UseFlower()
    {
        if (_canClickButton && _player._hasFlower)
        {
            LevelManager.instance._isPaused = false;
            Debug.Log("used flower");
            UIController.instance._flowerImage.enabled = false;
            _itemCode = 2;

        }
    }

    public void UseUmbrella()
    {
        if (_canClickButton && _player._hasUmbrella)
        {
            Debug.Log("used umbrella");
            UIController.instance._umbrellaImage.enabled = false;
            _itemCode = 3;
            LevelManager.instance._isPaused = false;
        }
    }

    #endregion

    #region Coroutine

    public IEnumerator DisplayInventory()
    {
        yield return new WaitForSeconds(_waitToDisplayInventory);
        _inventory.SetActive(true);
    }

    #endregion
}
