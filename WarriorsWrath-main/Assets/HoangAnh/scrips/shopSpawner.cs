using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopSpawner : MonoBehaviour
{
    private GameObject charHolder;
    [SerializeField] private GameObject charPrepab;
    // Start is called before the first frame update
    void Start()
    {
        charHolder = GameObject.FindGameObjectWithTag("CharData");
        foreach (Transform child in transform) {
	        GameObject.Destroy(child.gameObject);
        }
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawn(){
        foreach (Transform child in charHolder.transform){
            
            int id = child.GetComponent<charData>().id;
            string name = child.GetComponent<charData>().name;
            int gia = child.GetComponent<charData>().gia;
            float hp = child.GetComponent<charData>().hp;
            float dmg = child.GetComponent<charData>().dmg;
            float spd = child.GetComponent<charData>().spd;            
            int sprite = child.GetComponent<charData>().spriteNum;
            float bonusHP = child.GetComponent<charData>().bonushp;
            float bonusDMG = child.GetComponent<charData>().bonusdmg;
            float bonusspd = child.GetComponent<charData>().bonusspd;
            int upG = child.GetComponent<charData>().upgradeG;

            var newPre = Instantiate(charPrepab, gameObject.transform.position, Quaternion.identity);
            newPre.gameObject.GetComponent<shopCharacter>().setValue(id, name, gia, hp ,dmg, spd, sprite, bonusHP, bonusDMG, bonusspd, upG);
            newPre.transform.SetParent(gameObject.transform);
            newPre.transform.localScale = new Vector3(1f,1f,1f);
        }
            
    }
}
