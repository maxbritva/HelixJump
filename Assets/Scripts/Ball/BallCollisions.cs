using System;
using Platforms;
using UnityEngine;

namespace Ball
{
	public class BallCollisions : MonoBehaviour
	{
		[SerializeField] private BallBounce _bounce;
		[SerializeField] private BallParticles _particles;
		[SerializeField] private Transform _ball;

		private bool _collided;
		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent(out PlatformObstacle _))
			{
				Destroy();
				return;
			}
			if (_collided)
				return;

			_collided = true; 
			_bounce.BouceOff(Vector3.up);
			_particles.EmitSpotParticles(other);
			_particles.EmitCollisionParticles(other);
		}

		private void OnCollisionExit(Collision other)
		{
			_collided = false;
		}

		private void Destroy()
		{
			_particles.EmitDestroyParticles(_ball.position);
			Destroy(_ball.gameObject);
		}
	}
}