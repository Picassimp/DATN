using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firingSwordBullet : MonoBehaviour
{
    public float dmg;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyStat>().enemyTakeDmg(dmg);
            Destroy(gameObject);

        }
    }
}
