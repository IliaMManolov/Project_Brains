using UnityEngine;
using System.Collections;

public class SpawnWave : MonoBehaviour {

	public GameObject enemy;
	public int enemiesPerWave;
	public int enemiesSpawned;
	public int enemiesDead;
	public float spawnStart;
	public float spawnFixed;
	
	void Start () {
	}

	void Update () {
		if (enemiesSpawned != enemiesPerWave) {
			if (Time.time  >= spawnStart) {
				SpawnEnemy ();
				spawnStart = spawnStart + spawnFixed;
				enemiesSpawned++;
			}
		}
	}

	void WaveSpawn () {

	}
	void SpawnEnemy () {

		Instantiate (enemy, new Vector3 (-6F, 0, -3F), Quaternion.identity);
	}
}
