using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDefuser : MonoBehaviour
{
    [SerializeField] PredictedEvent _predictedEvent;

    [Header("Item needed :")]
    [Tooltip("0 = None, 1 = Wrench, 2 = Flower, 3  Umbrella")]
    [Range(0,3)]
    [SerializeField] int _keyCode = 0;

    private bool needsItem;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        if (_keyCode == 0)
        {
            needsItem = false;
        }
        else needsItem = true;
    }

    private void Update()
    {
        if (needsItem)
        {
            if (UIController.instance._itemCode == _keyCode)
            {

                _predictedEvent.DisableEvent();
            }
        }
        else
        {
            return;
        }
       
        
    }
}
