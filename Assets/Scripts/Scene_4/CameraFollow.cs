using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothTime = 0.2f;

    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
        => transform.position = Vector3.SmoothDamp(transform.position, _target.position, ref _velocity, _smoothTime);
}
