using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinningSword : MonoBehaviour
{
    private float stat;
    private float bonusStat;
    private float duration;
    private float bonusDuration;
    private int currentLV;

    private skillData sD;

    private float z = 0;
    private GameObject player;
    // Start is called before the first frame update
    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sD = transform.parent.transform.GetComponent<skillData>();
        stat = sD.getStat();
        bonusStat = sD.getBonusStat();
        duration = sD.getDuration();
        bonusDuration= sD.getBonusDuration();
        currentLV = sD.getCurrentLV();
        Invoke("DisableSkill", (duration + bonusDuration * (currentLV - 1)));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        float x = player.transform.position.x;
        float y = player.transform.position.y+0.5f;
        float z1 = player.transform.position.z;
        transform.position = new Vector3(x,y,z1);
        z += 0.3f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log(stat + bonusStat * (currentLV - 1));
            collision.gameObject.GetComponent<enemyStat>().enemyTakeDmg(stat + bonusStat * (currentLV - 1));
        }
    }

    private void DisableSkill()
    {
        gameObject.SetActive(false);
    }

}
