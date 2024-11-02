using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OrderManager : MonoBehaviour
{
    // Sipariþleri temsil eden liste
    private List<string> orders = new List<string> { "KaramelCandy", "Gummy", "ChocolatteCandy", "Lollipop" };

    // Þu anki sipariþi tutmak için deðiþken
    private string currentOrder;

    // TextMeshPro bileþeni (sipariþleri göstermek için)
    public TextMeshProUGUI orderText;

    private void Start()
    {
        // Ýlk sipariþi rastgele seç ve göster
        SelectRandomOrder();
    }

    // Rastgele bir sipariþ seçip ekrana yazdýrma
    private void SelectRandomOrder()
    {
        if (orders.Count > 0)
        {
            int randomIndex = Random.Range(0, orders.Count);
            currentOrder = orders[randomIndex];
            orderText.text = "Sipariþ: " + currentOrder;
        }
        else
        {
            orderText.text = "Tüm sipariþler tamamlandý!";
        }
    }

    // Sipariþi teslim etme fonksiyonu
    public void DeliverOrder(string deliveredItem)
    {
        if (deliveredItem == currentOrder) // Doðrudan currentOrder ile karþýlaþtýr
        {
            Debug.Log("Teslim edildi: " + deliveredItem);
            orders.Remove(currentOrder); // Teslim edilen sipariþi listeden çýkar
            SelectRandomOrder(); // Yeni bir sipariþ seç
        }
        else
        {
            Debug.Log("Yanlýþ ürün teslim edildi: " + deliveredItem);
        }
    }
}
