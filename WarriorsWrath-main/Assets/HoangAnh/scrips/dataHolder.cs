using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class dataHolder : MonoBehaviour
{
    //user data
    public int userId;
    public int diemUser;
    public string nameUser;
    public int Level;
    public int exp;
    public int skillSlot;

    public int selectCharID;
    public float selectHp;
    public float selectDmg;
    public float selectSpd;
    public int selectSprite;

    [SerializeField] private GameObject tradeH;

    //playing data
    public int difficulty;
    public float time = 0.0f;
    public bool isRunning;
    public int score;
    public int status;
    public int stage;

    //daily data
    public int nv1;
    public int nv1RW;
    public int nv2;
    public int nv2RW;
    public int nv3;
    public int nv3RW;

    public int kill;
    public int experience;

    public string addHis = "http://localhost/duanTN/addhistory.php";
    void Start(){
        DontDestroyOnLoad(gameObject);
        selectCharID = 1;
        isRunning = false;
    }

    private void Update()
    {
        if (isRunning)
        {
            time += Time.deltaTime;
        }
        StartCoroutine(GetCharacterGold(userId));

    }

    public void setUserID(int id){
        userId = id;
    }
    public void setDiem(int diem){
        diemUser = diem;
    }
    public void setName(string name){
        nameUser = name;
    }

    public void setLevel(int lv){
        Level = lv;
    }

    public void setExp(int lv){
        exp = lv;
    }

    public void setSkillSlot(int lv){
        skillSlot = lv;
    }

    public void setDaily(int _nv1, int rewardNV1,int _nv2, int rewardNV2,int _nv3, int rewardNV3){
        nv1 = _nv1;
        nv2 = _nv2;
        nv3 = _nv3;
        nv1RW = rewardNV1;
        nv2RW = rewardNV2;
        nv3RW = rewardNV3;

    }

    public void addTrade(int id, string date, int idtk, int idnv, int gia, int hpLV,int dmgLV, int spdLV, int lv, int exp, int selected){
        var trade = Instantiate(tradeH, gameObject.transform.position, Quaternion.identity);
        trade.GetComponent<tradeHistory>().id = id; 
        trade.GetComponent<tradeHistory>().date = date;
        trade.GetComponent<tradeHistory>().idtk = idtk;
        trade.GetComponent<tradeHistory>().idnv = idnv;
        trade.GetComponent<tradeHistory>().gia = gia;
        trade.GetComponent<tradeHistory>().hpLV = hpLV;
        trade.GetComponent<tradeHistory>().dmgLV = dmgLV;
        trade.GetComponent<tradeHistory>().spdLV = spdLV;
        trade.GetComponent<tradeHistory>().lv = lv;
        trade.GetComponent<tradeHistory>().exp = exp;
        trade.GetComponent<tradeHistory>().selected = selected;

        trade.transform.parent = gameObject.transform;
    }

    public void startTimer()
    {
        isRunning = true;
    }

    public void stopTimer()
    {
        isRunning = false;
    }

    public void resetTimer()
    {
        isRunning = false;
        time = 0.0f;
        score = 0;
    }

    public void addScore(int score1){
        score += score1;
    }

    public void endGame()
    {
        StartCoroutine(AddNewHis(userId, time, status, difficulty, stage, score, kill, experience));
        kill = 0;
        experience = 0;
    }


    IEnumerator AddNewHis(int idTK, float time, int status, int dif, int stage, int diem, int kill, int experience)
    {
        WWWForm form = new WWWForm();
        form.AddField("idplayer", idTK.ToString());
        form.AddField("time", time.ToString());
        form.AddField("status", status);
        form.AddField("difficuty", dif);
        form.AddField("stage", stage);
        form.AddField("diem", diem);
        form.AddField("kill", kill);
        form.AddField("exp", experience);
        using (UnityWebRequest www = UnityWebRequest.Post(addHis, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                JSONNode itemsData = JSON.Parse(www.downloadHandler.text);

                int randomNum2 = Random.Range(1, itemsData["Status"].Count);

                if (itemsData["Status"] == 1)
                {
                    diemUser = itemsData["diem"];
                    exp = itemsData["exp"];
                    Level = itemsData["lv"];
                    skillSlot = itemsData["skill"];
                    if(status == 1){
                        nv3 = 1;
                        
                    }
                    if(itemsData["soluong"] >= 10){
                            nv2 = 10;
                        }
                        else{
                            nv2 = itemsData["soluong"];
                    }
                }
            }
        }
    }
    IEnumerator GetCharacterGold(int id)
    {
        string getGoldUrl = "http://localhost/duanTN/getGold.php";
        WWWForm form = new WWWForm();
        form.AddField("idplayer", id);
        using (UnityWebRequest www = UnityWebRequest.Post(getGoldUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
  
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                JSONNode itemsData = JSON.Parse(www.downloadHandler.text);
                diemUser = itemsData["gold"];
            }
        }
    }
}


