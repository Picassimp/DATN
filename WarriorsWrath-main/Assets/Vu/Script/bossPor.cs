using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossPor : MonoBehaviour
{
    private Animator anim;
    private Material material;
    private float currentMATIntensity;

    private bool inside;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        material = GetComponent<SpriteRenderer>().material;
        inside = false;
        anim.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_Intensity", Mathf.Round(currentMATIntensity * 10.0f) * 0.1f);
        if(currentMATIntensity >= 0.5f)
        {
            GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().stage = 2;
            SceneManager.LoadScene("Boss1");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            inside = true;
            anim.enabled = true;
            StartCoroutine(Charge());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inside = false;
            anim.enabled = false;
            currentMATIntensity = 0f;
        }
    }

    private IEnumerator Charge()
    {
        float time = 0f;
        while (time < 3f)
        {
            if(inside) { 
            time += Time.deltaTime;
            currentMATIntensity = Mathf.Lerp(0f, 0.5f, (time / 3f));
            yield return null;
            }
            else
            {
                yield return null;
            }
        }
    }
}
