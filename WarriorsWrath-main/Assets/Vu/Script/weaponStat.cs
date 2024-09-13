using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponStat : MonoBehaviour
{
    // yeu to combat
    [SerializeField] public int type;
    //1 kiem
    //2 phep
    [SerializeField] public float dmg = 5;
    [SerializeField] public float delay = 1f;
    [SerializeField] public PolygonCollider2D collider;
    [SerializeField] private float totalDmg;
    private float charDmg;
    [SerializeField] private GameObject bullet1;
    [SerializeField] private GameObject bullet2;
    [SerializeField] private Transform firePos;
    [SerializeField] private float bulletSpeed;

    // yeu to hinh anh
    private Animator anim;
    private bool isRight;
    private Material material;
    private float currentMATIntensity;

    // yeu to logic
    public bool isAttacking;
    private bool canAttack;
    private bool isHoldDown;
    private float holdDownTime;
    private bool isEquipped;
    private void Start()
    {
        anim = GetComponent<Animator>();
        material= GetComponent<SpriteRenderer>().material;

        collider = GetComponent<PolygonCollider2D>();
        

        totalDmg = charDmg + dmg;
        canAttack = true;
        collider.enabled = false;

        // setup chi so dan khi la type 2
        if(type == 2)
        {
            bullet1.gameObject.GetComponent<bulletHit>().setBulletDmg(totalDmg);
            bullet1.gameObject.GetComponent<bulletHit>().setBulletForce(bulletSpeed);
            bullet2.gameObject.GetComponent<bulletHit>().setBulletDmg(totalDmg+5f);
            bullet2.gameObject.GetComponent<bulletHit>().setBulletForce(bulletSpeed+5f);
            anim.SetBool("isRight", true);
        }
        
    }

    private void Update()
    {
        isEquipped = this.gameObject.transform.parent.gameObject.GetComponent<weaponHolder>().getIsEquipped();
        if(!isEquipped)
        {
            return;
        }
        charDmg = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<playerStat>().playerDmg;

        // huong chuot
        isRight = this.gameObject.transform.parent.gameObject.GetComponent<weaponHolder>().isRight;

        //chinh animation phu hop huong
        if(isRight && type == 2)
        {
            anim.SetBool("isRight", true);
        }
        else if (!isRight && type == 2)
        {
            anim.SetBool("isRight", false);
        }
        
        material.SetFloat("_Intensity", Mathf.Round(currentMATIntensity * 10.0f) * 0.1f);
        if (Input.GetMouseButtonDown(0))
        {
            isHoldDown = true;
            //tan cong bang kiem
            if (type== 1)
            {
                //kiem
                Attack1();
            }
            // sac dang phep
            if(type== 2)
            {
                StartCoroutine(Charge());
            }
            
        }
        else if( Input.GetMouseButtonUp(0) && type == 2)
        {
            //goi lenh tan cong dang phep, tro ve trang thai dau
            isHoldDown = false;
            currentMATIntensity = 0f;
            Attack2();
        }

        // tinh thoi gian de chuot
        if (isHoldDown)
        {
            holdDownTime += Time.deltaTime;
        }
    }

    //kiem
    public void Attack1()
    {
        if (isAttacking == true || canAttack == false)
        {
            return;
        }
        if (isRight == true)
        {
            anim.SetTrigger("Atk");
        }
        else
        {
            anim.SetTrigger("Atk2");
        }
        canAttack= false;
        
    }

    //truong
    public void Attack2()
    {
        if (isAttacking == true || canAttack == false)
        {
            return;
        }
        if (isRight == true)
        {
            anim.SetTrigger("Atk");
        }
        else
        {
            anim.SetTrigger("Atk2");
        }
        canAttack = false;

    }

    // bat dau tan cong, goi trong Animation
    public void StartAtk()
    {
        isAttacking = true;
        collider.enabled = true;
    }
    // ket thuc tan cong, goi trong Animation
    public void FinishAtk()
    {
        isAttacking = false;
        collider.enabled = false;
        Invoke("AttackCountdown", delay);
        material.SetFloat("_Intensity", 0.5f);
        StartCoroutine(ChangeEngineColour());

        //ban dan khi dang 2
        if(type == 2)
        {
            if(holdDownTime > 1f)
            {
                Debug.Log("big one");
                Instantiate(bullet2, firePos.position, Quaternion.identity);
            }
            else if(holdDownTime > 0f)
            {
                Instantiate(bullet1, firePos.position, Quaternion.identity);
            }
            holdDownTime = 0f;
        }
    }

    // tu fillter > ko fillter
    private IEnumerator ChangeEngineColour()
    {
        float time = 0f;
        while (time < delay)
        {
            time += Time.deltaTime;
            currentMATIntensity = Mathf.Lerp(0.5f, 0f, (time / delay));
            yield return null;
        }
    }
    // tu ko fillter > fillter
    private IEnumerator Charge()
    {
        float time = 0f;
        while (time < delay)
        {
            time += Time.deltaTime;
            currentMATIntensity = Mathf.Lerp(0f, 0.5f, (time / 1f));
            yield return null;
        }
    }
    // co the tan cong lai
    private void AttackCountdown()
    {
        canAttack = true;
    }
    // lay trang thai dang tan cong
    public bool GetIsAttacking()
    {
        return isAttacking;
    }
    // kiem tra va cham khi type 1
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //va cham vu khi khi dang tan cong - khi la kiem
        if(!isEquipped)
        {
            return;
        }
        if (isAttacking == true && type == 1)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<enemyStat>().enemyTakeDmg(totalDmg);
            }
            else if (collision.gameObject.tag == "Boss")
            {
                collision.gameObject.GetComponent<bossStat>().takeDMG(totalDmg);
            }
        }
    }

}
