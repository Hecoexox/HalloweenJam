using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpItemRaycast : MonoBehaviour
{
    public GameObject pickUpText; // Ekranda g�sterece�imiz "al" yaz�s�
    public Transform playerHand; // Nesnenin tutulaca�� oyuncu elinin pozisyonu
    public float pickUpDistance = 2.0f; // Nesneyle etkile�ime ge�ebilece�i maksimum mesafe
    public float offsetDistance = 0.5f; // Nesnenin oyuncu elinin �n�nde duraca�� mesafe
    public Vector3 offsetRotation = new Vector3(0, 45, 0);
    private GameObject heldItem = null; // Oyuncunun elindeki nesneyi takip etmek i�in
    public Crafter crafter;
    public GameObject SugarKaramel;
 
    void Start()
    {
        pickUpText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    void Update()
    {
        // E�er oyuncunun elinde bir nesne yoksa ray ile etkile�imi kontrol et
        if (heldItem == null)
        {
            RaycastHit hit;

            // Kamera merkezinden ileriye do�ru ray g�nder
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickUpDistance))
            {
                // Ray bir "Item" ile temas ediyor mu kontrol et
                if (hit.collider.CompareTag("Karamel") || hit.collider.CompareTag("Water") || hit.collider.CompareTag("Sugar"))
                {
                    pickUpText.SetActive(true); // Yaz�y� g�ster

                    // E tu�una bas�ld���nda itemi al
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        heldItem = hit.collider.gameObject; // Oyuncunun elindeki nesneyi ayarla
                        heldItem.transform.SetParent(null); // Nesneyi ba��ms�z hale getir
                        pickUpText.SetActive(false); // Yaz�y� gizle
                    }
                }
                else
                {
                    pickUpText.SetActive(false); // Farkl� bir nesneye bak�yorsa yaz�y� gizle
                }
            }
            else
            {
                pickUpText.SetActive(false); // Herhangi bir nesneye bakm�yorsa yaz�y� gizle
            }
        }
        else
        {
            // Nesnenin oyuncunun elinin �n�nde durmas� i�in konum ve rotasyon ayar�
            heldItem.transform.position = playerHand.position + playerHand.forward * offsetDistance;
            heldItem.transform.rotation = playerHand.rotation * Quaternion.Euler(offsetRotation); ;

            // E tu�una bas�ld���nda nesneyi b�rak
            if (Input.GetKeyDown(KeyCode.E))
            {
                heldItem.transform.SetParent(null); // Nesnenin ebeveynini kald�r
                heldItem = null; // Elindeki nesneyi bo�alt
            }
        } 
    
        if (crafter.isReady == true)
        {
            RaycastHit hit0;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit0, pickUpDistance))
            {
                if (hit0.collider.CompareTag("Crafter"))
                {
                   if(Input.GetKeyDown(KeyCode.E)){
                        Instantiate(SugarKaramel);
                        crafter.isKaramel = false;
                        crafter.isCornsyrup = false;
                        crafter.isSugar = false;
                        crafter.isWater = false;
                        crafter.isChocolatte = false;
                        crafter.isGelatin = false;
                        crafter.isReady = false;
                    }
                    
                }
            }
        }
        



    }
}
