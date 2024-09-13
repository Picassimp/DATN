using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDirection : MonoBehaviour
{
    private GameObject weaponHolder;
    private bool isRight;

    private Camera camera;
    private Vector3 mousePos;

    private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        int count = this.transform.gameObject.transform.parent.childCount;

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        if (count == 1) {

            if (rotZ > 90 || rotZ < -90)
            {
                GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
            }
            return;
        }
        var wh = this.transform.gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject;
        if (wh == null)
        {
            return;
        }
        else
        {
            weaponHolder = wh;
        }

        isAttacking = weaponHolder.GetComponent<weaponHolder>().getIsAttacking();

        
        if (isAttacking == false)
        {
            //lat vu khi khi doi goc
            if (rotZ > 90 || rotZ < -90)
            {
                gameObject.transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);
                isRight = false;
            }
            else
            {
                gameObject.transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                isRight = true;
            }
        }
    }
}
