using UnityEngine;
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
    [SerializeField] private RandomEvent _randomEvent;

    private void Awake()
    {
        _cam1.gameObject.SetActive(false);
        _cam2.gameObject.SetActive(true);
        _cam2bis.gameObject.SetActive(false);
        _cam3.gameObject.SetActive(false);
        _cam4.gameObject.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(CamSwapTime());
        //StartTravelling();
    }

    public void StartTravelling()
    {
        if (Mathf.Approximately(_mainCamera.transform.position.x, _cam3.transform.position.x))
        {
            _cam3.gameObject.SetActive(true);
            _cam4.gameObject.SetActive(false);
        }

        if (Mathf.Approximately(_mainCamera.transform.position.x, _cam4.transform.position.x))
        {
            _cam3.gameObject.SetActive(false);
            _cam4.gameObject.SetActive(true);
        }
    }

    private void CameraSwap()
    {
        _cam1.gameObject.SetActive(true);
        _cam2.gameObject.SetActive(false);
    }

    IEnumerator CamSwapTime()
    {
        yield return new WaitWhile(_randomEvent.IsReady);
        CameraSwap();
    }
}
