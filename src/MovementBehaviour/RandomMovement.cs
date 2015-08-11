using UnityEngine;
using System.Collections;

public class RandomMovement : Movement
{
	
	public GameObject target;
	public float updateRandomTargetTimer;
	private float timeSinceLastUpdate = 0;
	private float randomX;
	private float randomY;
	private Vector3 randomTarget;

	public override Vector3 GetNewDirection (Vector3 myPos)
	{
		timeSinceLastUpdate += Time.deltaTime;
		Vector3 dir = (target.transform.position - myPos).normalized;
		Vector3 randDir = Random.insideUnitSphere;
		randDir.Scale (new Vector3 (0.5f, 0.5f, 0.5f));
		Vector3 randTarget = (randDir + dir);
		Debug.Log ("randTarget: " + randTarget);
		return randTarget;
	}

	public override void UpdateMovement (Rigidbody2D rigidbody2D)
	{
		//Vector3 movement = GetNewDirection(target.transform.position);
		
		//rigidbody2D.velocity = movement;
	}
}
