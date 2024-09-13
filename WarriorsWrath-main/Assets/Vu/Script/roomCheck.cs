using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomCheck : MonoBehaviour
{
    public bool done;
    public float finishTime;
    private Roomtemplate roomtemplate;
    [SerializeField] private int roomNumber;
    // Start is called before the first frame update
    void Start()
    {
        roomNumber = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplate>().roomcount;
        done = false;
        Invoke("Done", finishTime + 0.1f);

       
    }

    // Update is called once per frame
    void Done()
    {
        done = true;
    }

    public int getRoomNumber()
    {
        return roomNumber;
    }
}
