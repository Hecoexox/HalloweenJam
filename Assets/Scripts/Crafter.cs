using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{
    public bool isKaramel = false;
    public bool isWater = false;
    public bool isSugar = false;
    public bool isChocolatte= false;
    public bool isGelatin = false;
    public bool isCornsyrup = false;
    public bool isReady = false;
    public GameObject objectsugar01;
    public PickUpItemRaycast pickUpItemRaycast;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Karamel"))
        {
            isKaramel = true;
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
        else if (other.CompareTag("Chocolatte"))
        {
            isChocolatte = false;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Gelatin"))
        {
            isGelatin = false;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Cornsyrup"))
        {
            isCornsyrup = false;
            Destroy(other.gameObject);
        }
    }


    void Update()
    {
        //Karamelli
        if(isWater && isSugar && isKaramel ) 
        {
            isReady = true;
        }
    }
}
