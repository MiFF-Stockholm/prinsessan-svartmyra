using UnityEngine;
using System.Collections;

public class DancingAntController : MonoBehaviour {

	private new Rigidbody2D rigidbody2D;
	public Transform target;

	public float rotationSpeed = 0.001f;

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 dir = (target.position - transform.position).normalized;
		Debug.DrawRay (transform.position, dir, Color.red);
		rigidbody2D.velocity = new Vector2(dir.x, dir.y);

		//find the vector pointing from our position to the target
		Quaternion lookRotation = Quaternion.LookRotation(dir, Vector3.forward);
		lookRotation.x = 0;
		lookRotation.y = 0;

		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

	}
}
