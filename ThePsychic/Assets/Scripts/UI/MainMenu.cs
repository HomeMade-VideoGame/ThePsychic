using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField] string _levelToLoad;

    #endregion

    #region Public methods

    public void StartGame()
    {
        SceneManager.LoadScene(_levelToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    #endregion
}
