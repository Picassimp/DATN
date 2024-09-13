using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopWea : MonoBehaviour
{

    public GameObject[] weaponPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        SpawnVuKhi();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnVuKhi()
    {
        if (weaponPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, weaponPrefabs.Length);
            GameObject randomWeaponPrefab = weaponPrefabs[randomIndex];
            Instantiate(randomWeaponPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            //Debug.LogError("K");
        }
    }
}
