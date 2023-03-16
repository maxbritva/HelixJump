
using System;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
  [SerializeField] private Rigidbody _rigidbody;
  [SerializeField][Min(0.0f)] private float _rotationSpeed;
  [SerializeField] [Min(0.0f)] private float _angularDrag;

  private void OnValidate()
  {
	  _rigidbody.angularDrag = _angularDrag;
  }

  public void Rotate(float xAxis)
  {
    Vector3 torque = Vector3.up * (xAxis * _rotationSpeed * Time.deltaTime * -1);
   _rigidbody.AddTorque(torque, ForceMode.Acceleration);
  }
}
