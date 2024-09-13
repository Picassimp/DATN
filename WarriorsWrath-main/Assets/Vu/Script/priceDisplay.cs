using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class priceDisplay : MonoBehaviour
{
    private int price;
    [SerializeField] private TextMeshProUGUI  text;
    // Start is called before the first frame update
    void Start()
    {
        price = GetComponent<weaponHolder>().getPrice();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<playerStat>().getGold() < price)
        {
            text.color = new Color(255, 0, 0, 255);
        }
        else
        {
            text.color = new Color(255, 255, 255, 255);
        }
        text.text = price.ToString();
    }
}
