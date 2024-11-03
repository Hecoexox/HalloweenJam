using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour
{
    public bool isKaramel = false;
    public bool isChocolatte = false;
    public bool isSyrup = false;
    public bool isCornsyrup = false;
    public bool isGelatin = false;

    public bool isReady = false;
    public bool isJunk = false;

    public bool isMeltedChocolatte = false;
    public bool isMeltedKaramel = false;
    public bool isLollipop = false;
    public bool isGummy = false;


    public GameObject MeltedChocolatte;
    public GameObject MeltedKaramel;
    public GameObject Lollipop;
    public GameObject Gummy;

    public PickUpItemRaycast pickUpItemRaycast;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Karamel"))
        {
            isKaramel = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Chocolatte"))
        {
            isChocolatte = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Syrup"))
        {
            isSyrup = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Cornsyrup"))
        {
            isCornsyrup = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Gelatin"))
        {
            isGelatin = true;
            Destroy(other.gameObject);
        }
        else
        {
            isJunk = true;
        }
    }

    void Update()
    {
        // lolipop özü
        if (isSyrup && isCornsyrup)
        {
            isLollipop = true;
            GameObject lollipopInstance = Instantiate(Lollipop, transform.position + Vector3.up*3 + Vector3.right*5/4, transform.rotation);
            lollipopInstance.tag = "LollipopCandy";
            isLollipop = false;
            isSyrup=false;
            isCornsyrup=false;
        }
        // jelibon özü
        if (isSyrup && isGelatin)
        {
            isGummy = true;
            GameObject gummyInstance = Instantiate(Gummy, transform.position + Vector3.up*3, transform.rotation);
            gummyInstance.tag = "Gummy";
            isGummy = false;
            isSyrup = false;
            isGelatin = false;
        }
        // erimiþ çikolata
        if (isChocolatte)
        {
            isMeltedChocolatte = true;
            GameObject meltedChocolatteInstance = Instantiate(MeltedChocolatte, transform.position + Vector3.up * 3, transform.rotation);
            meltedChocolatteInstance.tag = MeltedChocolatte.name;
            isMeltedChocolatte = false;
            isChocolatte = false;
           
        }
        // erimiþ karamel
        if (isKaramel)
        {
            isMeltedKaramel = true;
            GameObject meltedKaramelInstance = Instantiate(MeltedKaramel, transform.position + Vector3.up * 3, transform.rotation);
            meltedKaramelInstance.tag = MeltedKaramel.name;
            isMeltedKaramel = false;
            isKaramel = false;
        }
    }
}
