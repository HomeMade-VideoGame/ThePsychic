using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField] float _waitForAnyKey = 2f;
    [SerializeField] GameObject _anyKeyText;
    [SerializeField] string _mainMenuScene;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (_waitForAnyKey > 0)
        {
            _waitForAnyKey -= Time.deltaTime;

            if (_waitForAnyKey <= 0)
            {
                _anyKeyText.SetActive(true);
            }

        }
        else
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(_mainMenuScene);
            }
        }
    }

    #endregion
}
