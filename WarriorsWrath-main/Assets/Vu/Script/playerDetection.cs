using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetection : MonoBehaviour
{
    private bool firstEnter;
    [SerializeField] private List<GameObject> enemy;
    [SerializeField] private GameObject chest;    
    [SerializeField] private GameObject border;


    private int enemyNumber = 0;
    public GameObject chestPrefab; // Prefab của rương
    public float spawnChance = 0.2f; // Xác suất xuất hiện rương sau khi diệt quái (vd: 20%)
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> list = new List<GameObject>();
        firstEnter = false;
        chest.SetActive(false);
        border.SetActive(false);
        if(enemy.Count != 0)
        {
            enemyNumber = enemy.Count;
            foreach (GameObject go in enemy)
            {
                go.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyNumber == 0)
        {
            Debug.Log("Done room");
            GetComponent<playerDetection>().enabled = false;
            enemy.Clear();
            //disable chan nguoi choi

            //wall.SetActive(false);
            //enable ruong
            chest.SetActive(true);
        }


        
    }

    private void SpawnChestAtEnemyPosition()
    {
        // Tạo một bản sao của rương tại vị trí của quái đang bị diệt
        GameObject chest = Instantiate(chestPrefab, transform.position, Quaternion.identity);
        // Có thể thêm các xử lý khác ở đây, ví dụ như gán đối tượng chest cho một layer cụ thể

        // Hủy bản sao rương sau một khoảng thời gian nếu cần
        Destroy(chest, 10f); // 10 giây sau, bạn có thể điều chỉnh thời gian này theo mong muốn
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
            if (enemyNumber != 0)
            {
                border.SetActive(true);
                foreach (GameObject go in enemy)
                {
                    go.SetActive(true);
                }
            }
            //enable chan nguoi choi
            if(enemy.Count == 0)
            {
                //wall.SetActive(true);
            }

        }
    }
    public void enemyDie()
    {
        enemyNumber--;
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<playerStat>().regen(Random.Range(1,5));  
        if(enemyNumber == 0){
            //enable ruong
            border.SetActive(false);
            Destroy(border);
            if (Random.value < spawnChance)
            {
                SpawnChestAtEnemyPosition();
            }
        }
    }
}
