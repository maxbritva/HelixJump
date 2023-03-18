using System;
using Extensions;
using Platforms;
using Structures;
using UnityEngine;

namespace Tower
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Tower/TowerGenerationSettings", fileName = "TowerGenerationSettings")]
	public class TowerGenerationSettingsSo: ScriptableObject
	{
		[SerializeField][Min(0)] private int _platformVariantCount;
		[SerializeField] [Min(0.0f)] private float _offsetBetweenPlatforms;
		
		[SerializeField] private FloatRange _rotationRange;

		
		[Header("Platforms")]
		[SerializeField] private Platform _startPlatformPrefab;
		[SerializeField] private Platform _finishPlatformPrefab;
		[SerializeField] private Platform[] _platformVariantsPrefabs = Array.Empty<Platform>();

		public int PlatformVariantCount
		{
			get { return _platformVariantCount; }
		}

		public float OffsetBetweenPlatforms
		{
			get { return _offsetBetweenPlatforms; }
		}

		public Platform StartPlatformPrefab
		{
			get { return _startPlatformPrefab; }
		}

		public Platform FinishPlatformPrefab
		{
			get { return _finishPlatformPrefab; }
		}

		public FloatRange RotationRange => _rotationRange;

		public Platform PlatformVariantPrefab => _platformVariantsPrefabs.Random();
	}
}