using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheController : MonoBehaviour {

    public int thrust;

    private Rigidbody body;
    private ParticleSystem ps;
    private float currSpeed;
    private bool endAvalanche;
    
    // Use this for initialization
    void Start () {
        ps = this.GetComponent<ParticleSystem>();
        currSpeed = ps.main.simulationSpeed;
        endAvalanche = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (ps.time>30)
        {
            this.GetComponent<AvalancheAudio>().stopAudio();
            if (currSpeed > 0)
            {
                currSpeed-=0.1f;
                if (currSpeed < 0)
                {
                    currSpeed = 0;
                    endAvalanche = true;
                }
                var main = ps.main;
                main.simulationSpeed = currSpeed;
            }
        }
        
	}

    public bool getEndAvalanche()
    {
        return endAvalanche;
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
