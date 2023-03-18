using System;
using Physics;
using UnityEngine;

namespace Ball
{
	public class BallBounce : MonoBehaviour
	{
		[SerializeField] private Rigidbody _rigidbody;
		private Bounce _bounce;

		private void Start()
		{
			_bounce = new Bounce(_rigidbody);
		}
	}
}