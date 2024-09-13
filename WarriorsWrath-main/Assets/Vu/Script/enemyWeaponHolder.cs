using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeaponHolder : MonoBehaviour
{
    private Vector3 playerPos;
    private bool isAttacking;

    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = transform.parent.gameObject.GetComponent<FollowPlayer>().getIsAttacking();
        if (isAttacking)
        {
            return;
        }
        playerPos = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
        Vector3 rotation = playerPos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //lat vu khi khi doi goc
        if (rotZ > 90 || rotZ < -90)
        {
            gameObject.transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(1f, -1f, 1f);
            isRight = false;
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
            isRight = true;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public bool GetIsRight()
    {
        return isRight;
    }
}
