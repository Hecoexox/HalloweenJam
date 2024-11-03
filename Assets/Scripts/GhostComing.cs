using UnityEngine;
using System.Collections;


public class GhostComing : MonoBehaviour
{
    public GameObject Door;
    public GameObject Ghost;
    public GameObject DeskBell;
    public GameObject SpecialObject; // The special object to activate when ghost reaches its position
    public float openSpeed = 1.0f; // Speed of door opening
    public float ghostSpeed = 1.0f; // Speed of ghost movement

    public bool customer = false; // Boolean to track if the bell has been clicked

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpening = false;
    private bool doorOpened = false;

    private Vector3 ghostStartPosition = new Vector3(-48.5f, 42.5f, -12.5f);
    private Vector3 ghostEndPosition = new Vector3(-48.5f, 42.5f, -6.75f);

    void Start()
    {
        // Initialize door rotation
        closedRotation = Door.transform.rotation;
        openRotation = Quaternion.Euler(0, 135, 0) * closedRotation;

        // Set the ghost's initial position
        Ghost.transform.position = ghostStartPosition;

        // Ensure the special object is initially inactive
        if (SpecialObject != null)
        {
            SpecialObject.SetActive(false);
        }
    }

    void Update()
    {
        // Handle door opening
        if (isOpening && !doorOpened)
        {
            Door.transform.rotation = Quaternion.Lerp(Door.transform.rotation, openRotation, Time.deltaTime * openSpeed);

            if (Quaternion.Angle(Door.transform.rotation, openRotation) < 0.1f)
            {
                Door.transform.rotation = openRotation;
                isOpening = false;
                doorOpened = true;
                StartCoroutine(MoveGhost()); // Start moving the ghost
            }
        }
    }

    // Method to be called when the desk bell is clicked
    public void RingBell()
    {
        Debug.Log("Desk bell clicked! Starting sequence...");
        customer = true; // Set customer to true when the bell is clicked
        isOpening = true;
    }

    IEnumerator MoveGhost()
    {
        // Move the ghost towards the end position
        while (Vector3.Distance(Ghost.transform.position, ghostEndPosition) > 0.1f)
        {
            Ghost.transform.position = Vector3.MoveTowards(Ghost.transform.position, ghostEndPosition, ghostSpeed * Time.deltaTime);
            yield return null; // Wait until the next frame
        }

        // Snap the ghost to the exact end position
        Ghost.transform.position = ghostEndPosition;
        Debug.Log("Ghost reached the target position!");

        // Activate the special object
        if (SpecialObject != null)
        {
            SpecialObject.SetActive(true);
            Debug.Log("Special object activated!");
        }

        // Start closing the door
        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        while (Quaternion.Angle(Door.transform.rotation, closedRotation) > 0.1f)
        {
            Door.transform.rotation = Quaternion.Lerp(Door.transform.rotation, closedRotation, Time.deltaTime * openSpeed);
            yield return null;
        }

        // Snap door to fully closed position
        Door.transform.rotation = closedRotation;
        Debug.Log("Door closed.");
    }
}
