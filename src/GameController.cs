using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	//Look upon my works, ye mighty, and despair - Lord Byron

	public GameObject scorePowerUp;
	public GameObject antHill;
	public GameObject[] ants;
	public Vector2 spawnValue;
	public float startWait;
	public int life = 100;
	public float powerUpTime = 5f;
	public List<Wave> waveList;
	public float timeBetweenWaves = 40f;
	private float waveCooldown = 0;
	private Wave activeWave = null;
	public GUIText lifeText;
	public GUIText scoreText;
	public GUIText gameoverText;
	public GUIText restartText;
	public GUIText timeIsPassedText;
	private bool gameOver;
	private bool restart;
	private int[] score = {0,0,0,0};

	// Sets the stage at play.
	void Start ()
	{
		gameOver = false;
		restart = false;
		gameoverText.text = "";
		restartText.text = "";
		scoreText.text = "";

		UpdateLife ();
		UpdateScore ();

		StartCoroutine (spawnScorePowerUp ());

		foreach (Wave w in waveList) {
			w.InitWave ();
		}
		
		if (waveList.Count == 0) {
			throw new DontBeStupidException ();
		}
	}
	
	void Update ()
	{
		if (!gameOver) {
			CALL_ON_WAVELORD_3000 ();
		}

		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void CALL_ON_WAVELORD_3000 ()
	{
		if (activeWave != null && activeWave.GetNumberOfEnemies () != 0) {
			activeWave.UpdateWave (Time.deltaTime);
		} else if (waveCooldown <= 0 && waveList.Count != 0) {
			Debug.Log ("New Wave");
			waveCooldown = timeBetweenWaves;
			activeWave = waveList [0];
			waveList.Remove (activeWave);
		} else if (waveList.Count == 0) {
			if (GameObject.FindGameObjectsWithTag ("Ant").Length == 0) {
				gameOver = true;
				restartText.text = "Press 'R' to restart!";
				restart = true;
			}
		} else {
			waveCooldown -= Time.deltaTime;
		}
	}

	IEnumerator spawnScorePowerUp ()
	{
		yield return new WaitForSeconds (powerUpTime);
		while (!gameOver) {
			float spawnPosX = antHill.transform.position.x + Random.Range (-5, 5);
			float spawnPosY = antHill.transform.position.y + Random.Range (-5, 5);
			Vector2 spawnPosition = new Vector2 (spawnPosX, spawnPosY);
			Quaternion spawnRotation = Quaternion.identity;
			Object spawnedObj = Instantiate (scorePowerUp, spawnPosition, spawnRotation);
			StartCoroutine (destroyAfterTimeout (spawnedObj));
			yield return new WaitForSeconds (powerUpTime);
		}

	}

	IEnumerator destroyAfterTimeout (Object powerup)
	{
		yield return new WaitForSeconds (powerUpTime);
		if (powerup != null) {
			Destroy (powerup);
		}
	}

	int antNr = 0;

	public GameObject getAnt ()
	{
		return ants [antNr++ % ants.Length];
	}

	public void AddScore (int newScoreValue, int player)
	{
		score [player - 1] += newScoreValue;
		UpdateScore ();
	}

	public void AddLives (int newLifeValue)
	{
		life += newLifeValue;
		UpdateLife ();
	}

	void UpdateScore ()
	{
		scoreText.text = "";
		for (int i = 0; i < score.Length; i++) {
			scoreText.text += "Player" + (i + 1) + " Score: " + score [i] + "\n"; 
		}
	}

	public void GameOver ()
	{
		gameoverText.text = "Game Over!";
		restartText.text = "Press 'R' to restart!";
		restart = true;
		gameOver = true;
		GameObject[] ants = GameObject.FindGameObjectsWithTag ("Ant");
		foreach (GameObject go in ants) {
			Destroy (go);
		}
	}

	public void DecreaseLife (int newLifeValue)
	{
		life += newLifeValue;
		UpdateLife ();
		if (life <= 0) {
			GameOver ();
		}
	}

	void UpdateLife ()
	{
		lifeText.text = "Life: " + life; 
	}

	public int GetLives ()
	{
		return life;
	}
}
//Sleep is for the weak - Leila