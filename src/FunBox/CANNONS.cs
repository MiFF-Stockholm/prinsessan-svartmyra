using UnityEngine;
using System.Collections;

public class CANNONS : MonoBehaviour {

	public string fireButton = "Fire1";
	public Rigidbody2D bullet;
	public float velocity = 10.0f;
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown(fireButton))
		{
			Rigidbody2D newBullet = Instantiate(bullet,transform.position,transform.rotation) as Rigidbody2D;
		}
	}
}