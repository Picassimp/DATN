using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class charDataHolder : MonoBehaviour
{
    [SerializeField] private GameObject charData;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void addChar(int id, string name, int gia, float hp, float dmg, float spd, int sprite, float bonusHP, float bonusDMG, float bonusSPD, int upG, int exp, int lv, int maxLV){
        var cD = Instantiate(charData, gameObject.transform.position, Quaternion.identity);
        cD.GetComponent<charData>().id = id; 
        cD.GetComponent<charData>().name = name;
        cD.GetComponent<charData>().gia = gia;
        cD.GetComponent<charData>().hp = hp;
        cD.GetComponent<charData>().dmg = dmg;        
        cD.GetComponent<charData>().spd = spd;        
        cD.GetComponent<charData>().spriteNum = sprite;
        cD.GetComponent<charData>().bonushp = bonusHP;
        cD.GetComponent<charData>().bonusdmg = bonusDMG;
        cD.GetComponent<charData>().bonusspd = bonusSPD;
        cD.GetComponent<charData>().upgradeG = upG;
        cD.GetComponent<charData>().exp = exp;
        cD.GetComponent<charData>().lv = lv;
        cD.GetComponent<charData>().maxLV = maxLV;


        cD.transform.parent = gameObject.transform;
    }

    
}
