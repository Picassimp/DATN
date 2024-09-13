using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossLazerDir : MonoBehaviour
{
    private Vector3 playerPos;
    private float z;
    private bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            z += 0.01f;
            transform.rotation = Quaternion.Euler(0f, 0f, z);
        }
    }

    public void changeCheck()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        check = false;
    }

    public void startLazer()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 direction = playerPos - transform.position;
        Vector3 rotation = transform.position - playerPos;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);
        z = rotZ + 180;
        check = true;
    }
}
