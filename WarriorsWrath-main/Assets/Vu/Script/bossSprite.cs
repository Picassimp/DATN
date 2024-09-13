using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSprite : MonoBehaviour
{
    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    public void doneResting()
    {
        boss.GetComponent<bossMoveSet>().callDoneResting();
    }

    public void doneLazer()
    {   
        GetComponent<bossLazerHit>().doDamage();
        Invoke("doneResting", 3f);
        Destroy(transform.parent.gameObject, 3f);
        
    }

    public void spawnBullet()
    {
        boss.GetComponent<bossMoveSet>().spawnBullet();
    }

    public void WakeUp()
    {
        boss.GetComponent<bossMoveSet>().callDoneWakeUp();
    }

    public void ActiveMelee()
    {
        boss.GetComponent<bossMoveSet>().ActiveMeleePos();

    }

    public void DisableMelee()
    {
        boss.GetComponent<bossMoveSet>().DisableMeleePos();

    }
}
