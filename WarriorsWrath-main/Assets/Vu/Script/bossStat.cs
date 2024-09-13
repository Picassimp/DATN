using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStat : MonoBehaviour
{
    private float bossHealth;
    [SerializeField] private float bossCurHealth;
    private float bossDmg;
    // Start is called before the first frame update
    void Start()
    {   
        if(GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().difficulty == 1){
            bossHealth = 100;
            bossDmg = 3;
        } 
        else{
            bossHealth = 150;
            bossDmg = 5;
        }
        bossCurHealth = bossHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (bossCurHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (bossCurHealth <= bossHealth/2)
        {
            GetComponent<bossMoveSet>().Rage();
        }


    }

    public float GetMax()
    {
        return bossHealth;
    }

    public float GetDMG()
    {
        return bossDmg;
    }

    public float GetCur()
    {
        return bossCurHealth;
    }

    public void takeDMG(float dmg)
    {
        if(bossCurHealth > bossHealth / 2)
        {
            float remain = bossCurHealth - dmg;
            if(remain <= bossHealth / 2)
            {
                remain = bossHealth / 2;
            }

            bossCurHealth = remain;
        }
        else
        {
            float remain = bossCurHealth - dmg;
            if (remain <= 0)
            {
                remain = 0;
                bossCurHealth = remain;
                GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().status = 1;   
                if(GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().difficulty == 1){
                    GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().addScore(500);  
                }               
                else{
                    GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().addScore(1000);  
                }
        
                GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().kill += 5;
                GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().experience += 50;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerStat>().playerEndgame();
            }

            bossCurHealth = remain;
            

        }
    }

}
