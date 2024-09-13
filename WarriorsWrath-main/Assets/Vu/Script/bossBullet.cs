using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float z;
    private float rotZ;
    private bool isRight;
    private Vector2 init;

    private float bulletDmg;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerPos += new Vector2(0f, 1f);
        rb = GetComponent<Rigidbody2D>();
        z = transform.rotation.z;
        Destroy(gameObject, 2f);
        init = (playerPos - new Vector2(transform.position.x, transform.position.y)).normalized;
        Vector2 rotation = new Vector2(transform.position.x, transform.position.y) - playerPos;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    }

    // Update is called once per frame
    void Update()
    {
        if(z== 0)
        {

        }else if (z < 0)
        {
            z = -30;
        }
        else if(z> 0)
        {
            z = 30;
        }
        float rad = z * Mathf.Deg2Rad;

        Vector2 dir = new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad));
        
        if (!isRight)
        {
            rb.velocity = (init + (-dir) + new Vector2(1f, 0f)).normalized * 3f;
        }
        else
        {
            rb.velocity = (init + dir - new Vector2(1f, 0f)).normalized * 3f;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180 + z);
    }

    public void setIsRight(bool r)
    {
        isRight = r;
    }

    public void setDMG(float dmg){
        bulletDmg = dmg;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerStat>().playerTakeDmg(bulletDmg);
        }
    }
}
