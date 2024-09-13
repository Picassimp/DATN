using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPos = transform.position;
        GameObject.FindGameObjectWithTag("Player").transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
