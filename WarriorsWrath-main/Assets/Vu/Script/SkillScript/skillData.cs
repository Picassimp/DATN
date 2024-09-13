using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillData : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private int price;
    [SerializeField] private string description;
    [SerializeField] private float stat;
    [SerializeField] private float bonusStat;
    [SerializeField] private float duration;
    [SerializeField] private float bonusDuration;
    [SerializeField] private float countdown;
    [SerializeField] private int upgradePrice;
    [SerializeField] private int maxLV;
    [SerializeField] private int currentLV;
    [SerializeField] private int selectedSkill;    
    [SerializeField] private bool isOwn;

    public Sprite img;


    [SerializeField] private GameObject skillActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateSkill()
    {
        skillActive.SetActive(true);
    }

    public void setID(int id1)
    {
        id = id1;
    }

    public int getID()
    {
        return id;
    }

    public void setName(string name1)
    {
        name = name1;
    }

    public string getName()
    {
        return name;
    }

    public void setPrice(int price1)
    {
        price = price1;
    }

    public int getPrice()
    {
        return price;
    }

    public void setDescription(string description1)
    {
        description = description1;
    }

    public string getDescription()
    {
        return description;
    }

    public void setStat(float stat1)
    {
        stat = stat1;
    }

    public float getStat()
    {
        return stat;
    }

    public void setBonusStat(float bonusStat1)
    {
        bonusStat = bonusStat1;
    }

    public float getBonusStat()
    {
        return bonusStat;
    }

    public void setDuration(float duration1)
    {
        duration = duration1;
    }

    public float getDuration()
    {
        return duration;
    }

    public void setBonusDuration(float bonusDuration1)
    {
        bonusDuration = bonusDuration1;
    }

    public float getBonusDuration()
    {
        return bonusDuration;
    }

    public void setCountdown(float countdown1)
    {
        countdown = countdown1;
    }

    public float getCountdown()
    {
        return countdown;
    }

    public void setUpgradePrice(int upgradePrice1)
    {
        upgradePrice = upgradePrice1;
    }

    public int getUpgradePrice()
    {
        return upgradePrice;
    }

    public void setMaxLV(int maxLV1)
    {
        maxLV = maxLV1;
    }

    public int getMaxLV()
    {
        return maxLV;
    }

    public void setCurrentLV(int currentLV1)
    {
        currentLV = currentLV1;
    }

    public int getCurrentLV()
    {
        return currentLV;
    }

    public void setSelectedSkill(int selectedSkill1)
    {
        selectedSkill = selectedSkill1;
    }

    public int getSelectedSkill()
    {
        return selectedSkill;
    }

    public void setIsOwn(bool isOwn1)
    {
        isOwn = isOwn1;
    }

    public bool getIsOwn()
    {
        return isOwn;
    }
}
