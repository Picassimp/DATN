using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyStat : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth;
    [SerializeField] private float enemyCurrentHealth;
    [SerializeField] private Image fillBar;

    private Material material;
    private float currentMATIntensity;
    private bool canTakeDmg;
    // Start is called before the first frame update
    void Start()
    {
        canTakeDmg = true;
        material = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().material;
        if(GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().difficulty == 1){
            enemyMaxHealth = 75;
        } 
        else{
            enemyMaxHealth = 50;
        }
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_Intensity", Mathf.Round(currentMATIntensity * 10.0f) * 0.1f);
        fillBar.fillAmount = enemyCurrentHealth / enemyMaxHealth;
    }

    public void enemyTakeDmg(float dmg)
    {
        if (!canTakeDmg)
        {
            return;
        }

        material.SetFloat("_Intensity", 0.5f);
        StartCoroutine(ChangeEngineColour());
        Invoke("updateCanTakeDmg", 0.5f);

        enemyCurrentHealth -= dmg;

        if (enemyCurrentHealth <= 0)
        {
            //death
            GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<playerStat>().spending(-500);                

            if(GameObject.FindGameObjectWithTag("Data").gameObject.GetComponent<dataHolder>().difficulty == 1){
                GameObject.FindGameObjectWithTag("Data").gameObject.GetComponent<dataHolder>().addScore(100);
            }         
            else if(GameObject.FindGameObjectWithTag("Data").gameObject.GetComponent<dataHolder>().difficulty == 2){
                GameObject.FindGameObjectWithTag("Data").gameObject.GetComponent<dataHolder>().addScore(150);
            }  
            

            this.transform.gameObject.transform.parent.GetComponent<playerDetection>().enemyDie();
            GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().kill++;
            GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().experience += 10;
            Destroy(gameObject);
        }
    }

    private IEnumerator ChangeEngineColour()
    {
        float time = 0f;
        while (time < 0.5f)
        {
            time += Time.deltaTime;
            currentMATIntensity = Mathf.Lerp(0.5f, 0f, (time / 0.5f));
            yield return null;
        }
    }
    private void updateCanTakeDmg()
    {
        canTakeDmg = true;
    }
}
