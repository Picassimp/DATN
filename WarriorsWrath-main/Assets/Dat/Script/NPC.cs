using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{   
    public GameObject shopWeapon;
    public GameObject player; 


    void Start (){
        shopWeapon.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update(){

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);


        if(Input.GetKey(KeyCode.B) && distanceToPlayer < 2f )
        {
            shopWeapon.SetActive(true);
            
        }
    }
}
