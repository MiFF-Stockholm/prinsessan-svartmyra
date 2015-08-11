using UnityEngine;
using System.Collections;

public abstract class BasicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public abstract void NonFatalCollision();
	public abstract void FatalCollision();		
}
