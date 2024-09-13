using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHolder : MonoBehaviour
{
    private Camera camera;
    private Vector3 mousePos;

    private bool isAttacking;

    public bool isRight;

    [SerializeField] private int price;
    [SerializeField] private bool isOwn;
    [SerializeField] private bool isEquipped;
    public bool canEquipped;
    [SerializeField] private GameObject priceTag;

    private CircleCollider2D coll;

    private void Start()
    {
        isRight = true;
        
        coll = GetComponent<CircleCollider2D>();

        if(isOwn)
        {
            GetComponent<priceDisplay>().enabled= false;
            Destroy(priceTag); priceTag = null;
        }
        else
        {
            isEquipped= false;
        }
    }

    private void Update()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //nhat vu khi
        if (Input.GetKeyDown(KeyCode.E) && canEquipped && !isEquipped)
        {
            if (isOwn == false)
            {
                buyItem();
            }
            if(isOwn == false)
            {
                return;
            }
            isEquipped = true;
            coll.enabled = false;
        }

        else if (Input.GetKeyDown(KeyCode.E) && isEquipped == true)
        {
            isEquipped = false;
            gameObject.transform.parent = null;
            coll.enabled = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (!isEquipped) { return; }
        else
        {
            gameObject.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            gameObject.transform.localPosition = new Vector3(0f, 0.35f, 0f);
        }
        //vu khi di chuyen theo chuot
        isAttacking = this.gameObject.transform.GetChild(0).GetComponent<weaponStat>().GetIsAttacking();
        
            mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        if (isAttacking == false)
        {
            //lat vu khi khi doi goc
            if (rotZ > 90 || rotZ < -90) {
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

        

    }

    public bool getIsAttacking()
    {
        return isAttacking;
    }

    public bool getIsEquipped()
    {
        return isEquipped;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canEquipped = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canEquipped = false;
        }
    }

    public void buyItem()
    {
        int playerGold = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStat>().getGold();
        if(playerGold >= price)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerStat>().spending(price);
            isOwn = true;
            Destroy(priceTag); priceTag = null;
        }
    }

    public int getPrice()
    {
        return price;
    }

    public void weaponAsReward()
    {
        isOwn = true;
        canEquipped = true;
    }
}
