using System;
using Platforms;
using UnityEngine;

namespace Ball
{
	public class BallCollisions : MonoBehaviour
	{
		[SerializeField] private BallBounce _bounce;
		[SerializeField] private BallDestroyer _destroyer;
		[SerializeField] private BallParticles _particles;
		private bool _collided;
		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent(out PlatformObstacle _))
			{
				_destroyer.Destroy();
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
		
	}
}