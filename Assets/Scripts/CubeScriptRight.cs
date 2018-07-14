using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScriptRight : MonoBehaviour
{

    public GameObject VRManager;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Controller (right)")
        {
            int cubeNum;
            string cubeName = gameObject.name.Split('(', ')')[1];
            cubeNum = int.Parse(cubeName);
            VRManager.GetComponent<VRManagerScript>().setCube(cubeNum);
            Debug.Log("Cube" + cubeName + "touched");
        }
        Debug.Log("Inside method");
    }
}
