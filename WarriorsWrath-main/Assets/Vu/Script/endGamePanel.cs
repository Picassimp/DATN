using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endGamePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text result;
    [SerializeField] private Text time;    
    [SerializeField] private Text score;

    // Start is called before the first frame update
    void OnEnable()
    {
        var data = GameObject.FindGameObjectWithTag("Data");
        if(data.GetComponent<dataHolder>().status == 0){
            result.text = "Defeat";
        }
        else if(data.GetComponent<dataHolder>().status == 1){
            result.text = "Victoy";
        }
        TimeSpan time1 = TimeSpan.FromSeconds((double) data.GetComponent<dataHolder>().time);
        time.text = time1.ToString(@"mm\.ss");  
        Debug.Log(time1.ToString(@"mm\.ss"));      
        score.text = data.GetComponent<dataHolder>().score + "";
    }

    public void reload(){
        var data = GameObject.FindGameObjectWithTag("Data");
        data.GetComponent<dataHolder>().resetTimer();
        data.GetComponent<dataHolder>().startTimer();        
        data.GetComponent<dataHolder>().stage = 1;
        data.GetComponent<dataHolder>().status = 0;

        SceneManager.LoadScene("Map test");
        Destroy(gameObject);
    }

    public void gotoMenu(){
        var data = GameObject.FindGameObjectWithTag("Data");
        data.GetComponent<dataHolder>().resetTimer();        
        data.GetComponent<dataHolder>().stage = 1;
        data.GetComponent<dataHolder>().status = 0;

        
        SceneManager.LoadScene("map1");
        Destroy(gameObject);
    }
}
