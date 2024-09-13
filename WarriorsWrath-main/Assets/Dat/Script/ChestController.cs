using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Animator chestAnimator;
    public GameObject weaponPrefab; // Đối tượng vũ khí để xuất hiện

    private bool isOpened = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpened)
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        // Kích hoạt animation mở rương
        chestAnimator.SetTrigger("Open");

        // Xuất hiện vũ khí (hoặc thực hiện hành động khác)
        SpawnWeapon();

        // Đánh dấu rương đã mở
        isOpened = true;

        // Tùy chỉnh logic xóa rương nếu cần
        // Đối với ví dụ đơn giản này, chúng ta có thể tắt renderer và collider của rương
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void SpawnWeapon()
    {
        // Xuất hiện vũ khí (ví dụ: instantiate vũ khíPrefab)
        Instantiate(weaponPrefab, transform.position, Quaternion.identity);
    }
}
