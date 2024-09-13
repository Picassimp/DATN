using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Networking;
using SimpleJSON;
using UnityEditor;

public class shopCharacter : MonoBehaviour
{
    public int id;
    public string name;
    public int gia;
    public float hp;
    public float dmg;    
    public float spd;

    public float bonushp;
    public float bonusdmg;    
    public float bonusspd;

    public int upgradeG;
    public int exp, lv, maxLV;

    public int hpLV;
    public int dmgLV;    
    public int spdLV;

    [SerializeField] private bool isOwn;    
    [SerializeField] private bool isUsed;

    [SerializeField] private Text nameText;        
    [SerializeField] private Image bg;    

    [SerializeField] private Text statTextHP, statTextDMG, statTextSPD;    
    [SerializeField] private Text priceText, upHPT, upDMGT, upSPDT;    
    [SerializeField] private Button buyButt;

    [SerializeField] private GameObject DataHolder;

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image image;
    [SerializeField] private GameObject cHP, cDMG,cSPD;

    public int spriteNum;
    private bool doneChecking;

    private bool isexpand = false;

    private string addTradeUrl = "http://localhost/duanTN/addTrade.php";

    // Start is called before the first frame update
    void Start()
    {
        doneChecking = false;
        DataHolder = GameObject.FindGameObjectWithTag("Data");
        nameText.text = name;        
        priceText.text = gia+"";
        

        if(spriteNum <= 2){
            image.sprite = sprites[spriteNum];
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(!doneChecking){
            setIsOwn();
        }

        if(id == DataHolder.GetComponent<dataHolder>().selectCharID){
            isUsed = true;
            DataHolder.GetComponent<dataHolder>().selectHp = (hp + bonushp*hpLV); 
            DataHolder.GetComponent<dataHolder>().selectDmg = (dmg+ bonusdmg*dmgLV);
            DataHolder.GetComponent<dataHolder>().selectSpd = (spd + bonusspd*spdLV);
            DataHolder.GetComponent<dataHolder>().selectSprite = spriteNum;
        }

        if(DataHolder.GetComponent<dataHolder>().diemUser < gia){
            buyButt.interactable = false;
        }
        else{
            buyButt.interactable = true;
        }

        if(isOwn && !isUsed){
            priceText.text = "Use";
            buyButt.interactable = true;
        }

        if(isOwn && isUsed){
            priceText.text = "Used";
            buyButt.interactable = false;
        }
        statTextHP.text = "Hp:" + (hp + bonushp*hpLV);
        statTextDMG.text = " Dmg:" + (dmg+ bonusdmg*dmgLV);
        statTextSPD.text = "Spd:" + (spd + bonusspd*spdLV) ;

        //tien nang cap
        if(!isOwn){
            upHPT.gameObject.transform.parent.GetComponent<Button>().interactable = false;
            upDMGT.gameObject.transform.parent.GetComponent<Button>().interactable = false;
            upSPDT.gameObject.transform.parent.GetComponent<Button>().interactable = false;
        }
        if(hpLV < 10){
            upHPT.text = hpLV*upgradeG+"";
        }
        else{
            upHPT.text = "Max";
            upHPT.gameObject.transform.parent.GetComponent<Button>().interactable = false;
        }

        if(dmgLV < 10){
            upDMGT.text = dmgLV*upgradeG+"";
        }
        else{
            upDMGT.text = "Max";
            upDMGT.gameObject.transform.parent.GetComponent<Button>().interactable = false;
        }

        if(spdLV < 10){
            upSPDT.text = spdLV*upgradeG+"";
        }
        else{
            upSPDT.text = "Max";
            upSPDT.gameObject.transform.parent.GetComponent<Button>().interactable = false;
        }

        changecolor();
    }

    public void setValue(int id1, string name1, int gia1, float hp1, float dmg1, float spd1, int sprite, float bonusHP1, float bonusDMG1, float bonusSPD1, int upgradeG1){
        id= id1;
        name = name1;
        gia = gia1;
        hp = hp1;
        dmg = dmg1;
        spd = spd1;
        spriteNum = sprite;


        bonushp = bonusHP1;
        bonusdmg = bonusDMG1;    
        bonusspd = bonusSPD1;

        upgradeG = upgradeG1;
    }

    private void setIsOwn(){
        foreach (Transform child in DataHolder.transform){
            
            int id1 = child.GetComponent<tradeHistory>().idnv;
            if(id == id1){
                isOwn = true;
                hpLV = child.GetComponent<tradeHistory>().hpLV;
                dmgLV = child.GetComponent<tradeHistory>().dmgLV;
                spdLV = child.GetComponent<tradeHistory>().spdLV;
                upHPT.gameObject.transform.parent.GetComponent<Button>().interactable = true;
            upDMGT.gameObject.transform.parent.GetComponent<Button>().interactable = true;
            upSPDT.gameObject.transform.parent.GetComponent<Button>().interactable = true;
;
                doneChecking = true;
            }
        }
    }

    public void buyChar(){
        if(DataHolder.GetComponent<dataHolder>().diemUser > gia && !isOwn && !isUsed){
            StartCoroutine(AddNewTrade(DataHolder.GetComponent<dataHolder>().userId+"", id+"", gia));
        }

        else if(isOwn && !isUsed){
           foreach (Transform child in gameObject.transform.parent.transform){
                child.GetComponent<shopCharacter>().isUsed = false;
            }
            isUsed = true;
            DataHolder.GetComponent<dataHolder>().selectCharID = id;
        }
    }

    IEnumerator AddNewTrade(string idTK, string idNV, int gia)
    {
        WWWForm form = new WWWForm();
        form.AddField("idTK", idTK);
        form.AddField("idNV", idNV);
        form.AddField("gia", gia);
        Debug.Log(idTK);
        Debug.Log(idNV);
        Debug.Log(gia);
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

                
                
                if(itemsData["Status"] == 1){
                    DataHolder.GetComponent<dataHolder>().addTrade(-1, "now", itemsData["Idtk"], itemsData["Idnv"], itemsData["Gia"], 1,1,1,1,0,0);
                    DataHolder.GetComponent<dataHolder>().diemUser = itemsData["Tien"];
                }
                else{
                    Debug.Log("ko du tien");
                }
            }
        }
    }

    private void changecolor()
    {
        if (hpLV > 0)
        {
            int i = 1;
            foreach(Transform tr in cHP.transform)
            {
                if(i<=hpLV)
                {
                    tr.gameObject.GetComponent<Image>().color = Color.green;
                    i++;
                }
            }
        }

        if (dmgLV > 0)
        {
            int y = 1;
            foreach(Transform tr in cDMG.transform)
            {
                if(y<=dmgLV)
                {
                    tr.gameObject.GetComponent<Image>().color = Color.green;
                    y++;
                }
            }
        }

        if (spdLV > 0)
        {
            int z = 1;
            foreach(Transform tr in cSPD.transform)
            {
                if(z<=spdLV)
                {
                    tr.gameObject.GetComponent<Image>().color = Color.green;
                    z++;
                }
            }
        }
    }

    public void upgradeChar(int type){
        int idUser = GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().userId;
        StartCoroutine(UpChar(id, idUser,type));
    }

    IEnumerator UpChar(int idSkill, int idUser, int type)
    {
        string upCharUrl = "http://localhost/duanTN/upgradeChar.php";
        WWWForm form = new WWWForm();
        form.AddField("idplayer", idUser);        
        form.AddField("idchar", idSkill);        
        form.AddField("type", type);


        using (UnityWebRequest www = UnityWebRequest.Post(upCharUrl, form))
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
                    foreach(Transform tr in DataHolder.transform){              
                        if((itemsData["upgradedCharID"]+"") == (tr.GetComponent<tradeHistory>().idnv+"")){
                            if((itemsData["type"]+"") == 1+""){
                                //set cap HP
                                tr.GetComponent<tradeHistory>().hpLV = itemsData["upgradedCharLV"];
                                hpLV = itemsData["upgradedCharLV"];
                            }
                            else if((itemsData["type"]+"") == 2+""){
                                //set cap DMG
                                tr.GetComponent<tradeHistory>().dmgLV = itemsData["upgradedCharLV"];
                                dmgLV = itemsData["upgradedCharLV"];
                            }
                            else if((itemsData["type"]+"") == 3+""){
                                //set cap SPD
                                tr.GetComponent<tradeHistory>().spdLV = itemsData["upgradedCharLV"];
                                spdLV = itemsData["upgradedCharLV"];
                            }
                            DataHolder.GetComponent<dataHolder>().diemUser = itemsData["remainGlod"];
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
