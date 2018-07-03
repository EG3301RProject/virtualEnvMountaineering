using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class lefthand : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;

	void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void FixedUpdate () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Left hand is holding Trigger");
        }
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log("Left hand has collided with " + col.name);
    }


}
