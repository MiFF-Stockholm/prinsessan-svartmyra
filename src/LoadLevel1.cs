using UnityEngine;
using System.Collections;

public class LoadLevel1 : MonoBehaviour {

	public string levelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick() {
		Application.LoadLevel (levelName);
	}
}
