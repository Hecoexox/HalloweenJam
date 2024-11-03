using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{
    
    public bool isWater = false;
    public bool isSugar = false;
    public bool isMeltedKaramel = false;
    public bool isMeltedChocolatte = false;

    public bool isReady = false;
    public bool isJunk = false;

    public bool isSyrup = false;
    public bool isCaramel = false;
    public bool isChocolatte = false;

    public GameObject Syrup;
    public GameObject Caramel;
    public GameObject Chocolatte;
 
    public PickUpItemRaycast pickUpItemRaycast;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MeltedKaramel"))
        {
            isMeltedKaramel = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Water"))
        {
            isWater = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Sugar"))
        {
            isSugar = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("MeltedChocolatte"))
        {
            isMeltedChocolatte = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Syrup"))
        {
            isSyrup=true;
            Destroy(other.gameObject);
        }
        
    }

    void Update()
    {
      //Þerbet
        if(isWater && isSugar) 
        {
            isSyrup = true;
            GameObject SyrupInstance = Instantiate(Syrup, transform.position + Vector3.up * 3, transform.rotation);
            SyrupInstance.tag = "Syrup";
            isSyrup = false;
            isWater = false;
            isSugar=false;
        }
       //Karamel Özü
       if(isMeltedKaramel && isSyrup) 
        {
            isCaramel=true;
            GameObject CaramelInstance = Instantiate(Caramel, transform.position + Vector3.up * 3, transform.rotation);
            CaramelInstance.tag = "Karamel";
            isCaramel = false;
            isMeltedKaramel = false;
            isSyrup =false;
        }
       //Çikolata Özü
       if (isMeltedChocolatte && isSyrup)
        {
            isChocolatte=true;
            GameObject ChocolatteInstance = Instantiate(Chocolatte, transform.position + Vector3.up * 3, transform.rotation);
            ChocolatteInstance.tag = "Chocolatte";
            isChocolatte = false;
            isMeltedChocolatte=false;
            isSyrup=false;
        }
    }
}
