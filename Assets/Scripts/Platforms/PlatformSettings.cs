using UnityEngine;

namespace Platforms
{
	[CreateAssetMenu(fileName = "PlatformSettings", menuName = "ScriptableObjects/Platform/Settings")]
	public class PlatformSettings : ScriptableObject
	{
		[SerializeField][Min(0.0f)] private float _destroyDelayAfterUnhooking;

		public float DestroyDelayAfterUnhooking => _destroyDelayAfterUnhooking;
	}
}