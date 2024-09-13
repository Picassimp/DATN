using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    public static WeaponShop weaponShop;
    public List<Weapon> weaponList = new List<Weapon>();
    public GameObject itemHolderPrefabs;
    public Transform grid;

    public GameObject exitbtn;
    void Start()
    {
        weaponShop = this;
        FillList();
    }

    void FillList()
    {
        for(int i = 0 ; i < weaponList.Count;i++){
            var holder = Instantiate(itemHolderPrefabs,grid);
            holder.GetComponent<ItemHolder>().itemPrice.text = weaponList[i].weaponPrice+"";

            holder.GetComponent<ItemHolder>().itemID = weaponList[i].weaponID;
            holder.GetComponent<ItemHolder>().itemPrice.text = weaponList[i].prefabs.GetComponent<weaponHolder>().getPrice() + "";
            holder.GetComponent<ItemHolder>().itemSprite.sprite = weaponList[i].weaponSprite;
            holder.GetComponent<ItemHolder>().prefabs = weaponList[i].prefabs;
           
        }
    }

    public void exitPanel(){
        gameObject.SetActive(false);
    }

     

}
