using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondScript : MonoBehaviour {

    private bool WinGame;
    private GameObject avalanche;
	// Use this for initialization
	void Start () {
        WinGame = false;
        avalanche = GameObject.Find("Active Avalanche");
        //this.GetComponent<AudioSource>().Play(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(avalanche.GetComponent<AvalancheController>().getEndAvalanche() && other.gameObject.name == "PlayerCollider")
        {
            WinGame = true;
        }
    }

    public bool getWinCond()
    {
        return WinGame;
    }
}
