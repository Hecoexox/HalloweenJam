using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
        // Eðer oyuncunun elinde bir nesne yoksa ray ile etkileþimi kontrol et
        if (heldItem == null)
        {
            RaycastHit hit;

            // Kamera merkezinden ileriye doðru ray gönder
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickUpDistance))
            {
                // Ray bir "Item" ile temas ediyor mu kontrol et
                if (validTags.Contains(hit.collider.tag))
                {
                    pickUpText.SetActive(true); // Yazýyý göster

                    // E tuþuna basýldýðýnda itemi al
                    if (Input.GetMouseButton(0))
                    {
                        heldItem = hit.collider.gameObject; // Oyuncunun elindeki nesneyi ayarla
                        heldItem.GetComponent<Collider>().enabled = false;
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
                heldItem.GetComponent<Collider>().enabled = true;
                heldItem.transform.SetParent(null); // Nesnenin ebeveynini kaldýr
                heldItem = null; // Elindeki nesneyi boþalt
                
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
