using UnityEngine;
using System.Collections;

public class CanonPowerUp : PowerUp
{
	public int ammo = 10;
	public GameObject bullet;

	public override void Use (PlayerController user)
	{
		Debug.Log (user);
		Rigidbody2D newBullet = Instantiate (bullet, user.transform.position, user.transform.rotation) as Rigidbody2D;
		ammo--;

		if (ammo <= 0) {
			user.RemovePowerUp(this);
		}
	}
}


