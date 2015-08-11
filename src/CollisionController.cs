using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

	public string[] fatalCollisions;
	public string[] nonFatalCollision;

	private BasicController controller;

	// Use this for initialization
	void Start () {
		controller = (BasicController) this.gameObject.GetComponent(typeof(BasicController));
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){
		//checkFatal
		foreach(string tag in fatalCollisions){
			if(other.CompareTag(tag)){
				controller.FatalCollision();
			}
		}

		//checkNonFatal
		foreach(string tag in nonFatalCollision){
			if(other.CompareTag(tag)){
				controller.NonFatalCollision();
			}
		}
	}
}
