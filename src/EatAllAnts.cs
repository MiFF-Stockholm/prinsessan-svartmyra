using UnityEngine;
using System.Collections;

public class EatAllAnts : MonoBehaviour {

	public AudioClip eatAntSound;
	public int scoreValue;
	[Range(1,4)]
	public int player = 1;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		Debug.Log ("Init EatAllAnts");
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Ant") {
			AudioSource audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
			audioSource.PlayOneShot(eatAntSound);

			AntController ac = other.gameObject.GetComponent<AntController>();
			if (ac.isPoisonous) {
				PlayerController pc = transform.parent.parent.gameObject.GetComponent<PlayerController>();
				pc.invertControls();
			}

			Destroy(other.gameObject);
			gameController.AddScore(scoreValue, player);
		}
	}
}
