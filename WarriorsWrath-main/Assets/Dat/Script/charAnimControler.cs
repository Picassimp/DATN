using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charAnimControler : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }
    }
}
