/*using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Weapon
{
    public string name;
    public GameObject weaponPrefab;
    public int price;
}

public class PurchaseController : MonoBehaviour
{


    //public Text priceText;
    public Button buyButton;
    public GameObject purchasePanel;
    public NPC npcController;
    public Weapon[] weapons;

    private Weapon currentWeapon;

    public void PreparePurchase()
    {
        // Chọn một vũ khí ngẫu nhiên từ danh sách
        currentWeapon = npcController.weapons[Random.Range(0, weapons.Length)];

        // Hiển thị giá cả và thông tin của vũ khí
        *//*priceText.text = "Price: $" + currentWeapon.price.ToString();
        priceText2.text = "Price: $" + currentWeapon.price.ToString();
        priceText3.text = "Price: $" + currentWeapon.price.ToString();
        priceText4.text = "Price: $" + currentWeapon.price.ToString();*/
        /*for (int i = 0; i < 4; i++)
        {
            priceText.text = "Price: $" + currentWeapon.price.ToString();
            Weapon selectedWeapon = weapons[Random.Range(0, weapons.Length)];
           
        }*//*

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(BuyItem);


    }

    private void BuyItem()
    {
        // Trừ số tiền của người chơi (thêm logic tương ứng với game của bạn)

        // Xuất hiện vũ khí đã chọn
        npcController.weaponManager.SpawnWeapon(currentWeapon.weaponPrefab); 
        
        
        // Tắt Panel Mua Hàng
        purchasePanel.SetActive(false);
    }
}*/
