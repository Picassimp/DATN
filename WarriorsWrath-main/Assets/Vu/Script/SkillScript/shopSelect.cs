using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

public class shopSelect : MonoBehaviour
{
    public int skillSlot;
    public int idSkill1, idSkill2, idSkill3;    
    public GameObject display1, display2, display3;

    public int index = 0;
    // Start is called before the first frame update
    void OnEnable()
    {   GameObject data = GameObject.FindGameObjectWithTag("Data");
        skillSlot = data.GetComponent<dataHolder>().skillSlot;
        GameObject skillHolder = GameObject.FindGameObjectWithTag("SkillData");
        foreach(Transform tr in skillHolder.transform){              
            if(tr.gameObject.GetComponent<skillData>().getSelectedSkill() != 0){
                index++;
                if(tr.gameObject.GetComponent<skillData>().getSelectedSkill() == 1){
                    idSkill1 = tr.gameObject.GetComponent<skillData>().getID();
                    display1.GetComponent<Image>().sprite = tr.gameObject.GetComponent<skillData>().img;
                }
                if(tr.gameObject.GetComponent<skillData>().getSelectedSkill() == 2){
                    idSkill2 = tr.gameObject.GetComponent<skillData>().getID();
                    display2.GetComponent<Image>().sprite = tr.gameObject.GetComponent<skillData>().img;
                }
                if(tr.gameObject.GetComponent<skillData>().getSelectedSkill() == 3){
                    idSkill3 = tr.gameObject.GetComponent<skillData>().getID(); 
                    display3.GetComponent<Image>().sprite = tr.gameObject.GetComponent<skillData>().img;
                }
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void indexForward()
    {
        if (index < skillSlot)
        {
            index++;
        }
    }

    public void indexBackward()
    {
        if (index > 0)
        {
            index--;
        }
    }

    public void selectSkill(int id, Sprite img)
    {
        indexForward();
        if(index == 1 && idSkill1 == 0)
        {
            idSkill1 = id;
            display1.GetComponent<Image>().sprite = img;
        }
        if (index == 2 && idSkill2 == 0)
        {
            if(id == idSkill1){
                return;
            }
            idSkill2 = id;
           display2.GetComponent<Image>().sprite = img;
        }
        if (index == 3 && idSkill3 == 0)
        {
            if(id == idSkill1 || id == idSkill2){
                return;
            }
            idSkill3 = id;
            display3.GetComponent<Image>().sprite = img;
        }
    }

    public void unselectSkill()
    {
        if(index == 3)
        {
            idSkill3 = 0;
            display3.GetComponent<Image>().sprite = null;
        }

        if (index == 2)
        {
            idSkill2 = 0;
            display2.GetComponent<Image>().sprite = null;

        }

        if (index == 1)
        {
            idSkill1 = 0;
            display1.GetComponent<Image>().sprite = null;

        }
        indexBackward();
    }

    public void selectSkillB(){
        GameObject data = GameObject.FindGameObjectWithTag("Data");
        StartCoroutine(selectSkill(idSkill1, idSkill2, idSkill3, data.GetComponent<dataHolder>().userId));
    }

    IEnumerator selectSkill(int idSkill1,int idSkill2,int idSkill3, int idUser)
    {
        string selectSkillUrl = "http://localhost/duanTN/skillSelection.php";
        WWWForm form = new WWWForm();
        form.AddField("idplayer", idUser);        
        form.AddField("idskill1", idSkill1); 
        form.AddField("idskill2", idSkill2);
        form.AddField("idskill3", idSkill3);


        using (UnityWebRequest www = UnityWebRequest.Post(selectSkillUrl, form))
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
                    StartCoroutine(GetSkillTradeHistory(idUser+""));
                }
                else if(itemsData["Status"] == 0){
                    Debug.Log(itemsData["Mes"]);
                }
                
            }
        }
    }

    IEnumerator GetSkillTradeHistory(string idUser)
    {
        string getSkillTradeUrl = "http://localhost/duanTN/getTradeSkill.php";
        WWWForm form = new WWWForm();
        form.AddField("idUser", idUser);
        using (UnityWebRequest www = UnityWebRequest.Post(getSkillTradeUrl, form))
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
                GameObject skillHolder = GameObject.FindGameObjectWithTag("SkillData");
                foreach(JSONNode item in itemsData["data"]){
                    JSONNode skillData = item["tradeSkill"];  
                    foreach(Transform tr in skillHolder.transform){             
                        if((skillData["skillid"]+"") == (tr.GetComponent<skillData>().getID()+"")){
                            tr.GetComponent<skillData>().setCurrentLV(skillData["skilllv"]);
                            tr.GetComponent<skillData>().setSelectedSkill(skillData["selected"]);                            
                            tr.GetComponent<skillData>().setIsOwn(true);

                        }
                    }
                }
                
            }
        }
    }
}
