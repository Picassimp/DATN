using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingArea : MonoBehaviour
{
    private float stat;
    private float bonusStat;
    private float duration;
    private float bonusDuration;
    private int currentLV;

    private skillData sD;

    private GameObject player;

    private bool inArea;
    private float time;
    // Start is called before the first frame update
    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
        sD = transform.parent.transform.GetComponent<skillData>();
        stat = sD.getStat();
        bonusStat = sD.getBonusStat();
        duration = sD.getDuration();
        bonusDuration = sD.getBonusDuration();
        currentLV = sD.getCurrentLV();
        time = 1f;
        inArea = true;
        Invoke("DisableSkill", (duration + bonusDuration * (currentLV - 1)));
    }

    // Update is called once per frame
    void Update()
    {  
        time += Time.deltaTime;
        if (time >= 1f)
        {
            time = time % 1f;
            if(inArea) { Heal();}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inArea = false;
        }
    }

    private void Heal()
    {
        Debug.Log(stat + bonusStat * (currentLV - 1));
        player.GetComponent<playerStat>().regen(stat + bonusStat * (currentLV - 1));
    }

    private void DisableSkill()
    {
        gameObject.SetActive(false);
    }
}
