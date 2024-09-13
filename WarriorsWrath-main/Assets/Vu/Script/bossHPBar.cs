using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class bossHPBar : MonoBehaviour
{
    private GameObject Boss;
    [SerializeField] private Image fillBar;
    [SerializeField] private TextMeshProUGUI valueText;
    private float max;
    private float current;
    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
        
    }

    // Update is called once per frame
    void Update()
    {
        max = Boss.GetComponent<bossStat>().GetMax();
        current = Boss.GetComponent<bossStat>().GetCur();
        fillBar.fillAmount = current / max;
        valueText.text = current.ToString() + " / " + max.ToString();

        if(current <= 0)
        {
            
            Destroy(Boss.gameObject);  
            Destroy(gameObject);
        }
    }
}
