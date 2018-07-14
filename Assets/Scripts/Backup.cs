using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backup : MonoBehaviour
{
    public static bool[] CubeIsHit = new bool[18];
    public static bool BSdetected, HBSdetected;
    public GameObject breaststroke_text, highbreaststroke_text;
    private int counter = 1000;
    // Use this for initialization
    void Start()
    {
        BSdetected = false;
        HBSdetected = false;
        setCubeFalse();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeIsHit[0] || CubeIsHit[3]) //Normal Breaststroke
        {
            if (CubeIsHit[0] && CubeIsHit[3] && (counter < 100))
            {
                if (CubeIsHit[1] && CubeIsHit[4] && (counter < 100))
                {
                    if (CubeIsHit[2] && CubeIsHit[5] && (counter < 100))
                    {
                        //StartCoroutine(ShowAndHide(breaststroke_text, 1f));
                        BSdetected = true;
                        Debug.Log("Breastroke detected");
                        setCubeFalse();
                        counter = 0;
                    }
                    else if ((counter >= 100))
                    {
                        setCubeFalse();
                        counter = 0;
                    }
                }
                else if (counter >= 100)
                {
                    setCubeFalse();
                    counter = 0;
                }
            }
            else
            {
                setCubeFalse();
                counter = 0;
            }
            counter++;
        }


        if (BSdetected)
        {
            StartCoroutine(ShowAndHide(breaststroke_text, 1f));
        }

        if (HBSdetected)
        {
            StartCoroutine(ShowAndHide(highbreaststroke_text, 1f));
        }



    }

    public void setCube(int cubeName)
    {
        if (cubeName >= 0)
        {
            CubeIsHit[cubeName] = true;
        }
    }
    public void setCubeFalse()
    {
        for (int i = 0; i < 18; i++)
        {
            CubeIsHit[i] = false;
        }
    }

    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }

}