﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDefuser : PredictedEvent
{
    [Header("Item needed :")]
    [Tooltip("0 = None, 1 = Wrench, 2 = Flower, 3  Umbrella")]
    [Range(0,3)]
    [SerializeField] int _keyCode = 0;
    [SerializeField] UtilisationItem _interract;

    private bool needsItem;

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

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public override void Disarm()
    {
        base.Disarm();
    }
}
