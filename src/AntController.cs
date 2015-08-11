using UnityEngine;
using System.Collections;

public class AntController : MonoBehaviour {

	private new Rigidbody2D rigidbody2D;
	public Movement movement;
	public bool isPoisonous = false;
	public Sprite altTex;
	AntProperties antProps;

	public float rotationSpeed = 100f;

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		float rand = Random.Range (0f, 100f);
		antProps = GetComponent<AntProperties> ();
		if (rand <= 10f) {
			isPoisonous = true;
			GetComponentInChildren<SpriteRenderer>().sprite = altTex;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 dir = movement.GetNewDirection (transform.position);
		Debug.DrawRay (transform.position, dir, Color.red);
		if (!antProps.isStunned ()) {
			rigidbody2D.velocity = new Vector2 (dir.x, dir.y);
		} else {
			rigidbody2D.velocity = Vector2.zero;
		}

		//find the vector pointing from our position to the target
		Quaternion lookRotation = Quaternion.LookRotation(dir, Vector3.forward);
		lookRotation.x = 0;
		lookRotation.y = 0;

		//transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
		transform.rotation = lookRotation;
	}
}
