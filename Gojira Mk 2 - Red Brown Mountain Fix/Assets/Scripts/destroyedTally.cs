using UnityEngine;
using System.Collections;

public class destroyedTally : MonoBehaviour {

	public int destroyed = 0;
	TextMesh tMesh;
	// Use this for initialization
	void Start () {
		tMesh = GetComponent<TextMesh>();
		tMesh.text = "Destroyed: " + destroyed + "%";

	}
	
	// Update is called once per frame
	void Update () {
		if (destroyed == 100) {
			tMesh.text = "Destroyed: " + destroyed + "%\nLevel Complete!";
		} else {
			tMesh.text = "Destroyed: " + destroyed + "%";
		}
	}

	public void Booster (int addition) {
		destroyed += addition;
	}
}
