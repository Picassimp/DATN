using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetectionBoBattle : MonoBehaviour
{
    private bool firstEnter;
    // Start is called before the first frame update
    void Start()
    {
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

            GameObject roomtemplate = GameObject.FindGameObjectWithTag("Rooms");
            GameObject minimapPos = GameObject.FindGameObjectWithTag("minimapPos");
            Transform mmH = minimapPos.transform.parent;

            if (firstEnter == false)
            {
                if (roomtemplate.GetComponent<Roomtemplate>().getDir() == 1)
                {
                    var mm = Instantiate(roomtemplate.GetComponent<Roomtemplate>().top, minimapPos.transform.position, Quaternion.identity);
                    mm.transform.parent = mmH;
                }
                else if (roomtemplate.GetComponent<Roomtemplate>().getDir() == 2)
                {
                    var mm = Instantiate(roomtemplate.GetComponent<Roomtemplate>().right, minimapPos.transform.position, Quaternion.identity);
                    mm.transform.parent = mmH;
                }
                else if (roomtemplate.GetComponent<Roomtemplate>().getDir() == 3)
                {
                    var mm = Instantiate(roomtemplate.GetComponent<Roomtemplate>().bot, minimapPos.transform.position, Quaternion.identity);
                    mm.transform.parent = mmH;
                }
                else if (roomtemplate.GetComponent<Roomtemplate>().getDir() == 4)
                {
                    var mm = Instantiate(roomtemplate.GetComponent<Roomtemplate>().left, minimapPos.transform.position, Quaternion.identity);
                    mm.transform.parent = mmH;
                }
            }

            firstEnter = true;


        }
    }
}
