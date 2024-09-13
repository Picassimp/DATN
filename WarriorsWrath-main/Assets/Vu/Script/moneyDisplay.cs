using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
public class moneyDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GetCharacterGold(GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().userId));
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
                GetComponent<Text>().text = itemsData["gold"];
            }
        }
    }
}
