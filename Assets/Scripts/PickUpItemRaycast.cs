using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject SugarLolipop;
    public GameObject SugarChocolatte;
    public GameObject SugarJelibon;
    string[] validTags = { "MeltedKaramel", "MeltedChocolatte", "Water", "Sugar", "Syrup","Decorative", "Karamel", "Chocolatte", "Cornsyrup", "Gelatin", "Junk", "Lollipop", "Gummy", "Karamel Candy", "Chocolatte Candy", "LollipopCandy", "GummyCandy", };
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
                if (validTags.Contains(hit.collider.tag))
                {
                    pickUpText.SetActive(true); // Yaz�y� g�ster

                    // E tu�una bas�ld���nda itemi al
                    if (Input.GetMouseButton(0))
                    {
                        heldItem = hit.collider.gameObject; // Oyuncunun elindeki nesneyi ayarla
                        heldItem.GetComponent<Collider>().enabled = false;
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
                heldItem.GetComponent<Collider>().enabled = true;
                heldItem.transform.SetParent(null); // Nesnenin ebeveynini kald�r
                heldItem = null; // Elindeki nesneyi bo�alt
                
            }
        } 
   /* //CRAFTER
        if (crafter.isReadyLolipop == true)
        {
            RaycastHit hit0;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit0, pickUpDistance))
            {
                if (hit0.collider.CompareTag("Crafter"))
                {
                   if(Input.GetKeyDown(KeyCode.E)){
                        Instantiate(SugarLolipop);
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
        else if (crafter.isReadyJelibon == true)
        {
            RaycastHit hit0;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit0, pickUpDistance))
            {
                if (hit0.collider.CompareTag("Crafter"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Instantiate(SugarJelibon);
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
        else if (crafter.isReadyKaramel == true)
        {
            RaycastHit hit0;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit0, pickUpDistance))
            {
                if (hit0.collider.CompareTag("Crafter"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
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
        else if (crafter.isReadyChocolatte== true)
        {
            RaycastHit hit0;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit0, pickUpDistance))
            {
                if (hit0.collider.CompareTag("Crafter"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Instantiate(SugarChocolatte);
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
        }*/




    }
}
