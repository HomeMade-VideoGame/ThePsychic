using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject _deathScreen;
    public Image _wrenchImage, _flowerImage, _umbrellaImage;
    public GameObject _inventory;
    public GameObject _pausedNotification;
    public float _waitToDisplayInventory;
    public float _waitToStopUmbrella;
    public string _reloadScene, _mainMenuScene;

    public SpriteRenderer _umbrellaSr;
    public Animator _umbrellaAnim;


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

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_mainMenuScene);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(_reloadScene);
    }

    public void UseWrench()
    {
        if (_canClickButton && _player._hasWrench)
        {
            Debug.Log("used wrench");
            LevelManager.instance._isPaused = false;
            UIController.instance._wrenchImage.enabled = false;
            _itemCode = 1;
            UIController.instance._pausedNotification.SetActive(false);
            _player._hasWrench = false;
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
            UIController.instance._pausedNotification.SetActive(false);
            _player._hasFlower = false;

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
            _umbrellaSr.enabled = true;
            _umbrellaAnim.SetTrigger("Deploy");
            StartCoroutine(StopUmbrella());
            UIController.instance._pausedNotification.SetActive(false);
            _player._hasUmbrella = false;

        }
    }

    #endregion

    #region Coroutine

    public IEnumerator DisplayInventory()
    {
        yield return new WaitForSeconds(_waitToDisplayInventory);
        _inventory.SetActive(true);
    }

    public IEnumerator StopUmbrella()
    {
        yield return new WaitForSeconds(_waitToStopUmbrella);
        _umbrellaSr.enabled = false;
    }

    #endregion
}
