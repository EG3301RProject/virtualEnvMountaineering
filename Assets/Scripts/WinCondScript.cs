using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCondScript : MonoBehaviour {

    /*public Text gameOverText;
    public Button startButton;
    public Button retryButton;
    public GameObject panel;*/

    private bool WinGame;
    private GameObject avalanche;
    private bool playMusic;
    private GameObject canvas;
    public GameObject wintext;

    private int count;
    private int timer;
    private string defaultText;
    // Use this for initialization
    private void Awake()
    {
        avalanche = GameObject.Find("Active Avalanche");
    }

    void Start () {
        WinGame = false;
        
        playMusic = false;
        //canvas = GameObject.Find("Canvas");
        count = 10;
        timer = 0;
        defaultText = wintext.GetComponent<TextMesh>().text;
    }
	
	// Update is called once per frame
	void Update () {
        if (WinGame == true && timer % 18 == 0)
        {
            count--;
        }
        wintext.GetComponent<TextMesh>().text = defaultText + "\n" + "Restarting in " + count;
        timer++;
    }

    void OnTriggerEnter(Collider other)
    {
        if(avalanche.GetComponent<AvalancheController>().getEndAvalanche() && other.gameObject.name == "PlayerCollider")
        {
            WinGame = true;
            if (!playMusic)
            {
                this.GetComponent<AudioSource>().Play(0);
                wintext.SetActive(true);
                /*gameOverText.text = "You Survived";
                startButton.gameObject.SetActive(false);
                FadeIn();*/
                Invoke("RestartGame", 10);
                playMusic = true;
            }
        }
    }

    public bool getWinCond()
    {
        return WinGame;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Temp");
    }

    /*void setRetryButton()
    {
        retryButton.gameObject.SetActive(true);
        retryButton.interactable = true;
    }


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
    }*/
}
