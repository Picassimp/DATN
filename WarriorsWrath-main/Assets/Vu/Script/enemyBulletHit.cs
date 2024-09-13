using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletHit : MonoBehaviour
{
    private Animator anim;
    private CircleCollider2D coll;

    [SerializeField] private float bulletDmg;

    private Vector3 playerPos;
    private Rigidbody2D rb;
    public float force;
    [SerializeField] private float bulletR;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();

        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = playerPos - transform.position;
        Vector3 rotation = transform.position - playerPos;

        //Debug.Log(direction);

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        //Vector3 oldDir = rb.velocity;
        //Debug.Log(oldDir);
        //rb.velocity = Quaternion.Euler(0, 90, 0) * oldDir * force;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBulletDmg(float dmg)
    {
        bulletDmg = dmg;
    }

    public void setBulletForce(float dmg)
    {
        force = dmg;
    }

    public void setbulletR(float r)
    {
        bulletR = r;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Hit");
            collision.gameObject.GetComponent<playerStat>().playerTakeDmg(bulletDmg);
        }
        else if(collision.gameObject.tag == "Obstacle"){
            anim.SetTrigger("Hit");
        }
    }

    public void DeleteBullet()
    {
        Destroy(gameObject);
    }
}
