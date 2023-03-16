using System;
using Unity.Mathematics;
using UnityEngine;

namespace Ball
{
	public class BallEffects : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _collisionParticlePrefab;
		private ParticleSystem _collisionParticles;

		private void Start()
		{
			_collisionParticles = Instantiate(_collisionParticlePrefab);
		}

		private void OnCollisionEnter(Collision other)
		{
			Vector3 collisionPosition = other.contacts[0].point;
			_collisionParticles.transform.position = collisionPosition;
			_collisionParticles.Play();
		}
	}
}