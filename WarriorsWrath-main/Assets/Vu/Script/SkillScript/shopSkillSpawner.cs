using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopSkillSpawner : MonoBehaviour
{
    [SerializeField] private GameObject skillPre;
    [SerializeField] private GameObject content;
    //[SerializeField] private GameObject skillData;
    // Start is called before the first frame update
    void Start()
    {
        GameObject skillData = GameObject.FindGameObjectWithTag("SkillData");
        foreach (Transform tr in skillData.transform)
        {
            //listImgLvPoint[i].color = Color.gray;
            var skill = Instantiate(skillPre, content.transform.position, Quaternion.identity);
            skill.transform.parent = content.transform;
            skill.transform.localScale = new Vector3(1f, 1f, 1f);
            skill.GetComponent<skillpanel>().id = tr.gameObject.GetComponent<skillData>().getID();
            skill.GetComponent<skillpanel>().skillmaxLV = tr.gameObject.GetComponent<skillData>().getMaxLV();
            skill.GetComponent<skillpanel>().skillCurLV = tr.gameObject.GetComponent<skillData>().getCurrentLV();
            skill.GetComponent<skillpanel>().isOwn = tr.gameObject.GetComponent<skillData>().getIsOwn();
            skill.GetComponent<skillpanel>().skillname.text = tr.gameObject.GetComponent<skillData>().getName();
            skill.GetComponent<skillpanel>().price = tr.gameObject.GetComponent<skillData>().getPrice();
            skill.GetComponent<skillpanel>().stat = tr.gameObject.GetComponent<skillData>().getStat();
            skill.GetComponent<skillpanel>().bonusStat = tr.gameObject.GetComponent<skillData>().getBonusStat();
            skill.GetComponent<skillpanel>().duration = tr.gameObject.GetComponent<skillData>().getDuration();
            skill.GetComponent<skillpanel>().bonusDuration = tr.gameObject.GetComponent<skillData>().getBonusDuration();
            skill.GetComponent<skillpanel>().upgradePrice = tr.gameObject.GetComponent<skillData>().getUpgradePrice();
            skill.GetComponent<skillpanel>().selectedSkill = tr.gameObject.GetComponent<skillData>().getSelectedSkill();               
            skill.GetComponent<skillpanel>().img = tr.gameObject.GetComponent<skillData>().img;            
         
            skill.GetComponent<skillpanel>().data = tr.gameObject;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
