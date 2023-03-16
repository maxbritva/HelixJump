using System;
using Unity.Mathematics;
using UnityEngine;

namespace Ball
{
	public class BallEffects : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _collisionParticlePrefab;
		
		private void OnCollisionEnter(Collision other)
		{
			Vector3 CollisionPosition = other.contacts[0].point;
			Instantiate(_collisionParticlePrefab, CollisionPosition, quaternion.identity);
		}
	}
}