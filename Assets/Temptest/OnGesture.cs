using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edwon.VR.Gesture;
using Edwon.VR;
using UnityEngine.UI;

public class OnGesture : MonoBehaviour {

    public GameObject breaststroke_text;
    public GameObject freestyle_text;
    public GameObject player;
    public int thrust;
    // int counterbs = 0;
    // int counterfs = 0;
    // public Text counttext;
    private Rigidbody body;

    void OnEnable()
    {
        GestureRecognizer.GestureDetectedEvent += OnGestureDetected;
        GestureRecognizer.GestureRejectedEvent += OnGestureRejected;
    }

  
    void OnDisable()
    {
        GestureRecognizer.GestureDetectedEvent -= OnGestureDetected;
        GestureRecognizer.GestureRejectedEvent -= OnGestureRejected;
    }

    void Start()
    {
        body = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }


    void OnGestureDetected(string gestureName, double confidence, Handedness hand, bool isDouble = false)
    {
        switch (gestureName)
        {
            case "BSjon":
                {
                    StartCoroutine(ShowAndHide(breaststroke_text, 1f));
                    //    counterbs++;
                    //    counttext.text = counterbs.ToString();
                    break;
                }
                break;

            case "FSjon":
                {
                    StartCoroutine(ShowAndHide(freestyle_text, 1f));
                    //    counterbs++;
                    //    counttext.text = counterbs.ToString();
                    break;
                }
                break;

            case "Breaststroke":
                {
                    StartCoroutine(ShowAndHide(breaststroke_text,1f));
                    //    counterbs++;
                    //    counttext.text = counterbs.ToString();
                    body.AddForce(player.transform.forward * 200);
                    break;
                }
                break;
            case "Frontstroke":
                {
                    StartCoroutine(ShowAndHide(freestyle_text, 1f));
                    //   counterfs++;
                    //   counttext.text = counterfs.ToString();
                    body.AddForce(player.transform.forward * 200);
                    break;
                }
                break;
        }
    }

    void OnGestureRejected(string error, string gestureName, double confidence)
    {
    }

   /* IEnumerator AnimateShape(GameObject shape)
    {
        Renderer[] renderers = shape.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.color = Color.red;
        }

        yield return new WaitForSeconds(.6f);

        foreach (Renderer r in renderers)
        {
            r.material.color = Color.white;
        }
    }
    */
        IEnumerator ShowAndHide(GameObject go, float delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }

}
