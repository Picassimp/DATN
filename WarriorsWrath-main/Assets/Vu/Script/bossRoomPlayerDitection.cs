using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRoomPlayerDitection : MonoBehaviour
{
    private bool firstEnter;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject bossHealBar;
    private int enemyNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> list = new List<GameObject>();
        firstEnter = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<bossRoomCamera>().OnEnter();
            boss.SetActive(true);
            bossHealBar.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<bossRoomCamera>().OnExit();

        }
    }
}
