using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow : MonoBehaviour
{
    private float growthRate = 0.05f;
    private float maxScale = 7.0f;

    private float stat;
    private float bonusStat;
    private float duration;
    private float bonusDuration;
    private int currentLV;

    private skillData sD;

    private GameObject player;

    private bool inArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        inArea = true;
        transform.localScale = new Vector3(1f,1f,1f);
        Invoke("DisableSkill", (duration + bonusDuration * (currentLV - 1)));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newScale = transform.localScale + Vector3.one * growthRate;
        if (newScale.x <= maxScale && newScale.y <= maxScale && newScale.z <= maxScale)
        {
            // Apply the new scale if within the limit
            transform.localScale = newScale;
        }
        else
        {
            // Optionally, you can add additional behavior when the limit is reached
            // For example, you might stop the scaling or reset the scale to a specific value
        }
    }

    private void DisableSkill()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<FollowPlayer>().moveSpeed = 1f;
        }
        else if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<bossFollow>().setSPD(2f);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<FollowPlayer>().moveSpeed = 3f;

        }
        else if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<bossFollow>().setSPD(5f);

        }
    }
}
