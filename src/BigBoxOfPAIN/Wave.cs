using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour{


	public List<Enemy> enemyList;
	public float waveTimer = 40f;
	public Vector2 spawnValue;

	private int totalEnemyCount = 0;
	private float timeBetweenSpawns;
	private float spawnCooldown = 0;

	// Use this for initialization
	public void InitWave () {
		Debug.Log("Start Wave");
		foreach( Enemy e in enemyList){
			totalEnemyCount += e.GetNumberOfEnemies();
		}

		if(totalEnemyCount == 0){
			throw new DontBeStupidException();
		}

		timeBetweenSpawns = waveTimer/totalEnemyCount;

		Debug.Log("Time Between Spawns : " + timeBetweenSpawns);
	}


	public void UpdateWave (float deltaTime) {
		if(spawnCooldown <= 0 && enemyList.Count != 0){
//			Debug.Log("Spawn Enemy");
			spawnCooldown = timeBetweenSpawns;
			Vector2 spawnPosition = GetRandomPos();
			Quaternion spawnRotation = Quaternion.identity;
			GameObject enemy = ChooseRandomEnemy();
			SpawnEnemy(enemy, spawnPosition, spawnRotation);
		}else{
			spawnCooldown -= deltaTime;
		}
	}

	public int GetNumberOfEnemies(){
		int enemyCounter = 0;
		foreach( Enemy e in enemyList){
			enemyCounter += e.GetNumberOfEnemies();
		}

		return enemyCounter;
	}


	GameObject ChooseRandomEnemy(){
		int random  = Random.Range(0,enemyList.Count);
		Enemy enemy = (Enemy)enemyList[random];//IndexOf(random);
		GameObject enemyObj = enemy.GetNextEnemy();
		if(enemy.GetNumberOfEnemies() == 0){
			enemyList.Remove(enemy);
		}
		return enemyObj;
	}

	void SpawnEnemy(Object enemy, Vector2 spawnPosition, Quaternion spawnRotation){
		Instantiate (enemy, spawnPosition, spawnRotation);
	}

	Vector2 GetRandomPos()
	{
		Vector2 spawnPosition;
		int random  = Random.Range(1,5);
		switch(random){
		case 1:
			spawnPosition = new Vector2(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y);
			break;
		case 2:
			spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));
			break;
		case 3:
			spawnPosition = new Vector2(-spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));
			break;
		case 4:
			spawnPosition = new Vector2(Random.Range(-spawnValue.x, spawnValue.x), -spawnValue.y);
			break;
		default:
			spawnPosition = new Vector2(Random.Range(-spawnValue.x, spawnValue.x), -spawnValue.y);
			break;
		}
		return spawnPosition;
	}
	


}
