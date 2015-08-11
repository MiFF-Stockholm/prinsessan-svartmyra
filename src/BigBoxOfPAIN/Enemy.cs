using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour{
	
	public GameObject enemyPrefab;
	public int numberOfEnemies = 1;
	
	public int GetNumberOfEnemies(){
		return numberOfEnemies;
		
	}
	
	public GameObject GetNextEnemy(){
		if(numberOfEnemies > 0){
			numberOfEnemies--;
			return enemyPrefab;
		}
		
		return null;
	}
}