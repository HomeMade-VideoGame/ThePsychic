using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public bool _isPaused;

    private void Update()
    {
        if (_isPaused)
        {
            Time.timeScale = 0f;
        }
        if (!_isPaused)
        {
            Time.timeScale = 1f;
        }
    }
}
