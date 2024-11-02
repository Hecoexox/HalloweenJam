using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sugar")||other.CompareTag("Water") || other.CompareTag("Karamel") || other.CompareTag("CornSyrup") || other.CompareTag("Chocolate") || other.CompareTag("Gelatin") || other.CompareTag("Junk"))
        {
            Destroy(other.gameObject);
        }
   
    }
}
