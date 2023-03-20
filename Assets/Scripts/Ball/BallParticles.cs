using System;
using Unity.Mathematics;
using UnityEngine;

namespace Ball
{
	public class BallParticles : MonoBehaviour
	{
		private const float SurfaceYOffset = 0.03f;
		[SerializeField] private ParticleSystem _collisionParticlePrefab;
		[SerializeField] private ParticleSystem _spotParticlesPrefab;
		[SerializeField] private ParticleSystem _destroyBallParticlesPrefab;
		private ParticleSystem _collisionParticles;

		private void Start()
		{
			_collisionParticles = Instantiate(_collisionParticlePrefab);
		}



		
		public void EmitCollisionParticles(Collision other)
		{
			Vector3 collisionPosition = other.contacts[0].point;
			_collisionParticles.transform.position = collisionPosition;
			_collisionParticles.Play(); 
		}
		public void EmitSpotParticles(Collision collision)
		{
			Vector3 collisionPosition = collision.contacts[0].point + Vector3.up *SurfaceYOffset;
			Instantiate(_spotParticlesPrefab, collisionPosition, quaternion.identity,collision.transform);
		}

		public void EmitDestroyParticles(Vector3 position) => 
			Instantiate(_destroyBallParticlesPrefab, position, quaternion.identity);
	}
}