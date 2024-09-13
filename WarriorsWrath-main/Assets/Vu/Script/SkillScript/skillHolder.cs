using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System;

public class skillHolder : MonoBehaviour
{
    public int skillSlot;
    [SerializeField] private float skillCD1;
    [SerializeField] private float skillCD2;
    [SerializeField] private float skillCD3;
    [SerializeField] private float skillWaitTime;    
    [SerializeField] private bool isPlaying;

    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        //skillSlot = GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().skillSlot;
        if(!isPlaying){
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)  && skillSlot>=1 && skillCD1<=0 && skillWaitTime<=0)
        {
            foreach(Transform child in transform)
            {
                if(child.GetComponent<skillData>().getSelectedSkill() == 1)
                {
                    child.GetComponent<skillData>().ActivateSkill();
                    skillCD1 = child.GetComponent<skillData>().getCountdown();
                    skillWaitTime = 1f;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && skillSlot >= 2 && skillCD2 <= 0 && skillWaitTime <= 0)
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<skillData>().getSelectedSkill() == 2)
                {
                    child.GetComponent<skillData>().ActivateSkill();
                    skillCD2 = child.GetComponent<skillData>().getCountdown();
                    skillWaitTime = 1f;
                }
            }
        }

        skillCD1 -= Time.deltaTime;
        skillCD2 -= Time.deltaTime;
        skillCD3 -= Time.deltaTime;
        skillWaitTime -= Time.deltaTime;
    }

    public void Play(){
        isPlaying = true;
    }

    public float getCD1(){
        return skillCD1;
    }
    public float getCD2(){
        return skillCD2;
    }
    public float getCD3(){
        return skillCD3;
    }

    public float getWait(){
        return skillWaitTime;
    }
}
