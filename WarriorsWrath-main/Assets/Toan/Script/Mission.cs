using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class Mission : MonoBehaviour
{
    public int type;
    //1 2 3
    // Start is called before the first frame update
    public Text text;
    private GameObject data;
    public GameObject butt;
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
    }

    // Update is called once per frame
    void Update()
    {
        if(type == 1){
            text.text = "Nhiệm vụ 1:Đăng nhập vào game";
            if(data.GetComponent<dataHolder>().nv1 == 1 && data.GetComponent<dataHolder>().nv1RW != 1){
                butt.GetComponent<Button>().interactable = true;
            }
            else{
                butt.GetComponent<Button>().interactable = false;
            }
        }
        else if(type == 2){
            text.text = "Nhiệm vụ 2:Giết 10 quái (" + data.GetComponent<dataHolder>().nv2 + "/10)";
            if(data.GetComponent<dataHolder>().nv2 == 10 && data.GetComponent<dataHolder>().nv2RW != 1){
                butt.GetComponent<Button>().interactable = true;
            }
            else{
                butt.GetComponent<Button>().interactable = false;
            }
        }

        else if(type == 3){
            text.text = "Nhiệm vụ 3:Hoàn thành 1 game";
            if(data.GetComponent<dataHolder>().nv3 == 1 && data.GetComponent<dataHolder>().nv3RW != 1){
                butt.GetComponent<Button>().interactable = true;
            }
            else{
                butt.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void Reward(){
        StartCoroutine(GetCharacterGold(GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().userId, type));
    }

    IEnumerator GetCharacterGold(int id, int type)
    {
        string dailyUrl = "http://localhost/duanTN/dailyReward.php";
        WWWForm form = new WWWForm();
        form.AddField("idplayer", id);
        form.AddField("type", type);
        using (UnityWebRequest www = UnityWebRequest.Post(dailyUrl, form))
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
                if(itemsData["Status"] == 1){
                    if(type == 1){
                        data.GetComponent<dataHolder>().nv1RW = 1;
                    }
                    else if(type == 2){
                        data.GetComponent<dataHolder>().nv2RW = 1;
                    }
                    else if(type == 3){
                        data.GetComponent<dataHolder>().nv3RW = 1;
                    }
                    data.GetComponent<dataHolder>().exp = itemsData["exp"];
                    data.GetComponent<dataHolder>().Level = itemsData["lv"];
                    data.GetComponent<dataHolder>().skillSlot = itemsData["skill"];
                }
            }
        }
    }
}
