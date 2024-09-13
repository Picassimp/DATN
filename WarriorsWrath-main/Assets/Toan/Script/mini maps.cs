using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimaps : MonoBehaviour
{
    Rigidbody2D myrigidbody2D;
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        myrigidbody2D.velocity = new Vector2(x * 5, y * 5);
    }
}
