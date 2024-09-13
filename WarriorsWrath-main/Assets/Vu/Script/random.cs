using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    private Roomtemplate roomtemplate;
    private int rand;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().time);
        roomtemplate = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplate>();
        int rand = Random.Range(0, 4);
        if(rand == 0)
        {
            Instantiate(roomtemplate.bDoorEnd[0], transform.position, Quaternion.identity);
        }
        if (rand == 1)
        {
            Instantiate(roomtemplate.lDoorEnd[0], transform.position, Quaternion.identity);
        }
        if (rand == 2)
        {
            Instantiate(roomtemplate.tDoorEnd[0], transform.position, Quaternion.identity);
        }
        if (rand == 3)
        {
            Instantiate(roomtemplate.rDoorEnd[0], transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
