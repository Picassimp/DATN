using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMoveSet : MonoBehaviour
{
    private bool isResting;
    [SerializeField] private GameObject bossSprite;
    [SerializeField] private GameObject lazerSprite;
    [SerializeField] private GameObject lazer;

    [SerializeField] private GameObject shootPos;
    [SerializeField] private GameObject bullet;

    [SerializeField] private GameObject meleePos;
    private Animator anim;

    private bool isMeleeing;
    private float pre = -1;
    private bool isWakeUp;
    private bool isRage;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        isWakeUp = false;
        isResting = false;
        isMeleeing = false;
        isRage = false;
        material = bossSprite.GetComponent<SpriteRenderer>().material;
        anim = bossSprite.GetComponent<Animator>();
        Invoke("Delay", 0.1f);

    }

    private void Delay()
    {
        GetComponent<bossFollow>().stopChasing();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWakeUp == false) return;
        if(isResting == false)
        {
            float randomNumber = Random.Range(0, 3);
            if(pre != randomNumber)
            {
                pre = randomNumber;
            }
            else
            {
                return;
            }
            switch(randomNumber)
            {
                case 0:
                    {
                        startLazer();
                        break;
                    }
                case 1:
                    {
                        startMelee();
                        break;
                    }
                case 2:
                    {
                        startShoot();
                        break;
                    }
                default:
                    {
                        Debug.Log("beep");
                        break;
                    }
            }
        }

        float distance = GetComponent<bossFollow>().getDistance();
        if(isMeleeing == true && distance <= 2.1f) {
            startMeleeAnim();
        }
        else if (isMeleeing == true && distance > 2.1f)
        {
            Invoke("startMeleeAnim", 1.5f);
        }
    }

    private void startLazer()
    {
        transform.position = Vector3.zero;
        isResting= true;
        Invoke("startLazerAnim", 1f);
    }

    private void startLazerAnim()
    {
        var myNewLaz =  Instantiate(lazer, lazerSprite.transform.position, Quaternion.identity);
        myNewLaz.transform.parent = lazerSprite.transform;
        myNewLaz.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (isRage)
        {
            var myNewLaz2 = Instantiate(lazer, lazerSprite.transform.position, Quaternion.identity);
            myNewLaz2.transform.parent = lazerSprite.transform;
            myNewLaz2.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            var myNewLaz3 = Instantiate(lazer, lazerSprite.transform.position, Quaternion.identity);
            myNewLaz3.transform.parent = lazerSprite.transform;
            myNewLaz3.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            var myNewLaz4 = Instantiate(lazer, lazerSprite.transform.position, Quaternion.identity);
            myNewLaz4.transform.parent = lazerSprite.transform;
            myNewLaz4.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
        }

        anim.SetBool("Lazer", true);
        lazerSprite.GetComponent<bossLazerDir>().startLazer();
    }

    private void startShoot()
    {
        isResting = true;
        anim.SetBool("Shoot", true);
        
    }

    public void spawnBullet()
    {
        for (int fireangle = -30; fireangle <= 30; fireangle += 30)

        {
            bool isRight = GetComponent<bossFollow>().Right();
            var newBullet = Instantiate(bullet);

            newBullet.transform.position = shootPos.transform.position;

            newBullet.GetComponent<bossBullet>().setIsRight(isRight);     
            float dmg = GetComponent<bossStat>().GetDMG();       
            newBullet.GetComponent<bossBullet>().setDMG(dmg);
            if(isRage){
                newBullet.GetComponent<bossBullet>().setDMG(dmg + 5f);
            }


            newBullet.transform.eulerAngles = new Vector3(0, 0, fireangle);

        }
    }

    private void startMelee()
    {
        GetComponent<bossFollow>().startChasing();
        
        isMeleeing = true;
        isResting = true;
        
    }

    private void startMeleeAnim()
    {
        if (isMeleeing)
        {
            anim.SetBool("Melee", true);

            GetComponent<bossFollow>().stopChasing();
        }
        

    }


    private void doneResting()
    {
        isResting = false;
    }

    public void callDoneResting()
    {
        GetComponent<bossFollow>().stopChasing();
        isMeleeing = false;
        lazerSprite.GetComponent<bossLazerDir>().changeCheck();
        anim.SetBool("Lazer", false);
        anim.SetBool("Shoot", false);
        anim.SetBool("Melee", false);
        Invoke("doneResting", 3f);
    }

    public void callDoneWakeUp()
    {
        isWakeUp = true;
    }

    public void ActiveMeleePos()
    {
        if (isRage)
        {
            meleePos.transform.localScale = new Vector3(2f, 2f, 0f);
        }
        meleePos.SetActive(true);
    }

    public void DisableMeleePos()
    {
        meleePos.SetActive(false);
    }

    public void Rage()
    {
        isRage = true;
        material.SetFloat("_Intensity", 0.2f);
    }
}
