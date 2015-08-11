using UnityEngine;
using System.Collections;

public abstract class Movement : MonoBehaviour {

	public abstract void UpdateMovement(Rigidbody2D rigidbody2D);

	public abstract Vector3 GetNewDirection(Vector3 myPos);
}
