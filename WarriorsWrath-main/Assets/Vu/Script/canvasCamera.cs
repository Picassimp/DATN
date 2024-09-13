using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        GetComponent<Canvas>().worldCamera = cam.GetComponent<Camera>();
    }
}
