using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class OnContactRight : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;


    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);

    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log("Right hand collided with" + col.name);
    }
}
