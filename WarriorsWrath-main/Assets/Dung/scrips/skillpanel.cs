using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

public class skillpanel : MonoBehaviour
{
    //public List<Image> listImgLvPoint;
    public int id;
    public int skillmaxLV = 10;
    public int skillCurLV;
    public GameObject skilllv;
    public bool isOwn = false;
    public Text skillname;
    public Image skillimage;
    public Button buybutton;
    public Text buybuttonT;
    public Button nangcapbutton;
    public Text nangcapbuttonT;
    public Button dungbutton;    
    public Text dungbuttonT;


    public int price;
    public float stat;
    public float bonusStat;
    public float duration;
    public float bonusDuration;
    public int upgradePrice;
    public int selectedSkill;    
    public Sprite img;


    [SerializeField] private Image skillLVIMG;
    [SerializeField] private Image skillIMG;
    private GameObject DataHolder;
    public GameObject data;
    // Start is called before the first frame update
    void Start()
    {
        DataHolder = GameObject.FindGameObjectWithTag("Data");
        changecolor();
        for (int i = 1; i < skillmaxLV; i++)
        {
            //listImgLvPoint[i].color = Color.gray;
            var img = Instantiate(skillLVIMG, skilllv.transform.position, Quaternion.identity);
            img.transform.parent = skilllv.transform;
            img.gameObject.GetComponent<Image>().color = Color.white;
            img.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }

        buybuttonT.text = price+"";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOwn == false)
        {
            nangcapbutton.gameObject.SetActive(false);
            dungbutton.gameObject.SetActive(false);
            buybutton.gameObject.SetActive(true);
            skilllv.SetActive(false);
        }
        else
        {
            nangcapbutton.gameObject.SetActive(true);
            dungbutton.gameObject.SetActive(true);
            buybutton.gameObject.SetActive(false);
            skilllv.SetActive(true);
        }

            skillCurLV =  data.GetComponent<skillData>().getCurrentLV();
            isOwn =  data.GetComponent<skillData>().getIsOwn();
            upgradePrice =  data.GetComponent<skillData>().getUpgradePrice();
            selectedSkill =  data.GetComponent<skillData>().getSelectedSkill(); 
            changecolor();

            if(selectedSkill != 0){
                
                dungbuttonT.text = "Đang dùng";
                dungbutton.interactable = false;
            }
            else{
                dungbuttonT.text = "Dùng";
                dungbutton.interactable = true;

                
            }

            if(skillCurLV < skillmaxLV){
                nangcapbuttonT.text = (upgradePrice * skillCurLV) + "";
            }
            else{
                nangcapbuttonT.text = "Max";
                nangcapbutton.interactable = false;
            }
            skillIMG.GetComponent<Image>().sprite = img;
    }
    public void buyskill ()
    {
        isOwn = true;
        
    }
    public void useskill()
    {
        //GameObject controller = GameObject.Find("controllerskill");
        //controller.GetComponent<controller>().isupdateusedskill = true;
        //controller.GetComponent<controller>().idskillupdate = id;
        GameObject skillShop = GameObject.FindGameObjectWithTag("skillShop");
        skillShop.GetComponent<shopSelect>().selectSkill(id, img);
    }
    public void upskill()
    {
        
        if (skillCurLV < skillmaxLV)
        {
            skillCurLV++;
            Debug.Log(skillCurLV +"");
        }
        
    }
    private void changecolor()
    {
        if (skillCurLV > 0)
        {
            int i = 1;
            foreach(Transform tr in skilllv.transform)
            {
                if(i<=skillCurLV)
                {
                    tr.gameObject.GetComponent<Image>().color = Color.green;
                    i++;
                }
            }
        }
    }

    public void buySkill1(){
        Debug.Log(DataHolder.GetComponent<dataHolder>().userId+"");
        Debug.Log(id+"");
        Debug.Log(price);

        StartCoroutine(AddNewTrade(DataHolder.GetComponent<dataHolder>().userId+"", id+"", price));
    }

    IEnumerator AddNewTrade(string idTK, string idSkill, int gia)
    {
        string buySkillUrl = "http://localhost/duanTN/addTradeSkill.php";
        WWWForm form = new WWWForm();
        form.AddField("idTK", idTK);
        form.AddField("idskill", idSkill);
        form.AddField("gia", gia);
        using (UnityWebRequest www = UnityWebRequest.Post(buySkillUrl, form))
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
                    GameObject skillHolder = GameObject.FindGameObjectWithTag("SkillData");
                    foreach(Transform tr in skillHolder.transform)
                    {
                        if((itemsData["Idskill"] + "") == (tr.gameObject.GetComponent<skillData>().getID()+""))
                        {
                            tr.gameObject.GetComponent<skillData>().setCurrentLV(itemsData["LV"]);
                            tr.gameObject.GetComponent<skillData>().setIsOwn(true);                            
                            tr.gameObject.GetComponent<skillData>().setSelectedSkill(itemsData["Select"]);
                        }
                    }
                    DataHolder.GetComponent<dataHolder>().diemUser = itemsData["Tien"];
                }
                else {
                    Debug.Log(itemsData["Mes"]);
                }
            }
        }
    }


    public void upgradeSkill(){
        int idUser = GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().userId;
        StartCoroutine(UpSkillAPI(id, idUser));
    }

    IEnumerator UpSkillAPI(int idSkill, int idUser)
    {
        string upSkillUrl = "http://localhost/duanTN/upgradeSkill.php";
        WWWForm form = new WWWForm();
        form.AddField("idplayer", idUser);        
        form.AddField("idskill", idSkill);

        using (UnityWebRequest www = UnityWebRequest.Post(upSkillUrl, form))
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
                    GameObject skillHolder = GameObject.FindGameObjectWithTag("SkillData");
                    foreach(Transform tr in skillHolder.transform){              
                        if((itemsData["upgradedSkillID"]+"") == (tr.GetComponent<skillData>().getID()+"")){
                            tr.GetComponent<skillData>().setCurrentLV(itemsData["upgradedSkillLV"]);
                            GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().diemUser = itemsData["remainGlod"];
                        }
                    }
                }
                else if(itemsData["Status"] == 0){
                    Debug.Log(itemsData["Mes"]);
                }
                
            }
        }
    }
}
