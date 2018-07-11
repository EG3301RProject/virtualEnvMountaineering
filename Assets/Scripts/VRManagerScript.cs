using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRManagerScript : MonoBehaviour
{
    public static bool[] CubeIsHit = new bool[18];
    public static bool BSdetected, HBSdetected;
    public GameObject breaststroke_text,highbreaststroke_text;
    private int counter = 1000, counter2 = 1000;
    // Use this for initialization
    void Start()
    {
        BSdetected = false;
        HBSdetected = false;
        setCubeFalse();
        counter = 0;
        counter2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeIsHit[9] || CubeIsHit[6]) //High Breaststroke
        {
            if (CubeIsHit[9] && CubeIsHit[6] && (counter2 < 100))
            {
                if ((counter2 < 100) && (CubeIsHit[7] || CubeIsHit[10] || CubeIsHit[4] || CubeIsHit[1]))
                {
                    if ((counter2 < 100) && (CubeIsHit[5] || CubeIsHit[16] || CubeIsHit[2] || CubeIsHit[13]))
                    {
                        HBSdetected = true;
                        Debug.Log("High Breastroke detected");
                        setCubeFalse();
                        counter2 = 0;
                    }
                    else if ((counter2 >= 100))
                    {
                        setCubeFalse();
                        counter2 = 0;
                    }
                }
                else if (counter2 >= 100)
                {
                    setCubeFalse();
                    counter2 = 0;
                }
            }
            else
            {
                setCubeFalse();
                counter2 = 0;
            }
            counter2++;
        }




        if (CubeIsHit[0] || CubeIsHit[3]) //Normal Breaststroke
        {
            if (CubeIsHit[0] && CubeIsHit[3] && (counter < 100))
            {
                if ((counter < 100) && ( CubeIsHit[1] || CubeIsHit[4] || CubeIsHit[16] || CubeIsHit[13]) )
                {
                    if ((counter < 100) && (CubeIsHit[2] || CubeIsHit[5] || CubeIsHit[17] ||CubeIsHit[14]) )
                    {
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
            Debug.Log("Breastroke appeared");
            BSdetected = false;
        }
        else if (HBSdetected)
        {
            StartCoroutine(ShowAndHide(highbreaststroke_text, 1f));
            Debug.Log("High Breastroke appeared");
            HBSdetected = false;
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