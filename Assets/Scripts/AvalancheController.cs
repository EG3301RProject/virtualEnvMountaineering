using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheController : MonoBehaviour {

    public int thrust;

    private Rigidbody body;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        if (other.name == "Player")
        {
            body = other.GetComponent<Rigidbody>();
            body.AddForce(other.transform.forward * -thrust);
        }
    }
}
