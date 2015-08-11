using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {

	private bool _isStunned = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setStunned() {
		Debug.Log ("IsStunned!!!");
		StartCoroutine(this.removeStun(2.5f)); 
	}

	IEnumerator removeStun(float time) {
		_isStunned = true;
		yield return new WaitForSeconds(time);
		_isStunned = false;
	}

	public bool isStunned() {
		return _isStunned;
	}
}
