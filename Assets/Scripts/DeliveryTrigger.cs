using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryTrigger : MonoBehaviour
{
    public OrderManager orderManager; // OrderManager referans�

    private void OnTriggerEnter(Collider other)
    {
        // E�er obje do�ru tag'e sahipse teslimat� kontrol et
        if (other.CompareTag("KaramelCandy") || other.CompareTag("ChocolatteCandy") || other.CompareTag("Gummy") || other.CompareTag("Lollipop"))
        {
            // OrderManager ile teslimat i�lemi
            orderManager.DeliverOrder(other.tag);

            // Objeyi yok et
            Destroy(other.gameObject);
        }
    }
}

