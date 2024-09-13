using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] private int direction;
    //1 top
    //2 right
    //3 bot
    //4 left
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject roomtemplate = GameObject.FindGameObjectWithTag("Rooms");
        GameObject minimapPos = GameObject.FindGameObjectWithTag("minimapPos");

        Transform mmH = minimapPos.transform.parent;
        if (collision.gameObject.tag == "Player")
        {
            if(direction== 1) {
                Vector3 newPos = collision.transform.position;
                newPos.y = newPos.y + 7f;
                collision.gameObject.transform.position = newPos;

                Vector3 newPoss = minimapPos.transform.localPosition;
                newPoss.y = newPoss.y + 1.5f;
                minimapPos.transform.localPosition = newPoss;
            }
            else if (direction == 2)
            {
                Vector3 newPos = collision.transform.position;
                newPos.x = newPos.x + 6f;
                collision.gameObject.transform.position = newPos;

                Vector3 newPoss = minimapPos.transform.localPosition;
                newPoss.x = newPoss.x + 1.5f;
                minimapPos.transform.localPosition = newPoss;
            }
            else if (direction == 3)
            {
                Vector3 newPos = collision.transform.position;
                newPos.y = newPos.y + -7f;
                collision.gameObject.transform.position = newPos;

                Vector3 newPoss = minimapPos.transform.localPosition;
                newPoss.y = newPoss.y - 1.5f;
                minimapPos.transform.localPosition = newPoss;
            }
            else if (direction == 4)
            {
                Vector3 newPos = collision.transform.position;
                newPos.x = newPos.x + -6f;
                collision.gameObject.transform.position = newPos;

                Vector3 newPoss = minimapPos.transform.localPosition;
                newPoss.x = newPoss.x - 1.5f;
                minimapPos.transform.localPosition = newPoss;
            }

            roomtemplate.GetComponent<Roomtemplate>().setDir(direction);
        }
    }
}
