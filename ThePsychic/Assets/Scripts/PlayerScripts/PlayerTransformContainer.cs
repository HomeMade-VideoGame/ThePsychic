using UnityEngine;

public class PlayerTransformContainer : MonoBehaviour
{
    [SerializeField] TransformData _playerTransformContainer;

    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {

        if (_playerTransformContainer != null)
        {
            _playerTransformContainer.value = _playerTransform;
        }
    }
}
