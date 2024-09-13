using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRoomCamera : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private bool enter;    
    [SerializeField] private GameObject border;

    // Start is called before the first frame update
    void Start()
    {
        enter = false;
        border.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (enter == false)
        {
            transform.position = player.transform.position + new Vector3(0, 0, -10);

        }
        else
        {
            border.SetActive(true);
            transform.position = new Vector3(0, 0, -10);
        }
    }

    public void OnEnter()
    {
        enter = true;
    }

    public void OnExit()
    {
        enter = false;
    }
}
