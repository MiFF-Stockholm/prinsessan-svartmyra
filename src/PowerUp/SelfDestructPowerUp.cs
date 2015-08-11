using UnityEngine;
using System;

public class SelfDestructPowerUp : PowerUp
{
	public override void Use(PlayerController user) 
	{
		Debug.Log ("POFF!");
		user.GetComponent<SpriteRenderer> ().material.color = Color.black;
	}
	
}

