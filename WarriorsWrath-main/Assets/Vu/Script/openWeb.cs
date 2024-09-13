using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openWeb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open(){
        Application.OpenURL("http://localhost/DuanTN/loginuser.php");
    }
}
