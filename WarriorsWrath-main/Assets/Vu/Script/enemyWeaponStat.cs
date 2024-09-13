using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeaponStat : MonoBehaviour
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
    [SerializeField] private Transform[] firePos;
    [SerializeField] private float bulletSpeed;

    // yeu to hinh anh
    private Animator anim;
    private bool isRight;
    private Material material;
    private float currentMATIntensity;

    // yeu to logic
    public bool isAttacking;
    private bool canAttack;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        material = GetComponent<SpriteRenderer>().material;

        collider = GetComponent<PolygonCollider2D>();
        collider.enabled = false;
        canAttack = true;

        if (type == 2)
        {
            bullet1.gameObject.GetComponent<enemyBulletHit>().setBulletDmg(dmg);
            bullet1.gameObject.GetComponent<enemyBulletHit>().setBulletForce(bulletSpeed);
            anim.SetBool("isRight", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = transform.parent.gameObject.transform.parent.gameObject.GetComponent<FollowPlayer>().getIsAttacking();
        isRight = transform.parent.gameObject.GetComponent<enemyWeaponHolder>().GetIsRight();
        //chinh animation phu hop huong
        if (isRight && type == 2)
        {
            anim.SetBool("isRight", true);
        }
        else if (!isRight && type == 2)
        {
            anim.SetBool("isRight", false);
        }

        material.SetFloat("_Intensity", Mathf.Round(currentMATIntensity * 10.0f) * 0.1f);

        if (isAttacking && canAttack)
        {
            //tan cong bang kiem
            if (type == 1)
            {
                //kiem
                Invoke("Attack1", 0.5f);
            }
            // sac dang phep
            if (type == 2)
            {
                Invoke("Attack2", 0.5f);
            }

        }
    }

    //kiem
    public void Attack1()
    {
        if (!canAttack)
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

    //truong
    public void Attack2()
    {
        if (!canAttack)
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
        collider.enabled = false;
        Invoke("AttackCountdown", delay);
        material.SetFloat("_Intensity", 0.5f);
        StartCoroutine(ChangeEngineColour());

        //ban dan khi dang 2
        if (type == 2)
        {
            foreach(Transform p in firePos)
            {
                var bullet = Instantiate(bullet1, p.position, Quaternion.identity);
                //var script = bullet.GetComponent<enemyBulletHit>();
                //Debug.Log(p.transform.rotation.z);
                //script.setbulletR(p.transform.rotation.z*100);
            }
           
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
        transform.parent.gameObject.transform.parent.gameObject.GetComponent<FollowPlayer>().SetAttacking();
        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //va cham vu khi khi dang tan cong - khi la kiem
        
        if (type == 1)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<playerStat>().playerTakeDmg(dmg);
            }
        }
    }
}
