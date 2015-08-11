using UnityEngine;
using System.Collections;

public class WarriorAntCollisionController : MonoBehaviour {
	AntProperties antProperties;
	// Use this for initialization
	void Start () {
		antProperties = GetComponent<AntProperties>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag.Equals("Player")) {
			PlayerProperties playerProperties = other.GetComponent<PlayerProperties>();
			playerProperties.setStunned();
			antProperties.setStunned();
		}
	}
}
