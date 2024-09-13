using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    private Animator anim;
    private CircleCollider2D coll;

    [SerializeField] private float bulletDmg;

    private Camera camera;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        coll = GetComponent<CircleCollider2D>();

        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("Hit");
            collision.gameObject.GetComponent<enemyStat>().enemyTakeDmg(bulletDmg);
        }
        else if(collision.gameObject.tag == "Obstacle"){
            anim.SetTrigger("Hit");
        }
        else if (collision.gameObject.tag == "Boss")
        {
            anim.SetTrigger("Hit");
            collision.gameObject.GetComponent<bossStat>().takeDMG(bulletDmg);
        }
    }

    public void DeleteBullet()
    {
        Destroy(gameObject);
    }
}
