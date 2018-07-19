using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondScript : MonoBehaviour {

    /*public Text gameOverText;
    public Button startButton;
    public Button retryButton;
    public GameObject panel;*/

    private bool WinGame;
    private GameObject avalanche;
    private bool playMusic;
    private GameObject canvas;
    // Use this for initialization
    void Start () {
        WinGame = false;
        avalanche = GameObject.Find("Active Avalanche");
        playMusic = false;
        //canvas = GameObject.Find("Canvas");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(avalanche.GetComponent<AvalancheController>().getEndAvalanche() && other.gameObject.name == "PlayerCollider")
        {
            WinGame = true;
            if (!playMusic)
            {
                this.GetComponent<AudioSource>().Play(0);
                /*gameOverText.text = "You Survived";
                startButton.gameObject.SetActive(false);
                Invoke("setRetryButton", 4);
                FadeIn();*/
                playMusic = true;
            }
        }
    }

    public bool getWinCond()
    {
        return WinGame;
    }

    /*void setRetryButton()
    {
        retryButton.gameObject.SetActive(true);
        retryButton.interactable = true;
    }*/


    public void FadeIn()
    {
        StartCoroutine(Dofade());
    }

    IEnumerator Dofade()
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 256)
        {
            canvasGroup.alpha += Time.deltaTime / 4;
            yield return null;
        }
        yield return null;
    }
}
