using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStat : MonoBehaviour
{
    
    public float playerDmg;
    [SerializeField] private int playerGold;
    private float playerMaxHealth;
    [SerializeField] private float playerCurrentHealth;

    private Material material;
    private float currentMATIntensity;
    private bool canTakeDmg;
    [SerializeField] private GameObject endGamePanel;
    // Start is called before the first frame update
    /*void Start()
    {
        canTakeDmg = true;
        var data = GameObject.FindGameObjectWithTag("Data");
        playerMaxHealth = data.GetComponent<dataHolder>().selectHp;        
        playerDmg = data.GetComponent<dataHolder>().selectDmg;
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().material){
        material = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().material;
        material.SetFloat("_Intensity", Mathf.Round(currentMATIntensity * 10.0f) * 0.1f);
        }
    }*/

    public int getGold()
    {
        return playerGold;
    }
    public void spending(int spent)
    {
        if(playerGold>= spent)
        {
            playerGold -= spent;
        }
    }

    public void playerTakeDmg(float dmg)
    {
        if(!canTakeDmg)
        {
            return;
        }

        material.SetFloat("_Intensity", 0.5f);
        StartCoroutine(ChangeEngineColour());
        Invoke("updateCanTakeDmg", 0.5f);

        playerCurrentHealth -= dmg;

        if(playerCurrentHealth <= 0)
        {
            playerCurrentHealth =0;
            //death
            playerEndgame();
             
        }
    }

    public void regen(float regen){
        playerCurrentHealth += regen;
        if(playerCurrentHealth >= playerMaxHealth){
        playerCurrentHealth = playerMaxHealth;
        }
    }

    public void playerEndgame(){
        Destroy(GameObject.FindGameObjectWithTag("GameUI"));
        GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().endGame();
        endGamePanel.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Player")); 
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

    public float maxH()
    {
        return playerMaxHealth;
    }

    public float curH()
    {
        return playerCurrentHealth;
    }
}
