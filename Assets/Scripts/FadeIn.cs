using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Retry()
    {
        SceneManager.LoadScene("Temp");
        Debug.Log("Im clicked");
    }

    public void FadeMe()
    {
        StartCoroutine(Dofade());
    }

    IEnumerator Dofade()
    {
        CanvasGroup canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup.interactable = true;
        yield return null;
    }
}
