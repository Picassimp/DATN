using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Roomspawner : MonoBehaviour
{
    public int openingDirection;
    public float openingSpeed;
    //1 = bottom door
    //2 = left door
    //3 = top door
    //4 = right door

    private Roomtemplate roomtemplate;
    private int rand;
    private Vector3 replacePos;
    private GameObject parent;
    private bool spawned = false;
    [SerializeField] private GameObject[] closeDoor;
    [SerializeField] private GameObject bDoor;
    [SerializeField] private GameObject lDoor;
    [SerializeField] private GameObject tDoor;
    [SerializeField] private GameObject rDoor;

    private int difficulty;
    void Start()
    {
        difficulty = GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().difficulty;
        roomtemplate= GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplate>();
        Invoke("Spawn", 1f * openingSpeed);
        
    }
    void Spawn()
    {
        Debug.Log("aaaaa");
        if (spawned == false && openingDirection != 0)
        {
            if (openingDirection == 1)
            {
                //spawn bottom dooor
                if (GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplate>().roomcount < difficulty*4)
                {
                    rand = Random.Range(0, roomtemplate.bDoor.Length);
                    var spawnedRoom = Instantiate(roomtemplate.bDoor[rand], transform.position, Quaternion.identity);
                    
                }
                else
                {
                    var spawnedRoom = Instantiate(roomtemplate.bDoorEnd[0], transform.position, Quaternion.identity);
                    
                }

            }
            else if (openingDirection == 2)
            {
                //spawn left dooor
                if (GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplate>().roomcount < difficulty*4)
                {
                    rand = Random.Range(0, roomtemplate.lDoor.Length);
                    var spawnedRoom = Instantiate(roomtemplate.lDoor[rand], transform.position, Quaternion.identity);
                    
                }
                else
                {
                    var spawnedRoom = Instantiate(roomtemplate.lDoorEnd[0], transform.position, Quaternion.identity);
                    
                }
            }
            else if (openingDirection == 3)
            {
                //spawn top dooor
                if (GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplate>().roomcount < difficulty*4)
                {
                    rand = Random.Range(0, roomtemplate.tDoor.Length);
                    var spawnedRoom = Instantiate(roomtemplate.tDoor[rand], transform.position, Quaternion.identity);
                    
                }
                else
                {
                    var spawnedRoom = Instantiate(roomtemplate.tDoorEnd[0], transform.position, Quaternion.identity);
                    
                }
            }
            else if (openingDirection == 4)
            {
                //spawn right dooor
                if (GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplate>().roomcount < difficulty*4)
                {
                    rand = Random.Range(0, roomtemplate.rDoor.Length);
                    var spawnedRoom = Instantiate(roomtemplate.rDoor[rand], transform.position, Quaternion.identity);
                    
                }
                else
                {
                    var spawnedRoom = Instantiate(roomtemplate.rDoorEnd[0], transform.position, Quaternion.identity);
                    
                }
            }
            spawned = true;
            GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplate>().Add();
            Destroy(gameObject);
        }

        

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            if (collision.GetComponent<roomCheck>().done == true)
            {
                if (openingDirection == 1)
                {
                    replacePos = tDoor.transform.position;
                    parent = tDoor.transform.parent.gameObject;
                    Destroy(tDoor);
                }
                else if (openingDirection == 2)
                {
                    replacePos = rDoor.transform.position;
                    parent = rDoor.transform.parent.gameObject;
                    Destroy(rDoor);
                }
                else if (openingDirection == 3)
                {
                    replacePos = bDoor.transform.position;
                    parent = bDoor.transform.parent.gameObject;
                    Destroy(bDoor);
                }
                else if (openingDirection == 4)
                {
                    replacePos = lDoor.transform.position;
                    parent = lDoor.transform.parent.gameObject;
                    Destroy(lDoor);
                }
                GameObject obj = Instantiate(closeDoor[openingDirection - 1], replacePos, Quaternion.identity);
                obj.transform.parent = parent.transform;
            }
            Destroy(gameObject);
        }
        if (collision.CompareTag("Spawnpoint"))
        {
            //if(collision.GetComponent<Roomspawner>().spawned == false && spawned == false)
            //{
            //spawn a block
            //Instantiate(roomtemplate.block, transform.position, Quaternion.identity);
            //}

            if (openingDirection == 1)
            {
                replacePos = tDoor.transform.position;
                parent = tDoor.transform.parent.gameObject;
                Destroy(tDoor);
            }
            else if (openingDirection == 2)
            {
                replacePos = rDoor.transform.position;
                parent = rDoor.transform.parent.gameObject;
                Destroy(rDoor);
            }
            else if (openingDirection == 3)
            {
                replacePos = bDoor.transform.position;
                parent = bDoor.transform.parent.gameObject;
                Destroy(bDoor);
            }
            else if (openingDirection == 4)
            {
                replacePos = lDoor.transform.position;
                parent = lDoor.transform.parent.gameObject;
                Destroy(lDoor);
            }
            GameObject obj = Instantiate(closeDoor[openingDirection - 1], replacePos, Quaternion.identity);
            obj.transform.parent = parent.transform;
            Instantiate(roomtemplate.block, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
