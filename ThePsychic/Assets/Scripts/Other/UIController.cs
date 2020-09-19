using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Singleton
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Image _wrenchImage, _flowerImage, _umbrellaImage;
    public GameObject _pausedNotification;
}
