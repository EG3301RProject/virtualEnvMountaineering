using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class OnContactLeft : MonoBehaviour { 
    public GameObject breaststroke_text;

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

        if(col.gameObject.name =="Cube")
        {
        StartCoroutine(ShowAndHide(breaststroke_text, 1f));
    }

        Debug.Log("Left hand collided with " + col.name);
    }

IEnumerator ShowAndHide(GameObject go, float delay)
{
    go.SetActive(true);
    yield return new WaitForSeconds(delay);
    go.SetActive(false);
}

}