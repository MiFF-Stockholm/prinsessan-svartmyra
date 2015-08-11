using UnityEngine;
using System.Collections;

public class BasicAntMovement : Movement {

	public float speed;
	public GameObject target;

	public override void UpdateMovement(Rigidbody2D rigidbody2D){
//		GameObject target = GameObject.FindGameObjectWithTag("AntTarget");
//		Vector3 dir = (target.transform.position - transform.position).normalized;
//		rigidbody2D.velocity = new Vector2(dir.x, dir.y);
//		Debug.Log("velocity: " + rigidbody2D.velocity);
//		Debug.Log("position: " + rigidbody2D.position);

		Vector3 dir = (target.transform.position - transform.position).normalized;
		Debug.DrawRay (transform.position, dir, Color.red);
		rigidbody2D.velocity = new Vector2(dir.x, dir.y);
	}

	public override Vector3 GetNewDirection (Vector3 myPos)
	{
		return (target.transform.position - myPos).normalized;
	}
}
