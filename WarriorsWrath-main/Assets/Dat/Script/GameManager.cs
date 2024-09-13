using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] private float money;

    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;

    }
    void Update()
    {
        UpdateUI();
    }


    public void AddMoney(float amount)
    {
        money += amount;
    }
    public void ReduceMoney(float amount)
    {
        money -= amount;
    }

    public bool RequestMoney(float amount)
    {
        if (amount <= money)
        {
            return true;
        }
        return false;
    }

    void UpdateUI()
    {
        moneyText.text = "" + money.ToString("N2");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        moneyText.text = "" + player.GetComponent<playerStat>().getGold();
    }
}
