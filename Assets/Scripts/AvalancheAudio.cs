using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheAudio : MonoBehaviour {

    private AudioSource source;
    private int counter;
	// Use this for initialization
	void Start () {
        source = this.GetComponent<AudioSource>();
        source.volume = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (source.volume <= 0.25f)
        {
            source.volume += 0.001f;
        } 
	}
}
