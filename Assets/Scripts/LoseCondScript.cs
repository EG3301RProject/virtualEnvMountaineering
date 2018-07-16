using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseCondScript : MonoBehaviour {

    public Text gameOverText;
    public Button startButton;
    public Button retryButton;
    public GameObject panel;

    private GameObject canvas;
    private bool LoseGame;
    private bool playMusic;
    private GameObject avalanche;
    // Use this for initialization
    void Awake()
    {
        avalanche = GameObject.Find("Active Avalanche");
    }

    void Start () {
        LoseGame = false;
        canvas = GameObject.Find("Canvas");
        retryButton.gameObject.SetActive(false);
        playMusic = false;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Lose Zone");
        if (other.gameObject.name == "PlayerCollider")
        {
            LoseGame = true;
            if (!playMusic)
            {
                avalanche.GetComponent<AudioSource>().Stop();
                this.GetComponent<AudioSource>().Play(0);
                gameOverText.text = "GAME OVER";
                startButton.gameObject.SetActive(false);
                panel.GetComponent<Image>().color = UnityEngine.Color.black;
                FadeIn();
                playMusic = true;
                Invoke("setRetryButton", 4);
            }
            
            Debug.Log("Play lose condition");
        }
        
    }

    public bool getLoseCond()
    {
        return LoseGame;
    }

    public void FadeIn()
    {
        StartCoroutine(Dofade());
    }

    void setRetryButton()
    {
        retryButton.gameObject.SetActive(true);
        retryButton.interactable = true;
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
