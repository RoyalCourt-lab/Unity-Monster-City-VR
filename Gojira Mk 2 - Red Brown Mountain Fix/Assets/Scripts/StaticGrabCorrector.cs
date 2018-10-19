using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

//Script used to fix a bug where you could grab a fractured chunk while it was still in a static Fractured Object.
public class StaticGrabCorrector : MonoBehaviour {

	FracturedChunk cScript;
	bool DEBUG = false;
	VRTK_InteractableObject vio;

	void Start () {
		vio = gameObject.GetComponent<VRTK_InteractableObject> ();
		cScript = gameObject.GetComponent<FracturedChunk>();
		vio.isGrabbable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (cScript.IsDetachedChunk) {
			if(DEBUG) Debug.Log ("Chunk is Detached");
			vio.isGrabbable = true;
		}
	}
}
