using Cinemachine;
using UnityEngine;

namespace Ball
{
	public class BallDestroyer : MonoBehaviour
	{
		[SerializeField] private BallParticles _particles;
		[SerializeField] private Transform _ball;
		[SerializeField] private CinemachineImpulseSource _cinemachineImpulseSource;

		public void Destroy()
		{
			_particles.EmitDestroyParticles(_ball.position);
			_cinemachineImpulseSource.GenerateImpulse();
			Destroy(_ball.gameObject);
		}
	}
}