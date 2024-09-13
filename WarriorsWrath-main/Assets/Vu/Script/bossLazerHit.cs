using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossLazerHit : MonoBehaviour
{
    private bool playerInArea;
    private bool doDMG = false;
    private int max = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInArea && doDMG && max <= 10){
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerStat>().playerTakeDmg(1);
            max++;
        }
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

    public void doDamage(){
        doDMG = true;
    }

}
