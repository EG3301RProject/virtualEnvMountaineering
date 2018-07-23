using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseCondScript : MonoBehaviour {

    /*public Text gameOverText;
    public Button startButton;
    public Button retryButton;
    public GameObject panel;*/

    private bool LoseGame;
    private bool playMusic;
    public GameObject avalanche;
    public GameObject losetext;

    private int count;
    private int timer;
    private string defaultText;
    // Use this for initialization
    void Awake()
    {
        avalanche = GameObject.Find("Active Avalanche");
    }

    void Start() {
        LoseGame = false;
        //retryButton.gameObject.SetActive(false);
        playMusic = false;
        count = 10;
        timer = 0;
        defaultText = losetext.GetComponent<TextMesh>().text;
    }

    // Update is called once per frame
    void Update() {
        if (LoseGame == true && timer%18 == 0)
        {
            count--;
        }
        losetext.GetComponent<TextMesh>().text = defaultText + "\n" + "Restarting in " + count;
        timer++;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerCollider")
        {
            LoseGame = true;
            if (!playMusic)
            {
                avalanche.GetComponent<AudioSource>().Stop();
                this.GetComponent<AudioSource>().Play(0);
                losetext.SetActive(true);
                /*gameOverText.text = "GAME OVER";
                startButton.gameObject.SetActive(false);
                panel.GetComponent<Image>().color = UnityEngine.Color.black;
                FadeIn();
                */
                Invoke("RestartGame", 10);
                playMusic = true;
            }
        }
        
    }

    public bool getLoseCond()
    {
        return LoseGame;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Temp");
    }

    /*public void FadeIn()
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
    }*/
}
