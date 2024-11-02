using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OrderManager : MonoBehaviour
{
    // Sipari�leri temsil eden liste
    private List<string> orders = new List<string> { "KaramelCandy", "Gummy", "ChocolatteCandy", "Lollipop" };

    // �u anki sipari�i tutmak i�in de�i�ken
    private string currentOrder;

    // TextMeshPro bile�eni (sipari�leri g�stermek i�in)
    public TextMeshProUGUI orderText;

    private void Start()
    {
        // �lk sipari�i rastgele se� ve g�ster
        SelectRandomOrder();
    }

    // Rastgele bir sipari� se�ip ekrana yazd�rma
    private void SelectRandomOrder()
    {
        if (orders.Count > 0)
        {
            int randomIndex = Random.Range(0, orders.Count);
            currentOrder = orders[randomIndex];
            orderText.text = "Sipari�: " + currentOrder;
        }
        else
        {
            orderText.text = "T�m sipari�ler tamamland�!";
        }
    }

    // Sipari�i teslim etme fonksiyonu
    public void DeliverOrder(string deliveredItem)
    {
        if (deliveredItem == currentOrder) // Do�rudan currentOrder ile kar��la�t�r
        {
            Debug.Log("Teslim edildi: " + deliveredItem);
            orders.Remove(currentOrder); // Teslim edilen sipari�i listeden ��kar
            SelectRandomOrder(); // Yeni bir sipari� se�
        }
        else
        {
            Debug.Log("Yanl�� �r�n teslim edildi: " + deliveredItem);
        }
    }
}
