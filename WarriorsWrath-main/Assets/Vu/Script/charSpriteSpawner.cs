using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charSpriteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] charSprite;
    private GameObject data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
        if(data.GetComponent<dataHolder>().selectSprite == 1){
            var newChar = Instantiate(charSprite[1], transform.position, Quaternion.identity);
            newChar.transform.parent = gameObject.transform;
            newChar.transform.localPosition = new Vector3(0f, 0.08f, 0f);
        }
        else if(data.GetComponent<dataHolder>().selectSprite == 2){
            var newChar = Instantiate(charSprite[2], transform.position, Quaternion.identity);
            newChar.transform.parent = gameObject.transform;
            newChar.transform.localPosition = new Vector3(0f, 0.08f, 0f);
        }
        else{
            var newChar = Instantiate(charSprite[0], transform.position, Quaternion.identity);
            newChar.transform.parent = gameObject.transform;
            newChar.transform.localPosition = new Vector3(0f, 0.08f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
