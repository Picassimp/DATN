using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firingSword : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;

    private float stat;
    private float bonusStat;
    private float duration;
    private float bonusDuration;
    private int currentLV;

    private skillData sD;

    private float z = 0;
    private GameObject player;

    void Start()
    {
        
        
    }

    void OnEnable()
    {
        sD = transform.parent.transform.GetComponent<skillData>();
        stat = sD.getStat();
        bonusStat = sD.getBonusStat();
        currentLV = sD.getCurrentLV();
        player = GameObject.FindGameObjectWithTag("Player");
        FireBullets();
        gameObject.SetActive(false);
    }

    void FireBullets()
    {
        for (int i = 0; i < 8; i++)
        {
            float angle = i * 45f; // Spread bullets in 45-degree increments

            // Calculate the direction based on the angle
            Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

            // Instantiate the bullet, set its position and rotation

            GameObject bullet = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction) * Quaternion.Euler(0f, 0f, 45f);
            bullet.GetComponent<firingSwordBullet>().dmg = (stat + bonusStat * (currentLV - 1));
            // Get the bullet's Rigidbody2D component and set its velocity
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = direction * bulletSpeed;
        }
    }
    
}
