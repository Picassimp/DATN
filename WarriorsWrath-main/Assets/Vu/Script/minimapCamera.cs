using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapCamera : MonoBehaviour
{
    private GameObject minimapPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        minimapPos = GameObject.FindGameObjectWithTag("minimapPos");
        Vector3 pos = minimapPos.transform.position;
        pos.z = -10f;
        transform.position = pos;
    }
}
