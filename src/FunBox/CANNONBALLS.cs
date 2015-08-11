using UnityEngine;
using System.Collections;

public class CANNONBALLS : MonoBehaviour {

	public float speed = 10.0f;
	public Rect cameraRect;
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * Time.deltaTime * speed);

		if(!cameraRect.Contains(this.transform.position)){
			Destroy(this.gameObject);
		}
	}
}
