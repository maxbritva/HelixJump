
using System;
using System.Collections.Generic;
using Extensions;
using Platforms;
using Structures;
using Tower;
using UnityEngine;

public class TowerGenerator : MonoBehaviour 
{
	[SerializeField] private TowerGenerationSettingsSo _generationSettings;
	
	[Header("Tower")]
	[SerializeField] private Transform _tower;

	private FloatRange RotationRange => _generationSettings.RotationRange;
	private void Start()
	{
		Generate(_generationSettings,_tower);
	}

	private void Generate(TowerGenerationSettingsSo generationSettings,Transform tower)
	{
		List<Platform> spawnedPlatforms = SpawnPlatforms(generationSettings, out float offsetFromTop);
		FitTowerHeight(tower, offsetFromTop);
		spawnedPlatforms.ForEach(platform => platform.transform.SetParent(tower));
	}
	
	private List<Platform> SpawnPlatforms(TowerGenerationSettingsSo generationSettingsSo,out float offsetFromTop)
	{ 
	offsetFromTop = _generationSettings.OffsetBetweenPlatforms;
	const int startAndLastPlatforms = 2;
	var spawnedPlatforms = new List<Platform>(_generationSettings.PlatformVariantCount + startAndLastPlatforms);
	Platform startPlatform = Create(_generationSettings.StartPlatformPrefab, RotationRange, ref offsetFromTop);
	spawnedPlatforms.Add(startPlatform);
		for (int i = 0; i < _generationSettings.PlatformVariantCount; i++)
	{
		Platform platform = Create(_generationSettings.PlatformVariantPrefab, RotationRange, ref offsetFromTop) ;
		spawnedPlatforms.Add(platform);
	}
	Platform finishPlatform = Create(_generationSettings.FinishPlatformPrefab,RotationRange, ref offsetFromTop);
	spawnedPlatforms.Add(finishPlatform);

	return spawnedPlatforms;
	}

	private void FitTowerHeight(Transform tower, float height)
	{
		Vector3 originalSize = tower.localScale;
		float towerHeight = height / 2.0f;
		tower.localScale = new Vector3(originalSize.x, towerHeight , originalSize.z);
		tower.localPosition -= Vector3.up * towerHeight;
	}
	
	private Vector3 GetRandomYRotation(FloatRange rotationRange) =>
		Vector3.up * rotationRange.Random;
	private Platform Create(Platform platformPrefab,FloatRange rotationRange ,ref float offsetFromTop)
	{
		Platform createdPlatform = Instantiate(platformPrefab);
		Transform platformTransform = createdPlatform.transform;
		platformTransform.position = Vector3.down * offsetFromTop;
		platformTransform.eulerAngles = GetRandomYRotation(rotationRange);
		offsetFromTop += platformTransform.localScale.y + _generationSettings.OffsetBetweenPlatforms;

		return createdPlatform;
	}


	
}
