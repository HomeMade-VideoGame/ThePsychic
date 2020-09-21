using UnityEngine;

public class PlayerTransformReceiver : MonoBehaviour
{
    [SerializeField] TransformData _playerTransformData;

    private Transform _thisTransform;

    private void Awake()
    {
        _thisTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        _thisTransform.position = _playerTransformData.value.position;
    }
}
