using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour{
     
    private Rigidbody2D rb;
    public float moveSpeed;

    void Start()
    {
        var data = GameObject.FindGameObjectWithTag("Data");
        moveSpeed = data.GetComponent<dataHolder>().selectSpd / 10f;        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Tạo vector di chuyển
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Gán tốc độ cho Rigidbody
        rb.velocity = movement * moveSpeed;

        
        // // Điều chỉnh hướng nhân vật
        // if (movement != Vector2.zero)
        // {
        //     transform.up = movement;
        // }
    }
}

   

