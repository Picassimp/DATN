using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{   
    private float stat;
    private float bonusStat;
    private float duration;
    private float bonusDuration;
    private int currentLV;

    private skillData sD;

    private GameObject player;

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

        player.GetComponent<CharacterController>().moveSpeed += (stat + bonusStat * (currentLV - 1));

        Invoke("DisableSkill", (duration + bonusDuration * (currentLV - 1)));
    }

    private void DisableSkill()
    {
        gameObject.SetActive(false);
        player.GetComponent<CharacterController>().moveSpeed -= (stat + bonusStat * (currentLV - 1));
    }
}
