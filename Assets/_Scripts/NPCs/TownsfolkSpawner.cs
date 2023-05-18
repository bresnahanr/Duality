using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TownsfolkSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRadius;

	private void OnEnable()
	{
		TimeManager.OnDayModeReached += SpawnTownsfolkRandomLocation;
	}

	private void OnDisable()
	{
		TimeManager.OnDayModeReached -= SpawnTownsfolkRandomLocation;
	}

	void SpawnTownsfolkRandomLocation()
	{
        //find random location on navmesh
        NavMeshHit hit;
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        NavMesh.SamplePosition(randomDirection, out hit, spawnRadius, 1);
        Vector3 spawnLocation = hit.position;

        Instantiate(prefab, spawnLocation, Quaternion.identity);
        
        //instantiate prefab at location
	}

}
