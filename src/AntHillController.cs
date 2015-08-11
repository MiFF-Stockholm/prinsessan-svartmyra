using UnityEngine;
using System.Collections;

public class AntHillController : MonoBehaviour {
	private GameController gameController;
	private Sprite[] alternateSprites;
	
	void Start () {
		Debug.Log ("Init AntHillController");
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
		alternateSprites = new Sprite[4];
		alternateSprites[0] = Resources.Load<Sprite> ("Sprites/Castle2");
		alternateSprites[1] = Resources.Load<Sprite> ("Sprites/Castle3");
		alternateSprites[2] = Resources.Load<Sprite> ("Sprites/Castle4");
		alternateSprites[3] = Resources.Load<Sprite> ("Sprites/Castle5");
	}
	
	void Update () {
		int lives = gameController.GetLives ();
		if (lives <= 10) {
			GetComponent<SpriteRenderer>().sprite = alternateSprites[3];
		} else if (lives <= 25) {
			GetComponent<SpriteRenderer>().sprite = alternateSprites[2];
		} else if (lives <= 50) {
			GetComponent<SpriteRenderer>().sprite = alternateSprites[1];
		} else if (lives <= 75) {
			GetComponent<SpriteRenderer>().sprite = alternateSprites[0];
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Ant") {
			int lifeValue = col.gameObject.GetComponent<AntProperties>().lifeValue;
			Destroy(col.gameObject);
			gameController.DecreaseLife(lifeValue);
		}
	}
	/*void OnTriggerEnter(Collider col) {
		if (col.tag == "Ant") {
			life--;
			Destroy(col.transform.parent.gameObject);
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.transform.tag == "Ant") {
			life--;
			Destroy(col.transform.parent.gameObject);
		}
	}*/
}
