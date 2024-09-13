using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class userUI : MonoBehaviour
{
    [SerializeField] private Image exp;
    [SerializeField] private TextMeshProUGUI expT, name;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject data = GameObject.FindGameObjectWithTag("Data");
        expT.text = data.GetComponent<dataHolder>().exp+"/100";
        name.text = data.GetComponent<dataHolder>().nameUser+" - LV: " + data.GetComponent<dataHolder>().Level;
        float e = (float)data.GetComponent<dataHolder>().exp;
        exp.fillAmount = e / 100f;
    }
}
