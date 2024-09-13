using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMeleeHit : MonoBehaviour
{
    private bool playerInArea;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            playerInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            playerInArea = false;
        }
    }

    public void dealDMG(){
        if(playerInArea){
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerStat>().playerTakeDmg(transform.parent.GetComponent<bossStat>().GetDMG());
        }
    }
}
