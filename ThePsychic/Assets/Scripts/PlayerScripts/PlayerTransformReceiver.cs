using UnityEngine;

public class PlayerTransformReceiver : MonoBehaviour
{
    [SerializeField] TransformData _playerTransformData;

    private Transform _thisTransform;

    private void Awake()
    {
        _thisTransform = transform;
    }

    private void Update()
    {
        _thisTransform = _playerTransformData.value;
    }
}
