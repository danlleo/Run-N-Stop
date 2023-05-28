using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _rotation;

    private void Start()
    {
        transform.SetParent(_player);
        transform.SetPositionAndRotation(_player.position - _offset, Quaternion.Euler(_rotation));
    }
}
