// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DraggableObject : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _initialScale;
    [SerializeField] private bool _isKinematicAfterDrop;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private bool _follow;
    [SerializeField] private float _followSpeed = 15f;
    [SerializeField] float _velocityLimit = 8f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public virtual void FixedUpdate()
    {
        if (!_follow)
            return;
        Vector3 moveDirection = _targetPosition - _rigidbody.position;
        _rigidbody.velocity = Vector3.ClampMagnitude(moveDirection * _followSpeed, _velocityLimit);
    }
    public void StartFollowingObject()
    {
        _follow = true;
        _rigidbody.isKinematic = false;
    }
    public void SetTargetPosition(Vector3 newTargetPosition)
    {
        _targetPosition = newTargetPosition;
    }
    public void StopFollowingObject()
    {
        _follow = false;
        _rigidbody.velocity = Vector3.zero;

        if (_isKinematicAfterDrop)
            _rigidbody.isKinematic = true;
    }
}
