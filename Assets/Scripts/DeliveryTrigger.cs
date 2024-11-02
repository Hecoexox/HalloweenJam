using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryTrigger : MonoBehaviour
{
    public OrderManager orderManager; // OrderManager referansý

    private void OnTriggerEnter(Collider other)
    {
        // Eðer obje doðru tag'e sahipse teslimatý kontrol et
        if (other.CompareTag("KaramelCandy") || other.CompareTag("ChocolatteCandy") || other.CompareTag("Gummy") || other.CompareTag("Lollipop"))
        {
            // OrderManager ile teslimat iþlemi
            orderManager.DeliverOrder(other.tag);

            // Objeyi yok et
            Destroy(other.gameObject);
        }
    }
}

