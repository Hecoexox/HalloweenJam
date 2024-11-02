using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpItemRaycast : MonoBehaviour
{
    public GameObject pickUpText; // Ekranda göstereceðimiz "al" yazýsý
    public Transform playerHand; // Nesnenin tutulacaðý oyuncu elinin pozisyonu
    public float pickUpDistance = 2.0f; // Nesneyle etkileþime geçebileceði maksimum mesafe
    public float offsetDistance = 0.5f; // Nesnenin oyuncu elinin önünde duracaðý mesafe
    public Vector3 offsetRotation = new Vector3(0, 45, 0);
    private GameObject heldItem = null; // Oyuncunun elindeki nesneyi takip etmek için

    void Start()
    {
        pickUpText.SetActive(false);
    }
  
    void Update()
    {
        // Eðer oyuncunun elinde bir nesne yoksa ray ile etkileþimi kontrol et
        if (heldItem == null)
        {
            RaycastHit hit;

            // Kamera merkezinden ileriye doðru ray gönder
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickUpDistance))
            {
                // Ray bir "Item" ile temas ediyor mu kontrol et
                if (hit.collider.CompareTag("Item"))
                {
                    pickUpText.SetActive(true); // Yazýyý göster

                    // E tuþuna basýldýðýnda itemi al
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        heldItem = hit.collider.gameObject; // Oyuncunun elindeki nesneyi ayarla
                        heldItem.transform.SetParent(null); // Nesneyi baðýmsýz hale getir
                        pickUpText.SetActive(false); // Yazýyý gizle
                    }
                }
                else
                {
                    pickUpText.SetActive(false); // Farklý bir nesneye bakýyorsa yazýyý gizle
                }
            }
            else
            {
                pickUpText.SetActive(false); // Herhangi bir nesneye bakmýyorsa yazýyý gizle
            }
        }
        else
        {
            // Nesnenin oyuncunun elinin önünde durmasý için konum ve rotasyon ayarý
            heldItem.transform.position = playerHand.position + playerHand.forward * offsetDistance;
            heldItem.transform.rotation = playerHand.rotation * Quaternion.Euler(offsetRotation); ;

            // E tuþuna basýldýðýnda nesneyi býrak
            if (Input.GetKeyDown(KeyCode.E))
            {
                heldItem.transform.SetParent(null); // Nesnenin ebeveynini kaldýr
                heldItem = null; // Elindeki nesneyi boþalt
            }
        }
    }
}
