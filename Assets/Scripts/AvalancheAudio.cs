using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheAudio : MonoBehaviour {

    private AudioSource source;
    private int counter;
    private bool stopAvalanche;
    private bool startAvalanche;
    // Use this for initialization
    void Start () {
        source = this.GetComponent<AudioSource>();
        source.volume = 0.0f;
        stopAvalanche = false;
        startAvalanche = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (startAvalanche)
        {
            source.volume += 0.001f;
            if (source.volume > 0.6f)
            {
                startAvalanche = false;
            }
        }
        if (stopAvalanche)
        {   
            if (source.volume - 0.01f > 0)
            {
                source.volume -= 0.01f;
            }
            else if (source.volume - 0.01f <= 0)
            {
                source.volume = 0.0f;
            }
            
        }
        
	}

    public void stopAudio()
    {
        stopAvalanche = true;
    }

}
