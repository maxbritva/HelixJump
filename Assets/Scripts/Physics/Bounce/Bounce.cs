using UnityEngine;

namespace Physics
{
	public class Bounce
	{
		private readonly Rigidbody _rigidBody;
		private  readonly float _force;
		private  readonly float _maxHeight;

		public Bounce(Rigidbody rigidBody, float force, float maxHeight)
		{
			_rigidBody = rigidBody;
			_force = force;
			_maxHeight = maxHeight;
		}

		public void BounceOff(Vector3 direction) => 
			_rigidBody.AddForce(direction * _force, ForceMode.VelocityChange);

		public void ClampHeight()
		{
			
		}
	}
	
	public class BounceData 
	{
	[SerializeField] private  float _force;
	[SerializeField] private  float _maxHeight;

	public float Force => _force;

	public float MaxHeight => _maxHeight;
	}
}
