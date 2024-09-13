using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    public GameObject prefabs;
    public int itemID; 
    public Text itemPrice;
    public Image itemSprite;
    public GameObject buyButton;

    public void buyWeapon(){
        int playerGold = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStat>().getGold();
        
        if (playerGold >= prefabs.GetComponent<weaponHolder>().getPrice()){
            var item = Instantiate(prefabs,GameObject.FindGameObjectWithTag("Player").transform.position,Quaternion.identity);
            item.GetComponent<weaponHolder>().buyItem();   
        }
    }



}
