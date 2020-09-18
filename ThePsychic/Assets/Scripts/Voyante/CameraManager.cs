using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cam1;
    [SerializeField] private CinemachineVirtualCamera _cam2;
    [SerializeField] private CinemachineVirtualCamera _cam3;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _camSwapTime;

    private void Awake()
    {
        _cam1.gameObject.SetActive(false);
        _cam2.gameObject.SetActive(true);
        _cam3.gameObject.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(CamSwapTime());
    }

    private void Camera2To3()
    {
        _cam3.gameObject.SetActive(true);
        _cam2.gameObject.SetActive(false);
    }

    private void Camera3To1()
    {
        _cam1.gameObject.SetActive(true);
        _cam3.gameObject.SetActive(false);
    }

    IEnumerator CamSwapTime()
    {
        yield return new WaitForSeconds(_camSwapTime);
        Camera2To3(); 

        yield return new WaitForSeconds(_camSwapTime);
        Camera3To1();
    }
}
