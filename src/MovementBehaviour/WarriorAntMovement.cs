using UnityEngine;
using System.Collections;

public class WarriorAntMovement : Movement {

	GameObject closestPlayer;

	public override Vector3 GetNewDirection (Vector3 myPos)
	{

		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

		float closestX = float.MaxValue;
		float closestY = float.MaxValue;

		foreach( GameObject playerObj in players){
			float distanceX = Mathf.Abs(playerObj.transform.position.x - myPos.x);
			float distanceY = Mathf.Abs(playerObj.transform.position.y - myPos.y);

			if((distanceX + distanceY) < (closestX + closestY)){
				closestPlayer = playerObj;
				closestX = distanceX;
				closestY = distanceY;
			}
		}

		return (closestPlayer.transform.position - myPos).normalized;
	}

	public override void UpdateMovement (Rigidbody2D rigidbody2D)
	{
		throw new System.NotImplementedException ();
	}
}
