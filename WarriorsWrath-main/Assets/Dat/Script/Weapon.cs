using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Weapon
{
    public GameObject prefabs; 
    public int weaponID;
    public Sprite weaponSprite;
    public int weaponPrice;
    public bool bought;

}
