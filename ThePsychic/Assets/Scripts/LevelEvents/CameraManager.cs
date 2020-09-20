﻿using UnityEngine;
using System.Collections;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cam1;
    [SerializeField] private CinemachineVirtualCamera _cam2;
    [SerializeField] private CinemachineVirtualCamera _cam2bis;
    [SerializeField] private CinemachineVirtualCamera _cam3;
    [SerializeField] private CinemachineVirtualCamera _cam4;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _camSwapTime;

    private void Awake()
    {
        _cam1.gameObject.SetActive(false);
        _cam2.gameObject.SetActive(false);
        _cam2bis.gameObject.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(CamSwapTime());
    }

    private void CameraSwap()
    {
        _cam1.gameObject.SetActive(true);
        _cam2.gameObject.SetActive(false);
    }

    IEnumerator CamSwapTime()
    {
        yield return new WaitForSeconds(_camSwapTime);
        CameraSwap();
    }
}
