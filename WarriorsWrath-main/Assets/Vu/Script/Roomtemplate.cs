using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Roomtemplate : MonoBehaviour
{
    public GameObject[] bDoor;
    public GameObject[] lDoor;
    public GameObject[] tDoor;
    public GameObject[] rDoor;
    public GameObject[] bDoorEnd;
    public GameObject[] lDoorEnd;
    public GameObject[] tDoorEnd;
    public GameObject[] rDoorEnd;

    //minimap
    [SerializeField] public GameObject top;
    [SerializeField] public GameObject right;
    [SerializeField] public GameObject bot;
    [SerializeField] public GameObject left;
    private int direction;

    public GameObject[] content;
    public GameObject firstRoom;    
    public GameObject lastRoom;


    public GameObject block;
    public int roomcount = 0;
    public List<GameObject> roomList = new List<GameObject>();

    private float time = 2.1f;

    [SerializeField] private GameObject loadingScene;
    [SerializeField] private Image LoadingBarFill;
    [SerializeField] private GameObject player;

    void Start(){
        player.GetComponent<CharacterController>().enabled = false;
    }
    public void Add()
    {
        roomcount++;
        time = 2.1f;
    }

    private void Update()
    {
        float rc = (float) roomcount;        
        float dif = (float) GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().difficulty*4;
        float progressValue = rc/ dif;
        
        LoadingBarFill.fillAmount = progressValue;
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            GameObject[] room = GameObject.FindGameObjectsWithTag("Wall");
            foreach (GameObject r in room)
            {
                roomList.Add(r);
            }
            if (roomList.Count > 0)
            {
                roomList.Sort(delegate (GameObject a, GameObject b) {
                    return (a.GetComponent<roomCheck>().getRoomNumber().CompareTo(b.GetComponent<roomCheck>().getRoomNumber()));
                });
            }

            Debug.Log(roomList.Count);

            foreach (GameObject r in roomList)
            {
                if (roomList.IndexOf(r) == 0)
                {
                    //spawn
                    Instantiate(firstRoom, r.transform.position, Quaternion.identity);
                }
                else if (roomList.IndexOf(r) == ((roomList.Count) - 1))
                {
                    //spawn boss
                    Instantiate(lastRoom, r.transform.position, Quaternion.identity);

                }
                else
                {
                    Roomtemplate roomtemplate = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplate>();
                    int rand = Random.Range(0, roomtemplate.content.Length);
                    var newRoom = Instantiate(roomtemplate.content[rand], r.transform.position, Quaternion.identity);
                    newRoom.transform.parent = r.gameObject.transform;
                }
            }
            
            GameObject.FindGameObjectWithTag("NavMesh").GetComponent<NavMeshSurface2d>().BuildNavMesh();
            player.GetComponent<CharacterController>().enabled = true;
            loadingScene.SetActive(false);
            GameObject.FindGameObjectWithTag("SkillData").GetComponent<skillHolder>().Play();
            GetComponent<Roomtemplate>().enabled = false;
        }
    }

    public void setDir(int dir)
    {
        direction = dir;
    }

    public int getDir()
    {
        return direction;
    }
 }
