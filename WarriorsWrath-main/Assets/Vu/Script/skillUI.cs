using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class skillUI : MonoBehaviour
{
    [SerializeField] private Image img1,img2,img3,img1CD,img2CD,img3CD;
    private float cd1,cd2,cd3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject skillData = GameObject.FindGameObjectWithTag("SkillData");
        foreach(Transform tr in skillData.transform){
            if(tr.GetComponent<skillData>().getSelectedSkill() == 1){
                img1.sprite = tr.GetComponent<skillData>().img;
                cd1= tr.GetComponent<skillData>().getCountdown();
            }
            else if(tr.GetComponent<skillData>().getSelectedSkill() == 2){
                img2.sprite = tr.GetComponent<skillData>().img;
                cd2= tr.GetComponent<skillData>().getCountdown();
            }
            else if(tr.GetComponent<skillData>().getSelectedSkill() == 3){
                img3.sprite = tr.GetComponent<skillData>().img;
                cd3= tr.GetComponent<skillData>().getCountdown();
            }
        }
        float remain1 = skillData.GetComponent<skillHolder>().getCD1();
        if(remain1<0){
            img1CD.fillAmount = skillData.GetComponent<skillHolder>().getWait() / 1f;
        }else{
            img1CD.fillAmount = remain1 / cd1;
        }
        
        float remain2 = skillData.GetComponent<skillHolder>().getCD2();
        if(remain2<0){
            img2CD.fillAmount = skillData.GetComponent<skillHolder>().getWait() / 1f;
        }else{
            img2CD.fillAmount = remain2 / cd2;
        }

        float remain3 = skillData.GetComponent<skillHolder>().getCD3();
        if(remain3<0){
            img3CD.fillAmount = skillData.GetComponent<skillHolder>().getWait() / 1f;
        }else{
            img3CD.fillAmount = remain3 / cd3;
        }
        
    }
}
