using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SmashingClench : MonoBehaviour {
	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	Renderer rend;
	bool inCollision = false;
	public VRTK_ObjectAutoGrab scriptB;
	public GameObject grabbed;


	void Awake () {
		trackedObj = gameObject.GetComponentInParent<SteamVR_TrackedObject>();
		rend = grabbed.GetComponentInChildren<Renderer> ();
		scriptB.enabled = false;
		grabbed.SetActive (false);
		//clenched1 = clenchedHand1.GetComponentInChildren<Renderer> ();
	}
	

	void FixedUpdate () {
		device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && !inCollision) {
			Material[] mat = rend.materials;
			foreach (Material m in mat) {
				m.shader = Shader.Find ("Standard");
			}
			grabbed.SetActive (true);
			scriptB.enabled = true;

		}

		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
			Material[] mat = rend.materials;
			foreach (Material m in mat) {
				m.shader = Shader.Find ("Particles/Additive (Soft)");
			}
			scriptB.enabled = false;
			grabbed.GetComponent<VRTK_InteractableObject>().ForceStopInteracting ();
			grabbed.SetActive (false);
		}
	}

	void OnTriggerEnter(Collider col) {
		if (!col.gameObject.name.Equals ("Head") && !col.gameObject.name.Equals ("Model") && !col.gameObject.name.Equals ("SideA") && !col.gameObject.name.Equals ("Body") &&
		   !col.gameObject.name.Equals ("SideB") && !col.gameObject.name.Contains ("Cursor") && !col.gameObject.name.Equals ("Armature") && !col.gameObject.name.Equals ("Circle")
			&& !col.gameObject.name.Contains ("Pointer") && !col.gameObject.tag.Equals ("GrabbedHand")) {
			Debug.Log ("Colliding with " + col.gameObject.name);
			inCollision = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (!col.gameObject.name.Equals ("Head") && !col.gameObject.name.Equals ("Model") && !col.gameObject.name.Equals ("SideA") && !col.gameObject.name.Equals ("Body") &&
		   !col.gameObject.name.Equals ("SideB") && !col.gameObject.name.Contains ("Cursor") && !col.gameObject.name.Equals ("Armature") && !col.gameObject.name.Equals ("Circle")
			&& !col.gameObject.name.Contains ("Pointer") && !col.gameObject.tag.Equals ("GrabbedHand")) {
			Debug.Log ("No longer colliding with " + col.gameObject.name);
			inCollision = false;
		}
	}
}
