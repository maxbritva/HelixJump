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
			Vector3 velocity = _rigidBody.velocity;
			velocity = velocity.y >= 0.0f
				? Vector3.ClampMagnitude(velocity, _data.MaxHeight)
				: velocity;
		}
	}
}
