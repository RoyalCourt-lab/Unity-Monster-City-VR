using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkConnector : MonoBehaviour {

	public List<FracturedChunk> connected = new List<FracturedChunk>();
	Rigidbody obj;
	int count = 0;
	int chunkArrLength;

	void Start () {
		obj = gameObject.GetComponent<Rigidbody>();
		chunkArrLength = connected.Count;
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < connected.Count; i++) {
			if (connected[i].IsDetachedChunk) {
				count++;
				connected.RemoveAt(i);
			}
		}
		if (count == chunkArrLength) {
			obj.isKinematic = false;
			obj.AddRelativeForce (Vector3.down * 2);
			Debug.Log ("Force is being applied.");
			Destroy (this);
		}
	}
}
