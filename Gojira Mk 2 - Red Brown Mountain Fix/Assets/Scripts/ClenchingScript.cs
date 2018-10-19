using UnityEngine;
using System.Collections;

public class ClenchingScript : MonoBehaviour {
	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	public bool GripIsPressed = false;
	static bool DEBUG = true;
	Animator anim;
	// Use this for initialization
	void Awake () {
		trackedObj = gameObject.GetComponentInParent<SteamVR_TrackedObject>();
		anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("GripIsPressed", false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
			if (DEBUG) Debug.Log ("Trigger in Clenching is PressedDown");
			anim.SetBool ("GripIsPressed", true);
			GripIsPressed = true;
		}
		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
			if (DEBUG) Debug.Log ("Trigger in Clenching is PressedUp");
			anim.SetBool ("GripIsPressed", false);
			GripIsPressed = false;
		}
	}
}
