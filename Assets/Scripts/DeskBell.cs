using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskBell : MonoBehaviour
{
    public GhostComing ghostComingScript; // Reference to the GhostComing script

    void OnMouseDown()
    {
        // Check if the customer boolean is false before ringing the bell
        if (!ghostComingScript.customer)
        {
            // Trigger the door and ghost sequence
            ghostComingScript.RingBell();
        }
        else
        {
            Debug.Log("The bell has already been clicked. Wait for the sequence to finish.");
        }
    }
}
