using Extensions;
using Physics.Ejections;
using UnityEngine;

namespace Platforms.Parts
{
	public abstract class PlatformPart : MonoBehaviour
	{
		

		public void UnhookBy(EjectionSo ejectionSo, Vector3 centerOfPlatform)
		{
			Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
			transform.ClearParent();
			rigidbody.detectCollisions = false;
			ejectionSo.PushOut(rigidbody,centerOfPlatform);
		}
	}
}