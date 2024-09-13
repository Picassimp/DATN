using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bossfireball;
    private int maxhp = 10;
    private int curenthp = 0;
    void Start()
    {
        curenthp = maxhp;
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Attack()
    {
        while(true)
        {
            if(curenthp>0)
            {
                GameObject f1 = Instantiate(bossfireball);
                f1.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f1.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x + 1f, transform.position.y + 1f, 1);
                Destroy(f1, 1f);

                GameObject f2 = Instantiate(bossfireball);
                f2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f2.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x + 2f, transform.position.y + 2f, 1);
                Destroy(f2, 1f);

                GameObject f3 = Instantiate(bossfireball);
                f3.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f3.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x + 3f, transform.position.y + 3f, 1);
                Destroy(f3, 1f);

                GameObject f4 = Instantiate(bossfireball);
                f4.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f4.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x - 1f, transform.position.y - 1f, 1);
                Destroy(f4, 1f);

                GameObject f5 = Instantiate(bossfireball);
                f5.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f5.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x - 2f, transform.position.y - 2f, 1);
                Destroy(f5, 1f);

                GameObject f6 = Instantiate(bossfireball);
                f6.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f6.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x - 3f, transform.position.y - 3f, 1);
                Destroy(f6, 1f);

                GameObject f7 = Instantiate(bossfireball);
                f7.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f7.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x + 1f, transform.position.y - 1f, 1);
                Destroy(f7, 1f);

                GameObject f8 = Instantiate(bossfireball);
                f8.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f8.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x + 2f, transform.position.y - 2f, 1);
                Destroy(f8, 1f);

                GameObject f9 = Instantiate(bossfireball);
                f9.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f9.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x + 3f, transform.position.y - 3f, 1);
                Destroy(f9, 1f);

                GameObject f10 = Instantiate(bossfireball);
                f10.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f10.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x - 1f, transform.position.y - 1f, 1);
                Destroy(f10, 1f);

                GameObject f11 = Instantiate(bossfireball);
                f11.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f11.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x - 2f, transform.position.y - 2f, 1);
                Destroy(f11, 1f);

                GameObject f12 = Instantiate(bossfireball);
                f12.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                f12.GetComponent<bossfireball>().SetVelocity(100, transform.position.x, transform.position.y, transform.position.x - 3f, transform.position.y - 3f, 1);
                Destroy(f12, 1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
