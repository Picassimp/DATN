using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenesLoader : MonoBehaviour
{
    public void LoadScene(){
        SceneManager.LoadScene("login");
        Destroy(GameObject.FindGameObjectWithTag("Data"));
        Destroy(GameObject.FindGameObjectWithTag("CharData"));
    }
}
