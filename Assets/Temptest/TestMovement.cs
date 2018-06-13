using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{

    public GameObject player;
    public float thrust;
    private Rigidbody rb;
    private Rigidbody currrb;
    private SteamVR_TrackedObject trackedObj;

    // 1
    private GameObject collidingObject;
    // 2
    private GameObject objectInHand;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        rb = player.GetComponent<Rigidbody>();
        currrb = GetComponent<Rigidbody>();
    }

    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject)
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    // 1
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        if(collidingObject == null)
        {
            Debug.Log("not detected");
        }
        else if(collidingObject.name == "SwimController")
        {
            rb.AddForce(transform.forward * thrust);
            Debug.Log("I'm in");
        }
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currrb.AddForce(transform.forward * thrust);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currrb.AddForce(-transform.forward * thrust);
        }
    }
}

