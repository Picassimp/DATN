using UnityEngine;
using UnityEngine.UI;

public class Chestt : MonoBehaviour
{
    public GameObject[] weaponPrefabs; // Kéo thả Prefab vũ khí vào trường này trong Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Tạo vũ khí khi nhân vật chạm vào rương
            SpawnVuKhi();
            // Tùy chọn: Xóa rương sau khi chạm vào
            Destroy(gameObject);
        }
    }

    private void SpawnVuKhi()
    {
        if (weaponPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, weaponPrefabs.Length);
            GameObject randomWeaponPrefab = weaponPrefabs[randomIndex]; // Chọn một Prefab từ mảng
            var spawnedWea = Instantiate(randomWeaponPrefab, transform.position, Quaternion.identity);
            spawnedWea.GetComponent<weaponHolder>().weaponAsReward();
        }
        else
        {
            Debug.LogError("Không có Prefab vũ khí được thiết lập!");
        }
    }
}
