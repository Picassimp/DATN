using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HealthUI : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] private Image fillBar;
    [SerializeField] private TextMeshProUGUI valueText;    
    [SerializeField] private TextMeshProUGUI gold;

    private float max;
    private float current;    
    private float currentG;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        max = Player.GetComponent<playerStat>().maxH();
        current = Player.GetComponent<playerStat>().curH();
        fillBar.fillAmount = current / max;
        valueText.text = current.ToString() + " / " + max.ToString();

        currentG = Player.GetComponent<playerStat>().getGold();
        gold.text = "$: "+currentG.ToString();

    }
}
