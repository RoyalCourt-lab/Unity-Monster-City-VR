using UnityEngine;
using System.Collections;

public class destroyedBooster : MonoBehaviour {

	public int addition;
	public string selfTag;
	static bool DEBUG = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter (Collider col) {
		if (!col.gameObject.tag.Equals (selfTag) && !col.name.Contains("Pointer")) {
			if (!col.name.Contains ("PlayerObject_Controller")) {
				Burn (col);
			} else if (!col.gameObject.GetComponent<Rigidbody> ().isKinematic) {
				Burn (col);
			}
		}
	}

	void Burn(Collider col) {
		GameObject gb = GameObject.FindGameObjectWithTag ("Tally");
		destroyedTally tally = gb.GetComponent<destroyedTally> ();
		if (DEBUG) Debug.Log ("Colliding with " + col.name);
		tally.Booster (addition);
		BoxCollider b = gameObject.GetComponent<BoxCollider> ();
		b.enabled = false;
	}
}
