using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class unityLoginRegisterLogout : MonoBehaviour
{
    // Start is called before the first frame update
    public string baseUrl = "http://localhost/duanTN/Login.php";
    public string tradeUrl = "http://localhost/duanTN/GetTradeHistory.php";

    public string addTradeUrl = "http://localhost/duanTN/addTrade.php";

    public string getCharUrl = "http://localhost/duanTN/getNhanvat.php";    
    public string getSkillUrl = "http://localhost/duanTN/getSkill.php";    
    public string getSkillTradeUrl = "http://localhost/duanTN/getTradeSkill.php";



    private GameObject dataHolder;
    private GameObject charDataHolder;    
    private GameObject skillDataHolder;

     
    public InputField accountUserName;
    public InputField accountName;
    public InputField accountPassword;
   
    public Text info;
    private string currentUsername;
    private string ukey = "accountusername";
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        dataHolder = GameObject.FindGameObjectWithTag("Data");        
        charDataHolder = GameObject.FindGameObjectWithTag("CharData");        
        skillDataHolder = GameObject.FindGameObjectWithTag("SkillData");


        currentUsername = "";
         
        if(PlayerPrefs.HasKey(ukey)){
            
            if(PlayerPrefs.GetString(ukey) != ""){
                currentUsername = PlayerPrefs.GetString(ukey);
                info.text = "You are loget in = " + currentUsername;
            }else{
                info.text = "You are not loged in.";
            }
        }else{
            info.text = "You are not loged in.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AccountLogout(){
        currentUsername = "";
        PlayerPrefs.SetString(ukey, currentUsername);
        info.text = "You are just loged out.";
    }
    public void AccountRegister()
    {
        string uName = accountUserName.text;
        string name1 = accountName.text;
        string pWord = accountPassword.text;
        StartCoroutine(RegisterNewAccount(uName, name1,pWord));
    }

    public void AccountLogin()
    {
        string uName = accountUserName.text;
        string pWord = accountPassword.text;
        StartCoroutine(LoginAccount(uName, pWord));

    }
     
    
     
    IEnumerator RegisterNewAccount(string uName, string name,string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("newAccountUsername", uName);
        form.AddField("newAccountName", name);
        form.AddField("newAccountPassword", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
  
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //string responseText = www.downloadHandler.text;
                //Debug.Log("Response = " + responseText);
                //info.text = "Response = " + responseText;
                JSONNode itemsData = JSON.Parse(www.downloadHandler.text);
                
                if(itemsData["Status"] == 1){
                    Debug.Log("The generated item is: \nName: " + itemsData["Name"]);
                    Debug.Log("The generated item is: \nDiem: " + itemsData["Diem"]);
                    Debug.Log("ID tao: \nId: " + itemsData["Id"]);
                    
                    StartCoroutine(AddNewTrade(itemsData["Id"], "1", 0));
                }   
            }
        }
    }

    IEnumerator AddNewTrade(string idTK, string idNV, int gia)
    {
        WWWForm form = new WWWForm();
        form.AddField("idTK", idTK);
        form.AddField("idNV", idNV);
        form.AddField("gia", gia);
        using (UnityWebRequest www = UnityWebRequest.Post(addTradeUrl, form))
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

                int randomNum2 = Random.Range( 1, itemsData["Status"].Count);
                Debug.Log("okokaaaa");
                
                if(itemsData["Status"] == 1){
                    Debug.Log("OK");
                    
                    SceneManager.LoadScene("login");
                }
            }
        }
    }



    IEnumerator LoginAccount(string uName, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", uName);
        form.AddField("loginPassword", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
  
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //if(responseText == "1"){
                    //PlayerPrefs.SetString(ukey, uName);
                    //info.text = "Login Success with username " + uName;
                    //SceneManager.LoadSceneAsync("map1");
                //}else{
                    //info.text = "Login Failed! ";
                //}
                
                JSONNode itemsData = JSON.Parse(www.downloadHandler.text);

                if(itemsData["Status"] == 1){
                    dataHolder.GetComponent<dataHolder>().setUserID(itemsData["Id"]);
                    dataHolder.GetComponent<dataHolder>().setDiem(itemsData["Diem"]);
                    dataHolder.GetComponent<dataHolder>().setName(itemsData["Name"]);
                    dataHolder.GetComponent<dataHolder>().setLevel(itemsData["Level"]);
                    dataHolder.GetComponent<dataHolder>().setExp(itemsData["Exp"]);
                    dataHolder.GetComponent<dataHolder>().setDaily(itemsData["nv1"],itemsData["rewardNV1"],itemsData["nv2"],itemsData["rewardNV2"],itemsData["nv3"],itemsData["rewardNV3"]);
                    dataHolder.GetComponent<dataHolder>().setSkillSlot(itemsData["SkillSlot"]);

                    GameObject.FindGameObjectWithTag("SkillData").GetComponent<skillHolder>().skillSlot = itemsData["SkillSlot"];

                    // goi api lay tat ca Tài khoản giao dịch theo id
                    StartCoroutine(GetTradeHistory(itemsData["Id"]));
                    StartCoroutine(GetCharacterData());                    
                    StartCoroutine(GetSkillData());
                    StartCoroutine(GetSkillTradeHistory(itemsData["Id"]));
                    SceneManager.LoadSceneAsync("map1");
                }
                if(itemsData["Status"] == 0){
                    Debug.Log("cook");
                }
                
            }
        }
    }

    IEnumerator GetTradeHistory(string idUser)
    {
        WWWForm form = new WWWForm();
        form.AddField("idUser", idUser);
        using (UnityWebRequest www = UnityWebRequest.Post(tradeUrl, form))
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

                foreach(JSONNode item in itemsData["data"]){
                    JSONNode tradeHistory = item["trade"];
                    dataHolder.GetComponent<dataHolder>().addTrade(tradeHistory["id"], tradeHistory["date"],tradeHistory["idtk"],tradeHistory["idnv"],tradeHistory["gia"],tradeHistory["hpLV"],tradeHistory["dmgLV"],tradeHistory["spdLV"],tradeHistory["NVLV"],tradeHistory["NVEXP"],tradeHistory["selected"]);
                }
                
            }
        }
    }

    IEnumerator GetCharacterData()
    {
        WWWForm form = new WWWForm();
        using (UnityWebRequest www = UnityWebRequest.Post(getCharUrl, form))
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
                int sprite = 0;
                foreach(JSONNode item in itemsData["data"]){
                    JSONNode charData = item["char"];
                    charDataHolder.GetComponent<charDataHolder>().addChar(charData["id"], charData["name"], charData["gia"], charData["hp"], charData["dmg"], charData["spd"], sprite, charData["bonusHP"], charData["bonusDMG"], charData["bonusSPD"], charData["giaNC"], charData["expNC"], charData["maxLV"], charData["MaxStatLV"]);
                    Debug.Log(sprite);
                    
                    if(charData["id"] == "1"){
                        dataHolder.GetComponent<dataHolder>().selectHp = charData["hp"]; 
                        dataHolder.GetComponent<dataHolder>().selectDmg = charData["dmg"];
                        dataHolder.GetComponent<dataHolder>().selectSpd = charData["spd"];
                        dataHolder.GetComponent<dataHolder>().selectSprite = sprite;
                    }
                    sprite++;
                }
                
            }
        }
    }

    IEnumerator GetSkillData()
    {
        WWWForm form = new WWWForm();
        using (UnityWebRequest www = UnityWebRequest.Post(getSkillUrl, form))
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
                foreach(JSONNode item in itemsData["data"]){
                    JSONNode skillData = item["skill"];                    
                    foreach(Transform tr in skillDataHolder.transform){
                        if((skillData["idSkill"]+"") == (tr.GetComponent<skillData>().getID()+"")){
                            tr.GetComponent<skillData>().setName(skillData["tenSkill"]);
                            tr.GetComponent<skillData>().setPrice(skillData["gia"]);
                            tr.GetComponent<skillData>().setDescription(skillData["mota"]);
                            tr.GetComponent<skillData>().setStat(skillData["thongSo"]);
                            tr.GetComponent<skillData>().setBonusStat(skillData["bonusTS"]);
                            tr.GetComponent<skillData>().setDuration(skillData["time"]);
                            tr.GetComponent<skillData>().setBonusDuration(skillData["timeTS"]);
                            tr.GetComponent<skillData>().setCountdown(skillData["countdown"]);
                            tr.GetComponent<skillData>().setUpgradePrice(skillData["giaNC"]);
                            tr.GetComponent<skillData>().setMaxLV(skillData["maxLV"]);
                        }
                    }
                }
                
            }
        }
    }

    IEnumerator GetSkillTradeHistory(string idUser)
    {
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

                foreach(JSONNode item in itemsData["data"]){
                    JSONNode skillData = item["tradeSkill"];  
                    
               
                    foreach(Transform tr in skillDataHolder.transform){             
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




