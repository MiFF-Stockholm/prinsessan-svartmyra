using UnityEngine;
using System.Collections;

public class SlalomAntMovement : Movement
{
	
	public Transform target;
	public float updateRandomTargetTimer = 1;
	private float timeSinceLastUpdate = 0;
	private float randomX;
	private float randomY;
	private Vector3 randomTarget;

	public override Vector3 GetNewDirection (Vector3 myPos)
	{

		if (timeSinceLastUpdate > updateRandomTargetTimer) {
			timeSinceLastUpdate = 0;

			float rangeX = Mathf.Abs(myPos.x - target.position.x);
			float rangeY = Mathf.Abs(myPos.y - target.position.y);

			randomX = Random.Range (-randomX, rangeX*2);
			randomY = Random.Range (-randomY, rangeY*2);
		
		
			randomTarget = target.position;
			randomTarget.x += randomX/2;
			randomTarget.y += randomY/2;

		}

		timeSinceLastUpdate += Time.deltaTime;
		return (randomTarget - myPos).normalized;
	}

	public override void UpdateMovement (Rigidbody2D rigidbody2D)
	{
		throw new System.NotImplementedException ();
	}
}
