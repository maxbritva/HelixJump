
using System;
using Extensions;
using Platforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerGenerator : MonoBehaviour
{
	[Header("Platform Rotation")]
	[SerializeField] [Min(0.0f)] private float _maxYRotation;
	[SerializeField] [Min(0.0f)] private float _minYRotation;

	[Header("Tower")]
	[SerializeField] private Transform _tower;
	
	[SerializeField][Min(0)] private int _platformVariantCount;
	[SerializeField] [Min(0.0f)] private float _offsetBetweenPlatforms;
	[Header("Platforms")]
	[SerializeField] private Platform _startPlatformPrefab;
	[SerializeField] private Platform _finishPlatformPrefab;
	[SerializeField] private Platform[] _platformVariants = Array.Empty<Platform>();


	private void Start()
	{
		Generate();
	}

	private void Generate()
	{
		float offsetFromTop = _offsetBetweenPlatforms;

		Platform startPlatform = Create(_startPlatformPrefab, ref offsetFromTop);

		for (int i = 0; i < _platformVariantCount; i++)
		{
			Platform platform = Create(_platformVariants.Random(), ref offsetFromTop) ;
		}
		Platform finishPlatform = Create(_finishPlatformPrefab, ref offsetFromTop);
		

	}

	private void FitTowerHeight(Transform tower)
	{
		Vector3 originalSize = tower.localScale;
	}
	private Platform Create(Platform platformPrefab, ref float offsetFromTop)
	{
		Platform createdPlatform = Instantiate(platformPrefab);
		Transform platformTransform = createdPlatform.transform;
		platformTransform.position = Vector3.down * offsetFromTop;
		platformTransform.eulerAngles = GetRandomYRotation();
		offsetFromTop += platformTransform.localScale.y + _offsetBetweenPlatforms;

		return createdPlatform;
	}
	private Vector3 GetRandomYRotation() => 
		Vector3.up * Random.Range(_minYRotation, _maxYRotation);
}
