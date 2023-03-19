using UnityEngine;

namespace Physics
{
	public class Bounce
	{
		private readonly Rigidbody _rigidBody;
		private readonly BounceData _data;

		public Bounce(Rigidbody rigidBody, BounceData data)
		{
			_rigidBody = rigidBody;
			_data = data;
		}

		public void BounceOff(Vector3 direction) => 
			_rigidBody.AddForce(direction * _data.Force, ForceMode.VelocityChange);

		public void ClampHeight()
		{
			Vector3 Velocity = _rigidBody.velocity;
			Velocity = Velocity.y >= 0.0f
				? Vector3.ClampMagnitude(Velocity, _data.MaxHeight)
				: Velocity;
		}
	}
}
