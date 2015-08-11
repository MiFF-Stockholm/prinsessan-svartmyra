using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Rect cameraRect;
	public float turnSpeed;
	public List<PowerUp> powerUps = new List<PowerUp> ();
	private bool invertedControls = false;
	[Range(1,4)]
	public int
		player = 1;
	private Transform tongue;
	private bool tongueStretch;
	private Vector3 tongueOriginalScale;
	private Vector3 tongueOriginalPosition;
	private float tongueStretchTime;
	public float tongueStretchFactor = 2;
	private PlayerProperties playerProps;

	void Start ()
	{
		tongue = transform.FindChild ("Tongue parent");
		playerProps = GetComponent<PlayerProperties> ();
		tongueOriginalScale = tongue.localScale;
		tongueOriginalPosition = tongue.localPosition;
	}
	
	void FixedUpdate ()
	{
		// Movement
		bool left = false;
		bool right = false;
		if (!invertedControls) {
			left = Input.GetButton ("Left" + player);
			right = Input.GetButton ("Right" + player);
		} else {
			left = Input.GetButton ("Right" + player);
			right = Input.GetButton ("Left" + player);
		}

		// Hack to avoid sliding
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		if (!playerProps.isStunned ()) {
			transform.Translate (Vector3.up * Time.deltaTime * speed);

			if (left) {
				transform.Rotate (Vector3.forward * Time.deltaTime * turnSpeed);
			} 

			if (right) {
				transform.Rotate (Vector3.back * Time.deltaTime * turnSpeed);
			}
		}

		GetComponent<Rigidbody2D> ().position = new Vector3 (
			Mathf.Clamp (transform.position.x, cameraRect.xMin, cameraRect.xMax),
			Mathf.Clamp (transform.position.y, cameraRect.yMin, cameraRect.yMax),
			transform.position.z);

		// Fire
		// FIIIIRREE!!! ARHGHGH!
		bool fire = Input.GetButtonDown ("Fire" + player);

		if (fire) {
			if (powerUps.Count != 0) {
				// Use random powerup from list?
				int i = Random.Range (0, powerUps.Count);
				PowerUp pu = powerUps [i];
				pu.Use (this);
			}

			// Fire
			tongueStretch = true;
		}


		//
		// Animations
		//

		// Update tongue
		tongue.Rotate (0, 404 * Time.deltaTime * 3.14f, 0);

		// Tongue stretch
		if (tongueStretch) {
			tongueStretchTime += Time.deltaTime * 3.14f;
			// Mmmm... pie
			float v = Mathf.Sin (tongueStretchTime);

			tongue.localScale = new Vector3 (tongueOriginalScale.x, tongueStretchFactor * v + tongueOriginalScale.y, tongueOriginalScale.z);

			//tongue.transform.position = new Vector3(tongue.position.x, transform.position.y, tongue.position.z);
			//tongue.localPosition = new Vector3 (tongue.localPosition.x, tongue.localPosition.y+v, tongue.localPosition.z);
			if (tongue.localScale.y <= tongueOriginalScale.y) {
				tongueStretch = false;
				tongue.localScale = tongueOriginalScale;
				tongue.localPosition = tongueOriginalPosition;
				tongueStretchTime = 0;
			}
		} 
	}

	void OnTriggerEnter (Collider other)
	{
		PowerUp pu = other.GetComponent<PowerUp> ();
		// om nom nom... honey!

		if (pu != null) {
			powerUps.Add (pu);
		}
	}

	public void RemovePowerUp (PowerUp powerUp)
	{
		powerUps.Remove (powerUp);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag.Equals ("Powerup")) {
			GameController gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
			gameController.AddScore (50, player);
			gameController.AddLives (1);

			Destroy (other.gameObject);
		}
	}

	public void invertControls ()
	{
		invertedControls = true;
		StartCoroutine (resetControlsAfterTimeout ());
		Debug.Log ("Controls inverted");
	}

	IEnumerator resetControlsAfterTimeout ()
	{
		yield return new WaitForSeconds (5f);
		invertedControls = false;
		Debug.Log ("Controls reset to normal");
	}
}
